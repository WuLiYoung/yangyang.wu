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
	return RLEDController:SetDetectString(str);
end
function M.WriteString(str)
	return RLEDController:WriteString(str);
end

function M.WaitForString(ntime)
	return RLEDController:WaitForString(ntime);
end

function M.Write_LEDValue(side,nindex,nvalue)
	M.SetDetectString("@_@");
	return RLEDController:Write_LEDData(side,nindex,nvalue);
	--M.WaitForString(100);
end	

function M.Close_LED(side,nindex)
	--[[local indexstr=string.char(nindex);
	local ledstr ="Close The "..side.." LED:"..indexstr..declimer;
	M.SetDetectString("@_@");
	M.WriteString(ledstr);
	M.WaitForString(100);
	--]]
	return RLEDController:Close_LED(side,nindex);
end	

function M.Close_All_LED(side)
	i = 1;
	while i<=17 do
		M.Close_LED(side,i);
		i= i+1;
	end
end

function M.Get_lightValue(side,index)
	return RLEDController:Get_lightValue(side,index);	
end

function M.Set_lightValue(side,index,nvalue)
	RLEDController:Set_lightValue(side,index,nvalue);
end

function M.Write_lightCalibData(side)
	RLEDController:Write_lightCalibData(side);
end

function M.IsNeedCalibration(ndaygrap)
	return RLEDController:IsNeedCalibration(ndaygrap);
end

function M.CycleTest(side)
	local ledstr ="Cycle "..side.." LED"..declimer;
	M.SetDetectString(declimer);
	M.WriteString(ledstr);
	M.WaitForString(8000);
end

function M.Write_lightCalibDate()
	RLEDController:Write_lightCalibDate();
end