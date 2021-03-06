--DUT操作函数模块

local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
--instance is fixture
local DUT_LOG = 1;	--记录调试信息
local function DUT_log(fmt,...)
	if (DUT_LOG ~=0) then
		--Log("	:)"..string.format(fmt,...),ID);
        Log("	:)"..tostring(fmt),ID);
	end
end


function M.checksn(str1,str2)
	return MESCHECK:CheckSN(str1,str2);
end

function M.GetFailInfo()
	return MESCHECK:getFmsg();
end
