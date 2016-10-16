--FCT操作函数模块
--fct
local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
--instance is TCP
local DUT_LOG = 1;	--记录调试信息
local function DUT_log(fmt,...)
	if (DUT_LOG ~=0) then
		--Log("	:)"..string.format(fmt,...),ID);
        Log("	:)"..tostring(fmt),ID);
	end
end

function M.CheckError(str)
	
end

function M.SetDetectString(str)
	return TCP:SetDetectString(str);
end
function M.WriteString(str)
	return TCP:SendMsg(str)
end

function M.ReadString()
	return TCP:ReadString();
end

function M.WaitForString(ntime)
	return TCP:WaitForString(ntime);
end

function M.WaitString(str,ntimeout)
	return TCP:WaitString(str,ntimeout);
end

function M.ClearBuffer()
	return TCP:ClearBuffer()
end

--Lex add you function below.