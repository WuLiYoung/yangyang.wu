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


function M.GetOhmData(Index)
	return A34972A:GetOhmData(Index);
end


function M.OpenDevice()
	return A34972A:OpenDevice();
end

function M.storyOhmData(str,delay)
	return A34972A:storyOhmData(str,delay);
end

function M.checkOhmExecuted()
	return A34972A:checkOhmExecuted();
end

function M.setOhmExecuted()
	return A34972A:setOhmExecuted();
end
function M.ResetOhmExecuted()
	return A34972A:ResetOhmExecuted();
end


function M.ResetOhmExecuted()
	return A34972A:ResetOhmExecuted();
end

function M.ReadCur(str)
	return A34972A:ReadCurrent(str);
end

