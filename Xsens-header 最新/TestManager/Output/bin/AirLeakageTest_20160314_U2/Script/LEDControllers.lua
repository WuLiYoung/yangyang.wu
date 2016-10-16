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
	return LEDController:SetDetectString(str);
end
function M.WriteString(str)
	return LEDController:WriteString(str);
end

function M.WaitForString(ntime)
	return LEDController:WaitForString(ntime);
end
--there is many problem between the convert for the bin strig to other, so just use the same
--language to convert it.
function M.Write_LEDValue(side,nindex,nvalue)
   --there is problem for the Hex convert when the value is bigger than 128
	M.SetDetectString("@_@");
	return LEDController:Write_LEDData(side,nindex,nvalue);
	--M.WaitForString(100);
end	

function M.Close_LED(side,nindex)
	--[[local indexstr=string.char(nindex);
	local ledstr ="Close The "..side.." LED:"..indexstr..declimer;
	M.SetDetectString("@_@");
	M.WriteString(ledstr);
	M.WaitForString(100);
	--]]
	return LEDController:Close_LED(side,nindex);
end	

function M.Close_All_LED(side)
	i = 1;
	while i<=17 do
		M.Close_LED(side,i);
		i= i+1;
	end
end

function M.Get_lightValue(side,index)
	return LEDController:Get_lightValue(side,index);	
end

function M.Set_lightValue(side,index,nvalue)
	LEDController:Set_lightValue(side,index,nvalue);
end

function M.Write_lightCalibData(side)
	LEDController:Write_lightCalibData(side);
end

function M.IsNeedCalibration(ndaygrap)
	return LEDController:IsNeedCalibration(ndaygrap);
end

function M.CycleTest(side)
	local ledstr ="Cycle "..side.." LED"..declimer;
	M.SetDetectString(declimer);
	M.WriteString(ledstr);
	M.WaitForString(8000);
end

function M.Write_lightCalibDate()
	LEDController:Write_lightCalibDate();
end