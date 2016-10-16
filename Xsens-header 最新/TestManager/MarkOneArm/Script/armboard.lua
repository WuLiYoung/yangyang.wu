--ArmBoard操作函数模块

local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
local ArmBoard_LOG = 1;	--记录调试信息

local function ArmBoard_log(fmt,...)
	if (ArmBoard_LOG ~=0) then
		--Log("	:)"..string.format(fmt,...),ID);
        Log("	:)"..tostring(fmt),ID);
	end
end

function M.BundleObjectExcludeTest()
    DbgOut("This is ArmBoard Bundle Test Information!");
    ArmBoard:BundleObjectExcludeTest();
end


function M.SendCmd(str)	--给产品发送一个字符串，不等待产品响应完成
	if (str) then
		ArmBoard:SendCmd(tostring(str));
	end
	--ArmBoard_log(tostring(cmd));
end

function M.ReadString()
	local v= tostring(ArmBoard:ReadString());
	return v;
end

----------
--ARM command wrapper function...

function M.SetDO(bit,value)
	SetDO(bit,value);
end

function M.Reset()
	Reset();
	M.A02Output(0)
	M.A04Output(0)
    M.A01Output(0)
end

function M.A02Output(value)
	local cmd = string.format("DAC1=%.03f",value);
	M.SendCmd(cmd);
	return 0;
end

function M.A04Output(value)
	local cmd = string.format("DAC3=%.03f",value);
	M.SendCmd(cmd);
	return 0;
end

function M.A01Output(value)
    local cmd = string.format("DAC0=%.03f",value);
    M.SendCmd(cmd);
    return 0;
end


function SetDO(bit,value)
    local cmd = string.format("BIT%03d=%01d",bit,value);
	M.SendCmd(cmd);
	return 0;
end

function Reset()
    M.SendCmd("GPIOC01AW00000000");
	M.SendCmd("GPIOC02AW00000000");
	M.SendCmd("GPIOC03AW00000000");
	return 0;
end


function CheckArmBoardLog(returndetail,cot,...)
	local buf = GetLog(tonumber(tc.ID()));

	for i,v in ipairs({...}) do
		local t = string.match(buf,v);
		if (returndetail==1) then
			if (t) then
				--DbgOut("[ CheckArmBoardLog ] : "..tostring(t).."\r\n");
				FAOut(t);
			end
		end
		
		if (cot==0) then
			assert(t==nil,"[ CheckArmBoardLog ] : found "..tostring(t));
		end
	end
end

function getPostLineLog(line)
	local buf = GetLog(tonumber(tc.ID()));
	local t = {};
	for i in string.gmatch(buf,"([^\r\n]*)[\r\n]?") do
			t[#t+1] = i ;
	end

	local index = #t-line;
	if (index<1) then
		index = 1;
	end

	local ret = "";
	for i=index,#t do
		ret = ret ..t[i].."\r\n" ;
	end
	return ret ;
end

function RunScript(cmdline,wait,timeout)
	if (not wait) then
		wait=1;
	end
	
	if (timeout==nil) then
		timeout=30000;
	end
	local tmp_file = "/tmp/outoput_"..tostring(tc.ID())..".txt";
	local ret = Execute(cmdline,tmp_file,wait,timeout);
	local f = io.open(tmp_file,"r");
	if (f==nil) then
		f:close();
		Execute("/bin/rm "..tmp_file);
		return ret;
	end
	
	local buf = f:read("*all");
	f:close();
	Execute("/bin/rm "..tmp_file);
	return ret,buf;
end

function OutToFile(filePath,fmt,...)
	local f = assert(io.open(filePath,"a"));
	local fm={...} ;
	local str = "" ;
	if (fm[1]~=nil) then
		str = string.format(tostring(fmt),...) ;
	else
		str = tostring(fmt) ;
	end
	f:write(str) ;
	f:close();
end

function M.LockInstrument(szLockName)
    return ArmBoard:LockInstrument(szLockName);
end
function M.UnlockInstrument(szLockName)
    return ArmBoard:UnlockInstrument(szLockName);
end
function M.UnlockAllMyInstrument()
    return ArmBoard:UnlockAllMyInstrument();
end

-- add time test

function M.ResetCircuit()
    return ArmBoard:ResetCircuit();
end

function M.ResetCircuitPower()
    return ArmBoard:ResetCircuitPower();
end

function M.ResetCircuitHard()
    return ArmBoard:ResetCircuitHard();
end

function M.SoftLatch()
	return ArmBoard:SoftLatch();
end

function M.TimeTest()
    local ret = ArmBoard:TimeTest();
    DbgOut("TimeTest"..ret);
    return ret;
end

