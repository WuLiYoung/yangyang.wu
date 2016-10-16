--fixture.

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

function M.CheckError(str)
	
end

function M.GetDutIndex()
	return tonumber(EEBroad:GetDut())
end

function M.SetDutIndex(index)
	return tonumber(EEBroad:SetDut(index))
end

function M.SetDetectString(str)
	return EEBroad:SetDetectString(str);
end
function M.WriteString(str)
	return EEBroad:WriteString(str);
end

function M.ReadString()
	return EEBroad:ReadString();
end

function M.WaitForString(ntime)
	return EEBroad:WaitForString(ntime);
end

function M.WaitString(str,ntimeout)
	return EEBroad:WaitString(str,ntimeout);
end

function M.Cylinder_work()
	M.SetDetectString("@_@");
	M.WriteString("Control Cylinder Work\r\n"); 
	if M.WaitForString(20000) ~=-1 then
		ret = M.ReadString();
		if(ret~=nil) then
			sub = string.find(ret,"Control Cylinder Work Finish");
			if sub ~= nil then
				return 0;
			else
				TestErrorMsg("Cylinder work faild (E0010)"..ret);
				return -1;
			end
		end	
	end
	return -1;
end	

--Write the command when all the test end
function M.SafeWrite(str)
	return EEBroad:SafeWrite(str);
end

function M.FixtureUp()
	return EEBroad:FixtureUp(ID);
end



-- Air Solenoid Valve Control
function M.MainAirSolenoidValveAction(action)
	M.SetDetectString("OK");
	if (tostring(action) == "on") then
		M.WriteString("MAN_POSITIVE_ON\r\n")
	elseif (tostring(action) == "off") then
		M.WriteString("MAN_POSITIVE_OFF\r\n")
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
end


