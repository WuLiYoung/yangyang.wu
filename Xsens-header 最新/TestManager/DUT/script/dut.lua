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


function M.SendCmd(str)	--给产品发送一个字符串，不等待产品响应完成
	if (str) then
		DUT:SendCmd(tostring(str));
	end
	--DUT_log(tostring(cmd));
end

function M.SendHexCmd(str)	--给产品发送一个字符串，不等待产品响应完成
	if (str) then
		DUT:SendHexCmd(tostring(str));
	end
	--DUT_log(tostring(cmd));
end



function DiagsCmd(cmd,res_format)	--发送一个命令给Diags,并读取返回值
	
end


function M.DetectString(str)
	local ret = DUT:DetectString(str);
	return ret;
	--assert(ret>=0,"DUT serialport read time out,please check hardware!");
end

function M.SetDetectString(detect)
	DUT:SetDetectString(detect);
end

function M.WaitDetect(timeout)
	local ret = 0;
	if (timeout) then
    	ret = DUT:WaitForString(timeout);
    else
    	ret = DUT:WaitForString();
    end
    --assert(ret>=0,"DUT serialport read time out,please check hardware!");
    return ret;
end

function M.QueryCmd(cmd,fmt,timeout)
	local command=cmd.."\r";
	DUT:QueryCmd(command,fmt,timeout);
end

function M.ReadString()
	local v= tostring(DUT:ReadString());
	return v;
end


