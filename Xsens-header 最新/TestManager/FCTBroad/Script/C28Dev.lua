--FCT操作函数模块
--fct
local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
--instance is C28DevInst
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
	return C28DevInst:SetDetectString(str);
end
function M.WriteString(str)
	return C28DevInst:WriteString(str);
end

function M.ReadString()
	return C28DevInst:ReadString();
end

function M.WaitForString(ntime)
	return C28DevInst:WaitForString(ntime);
end

function M.WaitString(str,ntimeout)
	return C28DevInst:WaitString(str,ntimeout);
end

function M.ClearBuffer()
	return C28DevInst:ClearBuffer()
end

--Lex add you function below.