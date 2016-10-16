--DUT操作函数模块

local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
local DUT_LOG = 1;	--记录调试信息
local function DUT_log(fmt,...)
	if (DUT_LOG ~=0) then
		--Log("	:)"..string.format(fmt,...),ID);
        Log("	:)"..tostring(fmt),ID);
	end
end

function M.SetDetectString(str)
	return LuxMeter:SetDetectString(str);
end
function M.WriteString(str)
	return LuxMeter:WriteString(str);
end

function M.ReadString()
	return LuxMeter:ReadString();
end

function M.WaitForString(ntime)
	return LuxMeter:WaitForString(ntime);
end

function M.Connnect_Luxmeter()
	LuxMeter:DoConnect();--Re connect the com here.
	local str = string.char(2).."00541   "..string.char(3).."13".."\013\010";
	M.WriteString(str);
	Delay(500);
end

local configframe = "\00200100200\00300\013\010";
function M.Config_Luxmeter()
	M.WriteString(configframe);
	Delay(3000);
end	

function M.CheckBCC(value)
	if value==nil	then
		return false;
	end
	len = string.len(value);
	stxstart,stxend= string.find(value,"\002");
	etxstart,etxend= string.find(value,"\003");
	if stxstart == 1 then
		return true;
	else
		--DbgOut("Lux "..tostring(stxstart)..tostring(stxend));
		return false;
	end
	return true;
end
function M.Get_LuxValue()
	str =configframe;
	M.SetDetectString(declimer);
	M.WriteString(str);
	if(M.WaitForString(100) == -1) then
		--msgbox("luxmeter.WaitForString TimeOut!");
	end
	retvalue =M.ReadString();
	if(retvalue ~= nil) then
		--DbgOut("Lux value :"..tostring(retvalue));
	end
	local ret = 0;
	local expnum;
	if(retvalue~=nil and string.len(retvalue) >= 32 and M.CheckBCC(retvalue)) then
		stxstart,stxend= string.find(retvalue,"\002");
		 sign = string.sub(retvalue,10,10);
		 value= string.sub(retvalue,11,14);
		if(value ~= nil) then
		 	ret  = tonumber(value);
		else
			DbgOut("LuxMeter get nothing!");
			return ret;
		end
		 expstr = string.sub(retvalue,15,15);
		 if expstr ~=nil then
			expnum  = tonumber(expstr);
		 else
			return 0;
		 end
		 ret=ret*(math.pow(10,(expnum-4))); 
		 if(sign =="-") then
		 	ret = -ret;
		 end
		 return ret;		 
	end
	return ret;
end


function M.Get_LuxSafeValue()
	ret = 0;
	trytime = 3;
	while trytime>=0 do
		Delay(200);
		ret = M.Get_LuxValue();
		trytime = trytime-1;
	end
	return ret;
end