--DataPusher操作函数模块
--dp
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


function M.IsOpen()
	return DataPusher:IsOpen();
end

function M.IsConnect()
	return DataPusher:IsConnect();
end

--Send the data to thre remote
function M.Send(data)
	if data then 
		len = #data;
		str = "@@"..string.format("%04d",len)..data.."\r\n";
		return DataPusher:Send(str);
	end
	return nil;
end

function IsMacTesting(str)
	if str and string.find(str,"OK") then
		return true;
	end
	return false;
end

--Read the buffer data from the dll
function M.ReadBuffer()
	return DataPusher:ReadBuffer(ID);
end

--Check if the Mac is Busy.
function M.IsMacBusy()
	return DataPusher:getMacStatue();
end