function M.PositiveAirSolenoidValveAction(index,action)
	M.SetDetectString("OK");
	
	if 	(tonumber(index) == 0) then
		if (tostring(action) == "on") then
			M.WriteString("POSITIVE_A_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("POSITIVE_A_OFF\r\n")
		else
			return -1
		end
	elseif (tonumber(index) == 1) then
		if (tostring(action) == "on") then
			M.WriteString("POSITIVE_B_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("POSITIVE_B_OFF\r\n")
		else
			return -1
		end
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
end


function M.NegativeAirSolenoidValveAction(index,action)
	M.SetDetectString("OK");
	
	if 	(tonumber(index) == 0) then
		if (tostring(action) == "on") then
			M.WriteString("NEGATIVE_A_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("NEGATIVE_A_OFF\r\n")
		else
			return -1
		end
	elseif (tonumber(index) == 1) then
		if (tostring(action) == "on") then
			M.WriteString("NEGATIVE_B_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("NEGATIVE_B_OFF\r\n")
		else
			return -1
		end
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
end


function M.VacuumAction(action)
	M.SetDetectString("OK");
	if (tostring(action) == "on") then
		M.WriteString("VACUUM_ON\r\n")
	elseif (tostring(action) == "off") then
		M.WriteString("VACUUM_OFF\r\n")
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
	
end


-- Air Cylinder Action Control
function M.HoldAirCylinderOutAction(index, action)
	M.SetDetectString("OK");
	
	if 	(tonumber(index) == 0) then
		if (tostring(action) == "on") then
			M.WriteString("HOLD_OUT_A_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("HOLD_OUT_A_OFF\r\n")
		else
			return -1
		end
	elseif (tonumber(index) == 1) then
		if (tostring(action) == "on") then
			M.WriteString("HOLD_OUT_B_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("HOLD_OUT_B_OFF\r\n")
		else
			return -1
		end
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
end


function M.HoldAirCylinderInAction(index, action)
	M.SetDetectString("OK");
	
	if 	(tonumber(index) == 0) then
		if (tostring(action) == "on") then
			M.WriteString("HOLD_IN_A_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("HOLD_IN_A_OFF\r\n")
		else
			return -1
		end
	elseif (tonumber(index) == 1) then
		if (tostring(action) == "on") then
			M.WriteString("HOLD_IN_B_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("HOLD_IN_B_OFF\r\n")
		else
			return -1
		end
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
end


function M.FixtureAirCylinderUpAction(index, action)
	M.SetDetectString("OK");
	
	if 	(tonumber(index) == 0) then
		if (tostring(action) == "on") then
			M.WriteString("UP_A_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("UP_A_OFF\r\n")
		else
			return -1
		end
	elseif (tonumber(index) == 1) then
		if (tostring(action) == "on") then
			M.WriteString("UP_B_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("UP_B_OFF\r\n")
		else
			return -1
		end
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
end


function M.FixtureAirCylinderDownAction(index, action)
	M.SetDetectString("OK");
	
	if 	(tonumber(index) == 0) then
		if (tostring(action) == "on") then
			M.WriteString("DOWN_A_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("DOWN_A_OFF\r\n")
		else
			return -1
		end
	elseif (tonumber(index) == 1) then
		if (tostring(action) == "on") then
			M.WriteString("DOWN_B_ON\r\n")
		elseif (tostring(action) == "off") then
			M.WriteString("DOWN_B_OFF\r\n")
		else
			return -1
		end
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	
	return -1
end



-- Get Air Cylinder Position status
function M.FixtureAirCylinderPositionStatus(index,position)
	if 	(tonumber(index) == 0) then
		if (tostring(position) == "up") then
			M.WriteString("SEN_UP_A\r\n")
			Delay(200)
			return tostring(M.ReadString())
		elseif (tostring(position) == "down") then
			M.WriteString("SEN_DOWN_A\r\n")
			Delay(200)
			return tostring(M.ReadString())
		end
	elseif (tonumber(index) == 1) then
		if (tostring(position) == "up") then
			M.WriteString("SEN_UP_B\r\n")
			Delay(200)
			return tostring(M.ReadString())
		elseif (tostring(position) == "down") then
			M.WriteString("SEN_DOWN_B\r\n")
			Delay(200)
			return tostring(M.ReadString())
		end	
	end
	
	return nil
end


function M.HoldAirCylinderPositionStatus(index,lock)
	if 	(tonumber(index) == 0) then
		if (tostring(lock) == "lock") then
			M.WriteString("SEN_HOLD_OUT_A_OPEN\r\n")
			Delay(200)
			return tostring(M.ReadString())
		elseif (tostring(lock) == "unlock") then
			M.WriteString("SEN_HOLD_IN_A_OPEN\r\n")
			Delay(200)
			return tostring(M.ReadString())
		end
	elseif (tonumber(index) == 1) then
		if (tostring(lock) == "lock") then
			M.WriteString("HOLD_OUT_B_ON\r\n")
			Delay(200)
			return tostring(M.ReadString())
		elseif (tostring(lock) == "unlock") then
			M.WriteString("HOLD_IN_B_ON\r\n")
			Delay(200)
			return tostring(M.ReadString())
		end		
	end
	
	return nil
end


-- Check Raster Status
function M.CheckRaster(index)
	local str
	if (tonumber(index) == 0) then
		M.WriteString("RASTER_A\r\n")
		Delay(200)
		str = tostring(M.ReadString())
		if (str == "RASTER_A_OPEN") then
			return 0
		elseif (str == "RASTER_A_CLOSE") then
			return 1
		else
			return -1
		end
	elseif (tonumber(index) == 1) then
		M.WriteString("RASTER_B\r\n")
		Delay(200)
		str = tostring(M.ReadString())
		if (str == "RASTER_B_OPEN") then
			return 0
		elseif (str == "RASTER_B_CLOSE") then
			return 1
		else
			return -1
		end
	end
	
	return -1
end

-- Check Switch Status
function M.CheckPresureSwitch()
	local str
	M.WriteString("PRE_SW\r\n")
	Delay(200)
	str = tostring(M.ReadString())
	if (str == "Pressure_switch_Open") then
		return 0
	elseif (str == "Pressure_switch_Close") then
		return 1
	else
		return -1
	end
end

function M.CheckSafeSwitch()
	local str
	M.WriteString("SAFE_SW\r\n")
	Delay(200)
	str = tostring(M.ReadString())
	
	if (str == "safe_switch_Open") then
		return 0
	elseif (str == "safe_switch_Close") then
		return 1
	else
		return -1
	end
end


-- Set Raster Color
function M.SetRasterColor(index,indicatorLamp,switch)
	M.SetDetectString("OK");
	
	if (tonumber(index) == 0) then 
		if 	(tostring(indicatorLamp) == "green") then
			if (tostring(switch) == "on") then
				M.WriteString("GREEN_LED_A_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("GREEN_LED_A_OFF\r\n")
			else
				return -1
			end
		elseif (tostring(indicatorLamp) == "red") then
			if (tostring(switch) == "on") then
				M.WriteString("RED_LED_A_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("RED_LED_A_OFF\r\n")
			else
				return -1
			end
		elseif (tostring(indicatorLamp) == "orange") then
			if (tostring(switch) == "on") then
				M.WriteString("ORANGE_LED_A_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("ORANGE_LED_A_OFF\r\n")
			else
				return -1
			end
		elseif (tostring(indicatorLamp) == "run") then
			if (tostring(switch) == "on") then
				M.WriteString("RUN_LED_A_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("RUN_LED_A_OFF\r\n")
			else
				return -1
			end
		else
			return -1
		end
	elseif (tonumber(index) == 1) then 
		if 	(tostring(indicatorLamp) == "green") then
			if (tostring(switch) == "on") then
				M.WriteString("GREEN_LED_B_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("GREEN_LED_B_OFF\r\n")
			else
				return -1
			end
		elseif (tostring(indicatorLamp) == "red") then
			if (tostring(switch) == "on") then
				M.WriteString("RED_LED_B_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("RED_LED_B_OFF\r\n")
			else
				return -1
			end
		elseif (tostring(indicatorLamp) == "orange") then
			if (tostring(switch) == "on") then
				M.WriteString("ORANGE_LED_B_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("ORANGE_LED_B_OFF\r\n")
			else
				return -1
			end
		elseif (tostring(indicatorLamp) == "run") then
			if (tostring(switch) == "on") then
				M.WriteString("RUN_LED_B_ON\r\n")
			elseif (tostring(switch) == "off") then
				M.WriteString("RUN_LED_B_OFF\r\n")
			else
				return -1
			end
		else
			return -1
		end
	else
		return -1
	end
	
	M.WaitForString(15000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	return -1;
end



-- Combined Command
function M.PerformDutTest(index)
	M.SetDetectString("OK");
	if (tonumber(index) == 0) then
		M.WriteString("START_VALUE_A\r\n")
	elseif (tonumber(index) == 1) then
		M.WriteString("START_VALUE_B\r\n")
	else
		return -1
	end
	
	M.WaitForString(30000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	return -1;
end


function M.PerformDutReset(index)
	M.SetDetectString("OK");
	if (tonumber(index) == 0) then
		M.WriteString("RESET_VALUE_A\r\n")
	elseif (tonumber(index) == 1) then
		M.WriteString("RESET_VALUE_B\r\n")
	else
		return -1
	end
	
	M.WaitForString(30000)
	
	ret = M.ReadString();
	if(ret~=nil) then
		sub = string.find(ret,"OK");
		return 0
	end
	return -1;
end