Module="Air_Leakage_Test"			--Module Name
Version="Script Version 20160311 V1.0"						--Version add write factor
Customer="Apple"					--Customer ID
StationID=""					--Station ID
LineID=""					--Line ID
FixtureID=""					--Fixture ID
DirInLogPath="FCT"

DutIndex=0

local IDTable={};
local SF=1;





function Test_OnEntry(par)		--Initial function for startup test,you can add test initial code in here
    DutIndex = fixture.GetDutIndex()
    
    if (DutIndex == -1) then
        Peform_Assert("Fixture Down Failed")	
    end

    DbgOut("DUT"..DutIndex.. " is testing")
    
    -- Check Pressure sensor
    if (fixture.CheckPresureSwitch("on") ~= 0) then
        DbgOut("presure:"..fixture.CheckPresureSwitch("on"))
        Peform_Assert("Presure switch is not open") 
    end
        
    -- Check Raster
	if (fixture.CheckRaster(DutIndex) ~= 0) then
        Peform_Assert("Raster is not open")
    end


    --Check Safe Switch
    if (fixture.CheckSafeSwitch() ~= 0) then
       Peform_Assert("check safe switch is not open")   
    end

    -- check V11 close
    if(string.match(fixture.FixtureAirCylinderPositionStatus(DutIndex,"up"),"OPEN") == nil) then            
        local str1 = fixture.FixtureAirCylinderPositionStatus(DutIndex,"up")      
         DbgOut("str1:"..str1)  
         Peform_Assert("Fixture status is not up")
	end

    -- check V7 status
    if (string.match(fixture.HoldAirCylinderPositionStatus(DutIndex,"unlock"),"OPEN") == nil ) then
        Peform_Assert("Hold Fixture(V7) is not up")         
    end 
        
        
    -- V11 on V12 off
	if (fixture.FixtureAirCylinderUpAction(DutIndex,"on") ~= 0) then
        Peform_Assert("Fixture Down Failed")		
	end
    
    -- check V11 status
    for i=1,10 do
        if(string.match(fixture.FixtureAirCylinderPositionStatus(DutIndex,"down"),"OPEN")) then            
            break
	    end
           
        Delay(500)
        
        if (i == 10) then
             Peform_Assert("Check V11 off Failed")   
        end         
	end
    

	-- V7 on V8 off
	if (fixture.HoldAirCylinderOutAction(DutIndex,"on") ~= 0) then  
         Peform_Assert("V7 off Failed") 
	end
    
    -- Check V7 status  
     for i=1,10 do
        if (string.match(fixture.HoldAirCylinderPositionStatus(DutIndex,"lock"),"OPEN")) then
            break         
        end 
        
        if (i == 10) then
             Peform_Assert("Check V7 off Failed")   
        end
           
        Delay(500)
	end

	
	-- V1 on
	if (fixture.MainAirSolenoidValveAction("on") ~= 0) then
        Peform_Assert("V1 off Failed")
	end
	
	-- V2 on 
	if (fixture.PositiveAirSolenoidValveAction(DutIndex,"on") ~= 0) then
        Peform_Assert("V2 off Failed")
	end
	
	-- V4 on 
	if (fixture.NegativeAirSolenoidValveAction(DutIndex,"on") ~= 0) then
		 Peform_Assert("V4 off Failed")
	end
	
	-- V6 on
	if (fixture.VacuumAction("on") ~= 0) then
		 Peform_Assert("V6 off Failed")
	end
	
	-- Check Presure	--Maybe we need time to wait for it done..
    for i=1,10 do
	    if (fixture.CheckPresureSwitch("Close") == 1) then
            break
	    end   
        
        if (i == 10) then
            Peform_Assert("check presure failed")
	    end
        
        Delay(500)   
	end
	
	-- V1 off
	if (fixture.MainAirSolenoidValveAction("off") ~= 0) then
		Peform_Assert("v1 off failed")
	end	
end

function Test_OnAbort(par)
	--fixture.PerformDutReset()
	--Perform_CompletedTest()
	Perfrom_C28StopTest()
    Perform_CompletedTest()
	Delay(2000)
end

function Test_OnFail(par)		--Clear function for test failed,you can add clear function code in here when test failed.
	--fixture.PerformDutReset()
	--Perform_CompletedTest()
    Perform_CompletedTest()
end

