--DUT��������ģ��

local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
--instance is fixture
local DUT_LOG = 1;	--��¼������Ϣ
local function DUT_log(fmt,...)
	if (DUT_LOG ~=0) then
		--Log("	:)"..string.format(fmt,...),ID);
        Log("	:)"..tostring(fmt),ID);
	end
end


function M.getID()
	return cypress:GetID();
	end