function Test_OnDone(par)		--Clear function for normal test finish.you can add clear function code in there when test normally finish.	
	--fixture.PerformDutReset()	
	--Perform_CompletedTest()
    Perform_CompletedTest()
end

function TestFunc()
	Delay(1000)
	return 0
end

function Perfrom_C28Test()
	--[[local strRead
    
    fixture.SetDutIndex(-1)
    
	c28.ClearBuffer()
	c28.SetDetectString("Stop");
	c28.WriteString("\r\nM\\S1TStart\r\n")
	
	if c28.WaitForString(35000) ~=-1 then
		Delay(1000)
		strRead = c28.ReadString();
		Delay(1000)
		strRead = strRead..tostring(c28.ReadString())
		DbgOut(tostring(strRead))
		if(strRead ~= nil) then
			if (string.find(strRead,"SL -") ~= nil) then
				return -1
			end
			

			local PL,Pt,EDC,PLR,FPR,LOF = string.match(strRead,"PL%s+([%.%-%d]+)%s+dPa%s+Pt%s+([%-%.%d]+)%s+kPa%s+EDC%s+([%.%-%d]+)%s+dPa%s+PLR%s+([%.%-%d]+)%s+dPa%s+FPR%s+([%.%-%d]+)%s+kPa%s+LOF%s+([%.%-%d]+)%s+dPa")
			DbgOut("PL:"..PL.."\nPT:"..Pt.."\nEDC:"..EDC.."\nPLR:"..PLR.."\nFPR:"..FPR.."\nLOF:"..LOF)
			return tonumber(PL)
		end
	end

	DbgOut("Failed:"..tostring(strRead))
--]]
end


function Perfrom_C28StopTest()
	local strRead
	DbgOut("Perfrom_C28StopTest")
	c28.WriteString("\r\nM\\S1TStop\r\n")
	c28.ClearBuffer()
end

function Peform_Assert(msg)
    Perform_CompletedTest()
    assert(false,tostring(msg))  
end


function Perform_CompletedTest() 
    -- V6 off
	if (fixture.VacuumAction("off") ~= 0) then
        Peform_Assert("V6 on failed")
	end
    
    -- V3 on
    local index = tonumber(1-tonumber(DutIndex))
	if (fixture.PositiveAirSolenoidValveAction(index,"on") ~= 0) then
		Peform_Assert("V3 on failed")
	end
    
    -- Check Presure	--Maybe we need time to wait for it done..
    Delay(5000)
	if (fixture.CheckPresureSwitch("on") ~= 0) then
        DbgOut("presure:"..fixture.CheckPresureSwitch("on"))
        Peform_Assert("checkPresureSwitch open failed")
	end
    
    -- V1 off
	if (fixture.MainAirSolenoidValveAction("off") ~= 0) then
        Peform_Assert("V1 off failed")
	end
    
	-- V2 off
	if (fixture.PositiveAirSolenoidValveAction(DutIndex,"off") ~= 0) then
         Peform_Assert("V2 off failed")		
	end
	
	-- V3 off
	if (fixture.PositiveAirSolenoidValveAction((1-DutIndex),"off") ~= 0) then
        Peform_Assert("V3 off failed")		
	end
	
	-- V4 off 
	if (fixture.NegativeAirSolenoidValveAction(DutIndex,"off") ~= 0) then
		Peform_Assert("V4 off failed")
	end
	
	-- V7 off
	if (fixture.HoldAirCylinderOutAction(DutIndex,"off") ~= 0) then
        Peform_Assert("V7 off failed")		
	end

	-- V11 off
	if (fixture.FixtureAirCylinderUpAction(DutIndex,"off") ~= 0) then
		Peform_Assert("V11 off failed")
	end
    
    -- Check Raster
	if (fixture.CheckRaster(DutIndex) ~= 0) then
        Peform_Assert("Raster is not open")
    end
end



local AIR_LEAKAGE_CHECK_Sub={
	{name="Air_Leakage_Test",lower=1,upper=2,unit="dPa",entry=Perfrom_C28Test,parameter={id=ID},visible=1},
};


local AIR_LEAKAGE_CHECK_Item={name="Air_Leakage_Test",entry=nil,parameter=nil,sub=AIR_LEAKAGE_CHECK_Sub};

items = 
{
	AIR_LEAKAGE_CHECK_Item,
}