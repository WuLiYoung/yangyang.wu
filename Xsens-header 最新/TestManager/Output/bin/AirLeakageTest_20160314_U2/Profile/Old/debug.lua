__Module="Debug Sequence"		--Module Name
__Version="SequenceVersion:1.3"			--Version
__StationID="1"					--Station ID
__LineID="1"					--Line ID
__TSTBDID="1"					--TEST ID

--[[
Test Sequence Version History:
V1.00: 20150728 Debug the first time in SHENZHEN Before Shipment;
V1.1:  20150808 Update motion and PMIC I2C test.
V1.3:  20150815 Update test script,the voltage current time test is ok.The test items of communicate with product can't test in MACOSX now.
]]


function Test_OnEntry(par)

	Initial();

end

function Test_OnFail(par)
	
	Initial();
--	fixture.WriteString("Test fail\r\n");
	Lock()
	fixture.Up();
	UnLock();
end

function Test_OnAbort(par)
	Initial();
	Lock()
	fixture.Up();
	UnLock();
end

function Test_OnDone(par)

	Initial();
	Lock()
	fixture.Up();
	UnLock();
end


current = 0;
-----------------------------------------------------------------------------------------
-----------------------Volt Current test-------------------------------------------------

function Initial(par)	
	do return end;
	armboard.SendCmd("SBIT1,2,3,4,5,6,7,8,9,10=1,0,1,0,1,1,0,0,0,0");
	armboard.SendCmd("SBIT11,12,13,14,15,20,21=1,1,0,0,0,0,0");
	--armboard.SendCmd("SBIT22,23,24,25,26,28,33=0,1,0,0,0,1,1","\r\n",200);
	armboard.SendCmd("SBIT22,23,24,25,26,33=0,1,0,0,0,1");
	armboard.SendCmd("SBIT45,47,49,50,52,53=0,0,0,0,0,1");
	armboard.SendCmd("SBIT35,36,37,38,39,41,43=0,1,0,0,1,0,0");
	--armboard.SendCmd("SBIT45,47,49,50,51,52,53=0,0,0,0,1,0,1","\r\n",200);
	armboard.SendCmd("DAC0=0","\r\n");
	armboard.SendCmd("DAC1=0","\r\n");
	armboard.SendCmd("DAC2=0","\r\n");
	armboard.SendCmd("DAC3=0","\r\n");
	Delay(100);
end

function OutPutOnOff(par)
	if par.index == "VBATT" then
		local cmd1 = string.format("DAC1=%.03f",par.volt);
		local cmd2 = string.format("SBIT15=%d",par.state);
		local cmdEnable = string.format("SBIT%d,%d=%d,%d",12,14,1,1);
		armboard.SendCmd(cmd1);
		Delay(10)
		armboard.SendCmd(cmd2);
		Delay(50)
		armboard.SendCmd(cmdEnable);	
		Delay(1000);
		armboard.SendCmd("SBIT14=0");
	end
	if par.index == "USB" then
		local cmd3 = string.format("DAC3=%.03f",par.volt);
		local cmd4 = string.format("SBIT26=%d",par.state);
		armboard.SendCmd(cmd3);
		armboard.SendCmd(cmd4);
		Delay(100);
		
	end
	if par.index == "QuiescentVBATT" then
		local cmd1 = string.format("DAC1=%.03f",par.volt);
		local cmd2 = string.format("SBIT15=%d",par.state);
		armboard.SendCmd(cmd1);
		Delay(500)
		armboard.SendCmd(cmd2);
	end
	
end

function LoadCurrent(par)
	if par == "PP3V0Load400mA" then
		armboard.SendCmd("DAC0=2");
		Delay(50);
		armboard.SendCmd("SBIT2=1");
	
	elseif par == "LDOLoad50mA" then
		armboard.SendCmd("DAC0=0.5");
		Delay(50);
		armboard.SendCmd("SBIT8=1");
		
	elseif par == "Load10mA" then
		armboard.SendCmd("DAC0=0.1");
		Delay(50);
		armboard.SendCmd("SBIT6=0");
	
	elseif par == "PP3V7Load400mA" then
		armboard.SendCmd("DAC0=4");
		Delay(50);
		armboard.SendCmd("SBIT4=1");
	elseif par == "7V2Load50mA" then
		armboard.SendCmd("DAC0=0.5");
		Delay(50);
		armboard.SendCmd("SBIT11=0");
	end	
end

function ReadVoltTest(par)		
	current = 0;
	local ret = nil;
	if par == "PP3V0"then
		LoadCurrent("PP3V0Load400mA");
		local cmdAd = string.format("SBIT%d,%d,%d,%d,%d=%d,%d,%d,%d,%d",47,45,43,41,44,1,0,0,0,0);
		armboard.SendCmd(cmdAd);
		Delay(50);
		armboard.SendCmd("ADD00R01");
	--   MessageBox("pp3v0");
		Delay(50);
		ret = armboard.ReadString();
	--	msgbox(ret,"123",1)
		DbgOut("Read PP3V0 volt is :"..ret);
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current = string.match(current,"ADD04G01D (.+)")
		armboard.SendCmd("SBIT2=0");		
		armboard.SendCmd("DAC0=0");		

	elseif par == "PP3V0_LDO" then
		LoadCurrent("LDOLoad50mA");
--		local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d",47,45,43,41,44,12,14,1,0,1,1,0,1,1);
		armboard.SendCmd("SBIT47,41,43,45=1,1,1,0");
		Delay(50);
		armboard.SendCmd("ADD00R01");
		Delay(50);
		ret = armboard.ReadString();
		--MessgeBox(ret)
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current = string.match(current,"ADD04G01D (.+)")
		armboard.SendCmd("SBIT8=0");
		armboard.SendCmd("DAC0=0");		

	elseif par == "PP3V0_VBAT_LDO" then
		LoadCurrent("Load10mA");
	--	local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d",47,45,43,41,44,7,9,1,0,1,0,0,0,0);
		armboard.SendCmd("SBIT47,41,43,45=1,0,1,0");
		armboard.SendCmd("ADD00R01");
		Delay(50);
		ret = armboard.ReadString();
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current = string.match(current,"ADD04G01D (.+)")
		armboard.SendCmd("SBIT6=1");
		
	elseif par == "PP3V7" then
		LoadCurrent("PP3V7Load400mA");
--		local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d",47,45,43,41,44,7,9,1,0,0,1,0,0,0);
		armboard.SendCmd("SBIT47,41,43,45=1,1,0,0");
		armboard.SendCmd("ADD00R01");
		Delay(50);
		ret = armboard.ReadString();
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current = string.match(current,"ADD04G01D (.+)")
		armboard.SendCmd("SBIT4=0");
		armboard.SendCmd("DAC0=0");

	elseif par == "PP7V2" then
		local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d,%d",13,5,3,11,39,44,7,9,0,1,0,1,1,0,0,0);
		armboard.SendCmd(cmd1);
		LoadCurrent("7V2Load50mA");
		armboard.SendCmd("ADD01R01");
		ret = armboard.ReadString();
		armboard.SendCmd("ADD04R01");
		current =armboard.ReadString();
		current = string.match(current,"ADD04G01D (.+)")
		armboard.SendCmd("SBIT11=1");
		if ret == nil then
			return -1;
		end
		local volt = string.match(ret,"ADD01G01D (.+)");
		if volt == nil then
			return -1;
		end
		return tonumber(volt);
	end
	local cmd = string.format("SBIT%d,%d,%d,%d,%d=%d,%d,%d,%d,%d",47,45,43,41,14,0,0,0,0,0);
	armboard.SendCmd(cmd);
	if ret == nil then
		return -1;
	end
	local volt = string.match(ret,"ADD00G01D (.+)");
	if volt == nil then
		return -1;
	end
	return tonumber(volt);
end

function ReadCurrentTest(par)
	local ret = nil;
	if par == "USBCharging" then
		armboard.SendCmd("ADD03R01");
		Delay(50);
		ret = armboard.ReadString();
	end
	if par == "SystemOff" then
		armboard.Reset();
		Delay(50);
		armboard.SendCmd("SBIT13=1");
		Delay(400);
		armboard.SendCmd("SBIT14,12=1,0");
		Delay(10);
		local parameter1={index="VBATT",volt="3.7",state=1}
		OutPutOnOff(parameter1);
		local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d",38,37,35,24,22,20,33,1,0,0,1,0,0,0);
		armboard.SendCmd(cmd1);
		armboard.SendCmd("DMMSETRG 100");
		armboard.SendCmd("DMMREADCRR");
--read dmmm	
		local ret = armboard.ReadString();
		if nil == ret then
			return -1;
		end
		ret = string.match(ret,"DMMREADCRR (.+) uA")
		if nil == ret then
			return -1;
		end
		if tonumber(ret)<0 then
		 	return ret*(-1);	
		end
		return tonumber(ret);
	end
	if ret == nil then
		return -1;
	end
	local volt = string.match(ret,"ADD03G01D (.+)");
	if volt == nil then
		return -1;
	end
	return tonumber(volt)*(-100);
end

-----------------------------------------------------------------------------------------
----------------------Time test----------------------------------------------------------
function ResetCircuitSoft(par)
	armboard.SendCmd("SBIT21,47=1,1");
	local ret = armboard.ResetCircuit();
	armboard.SendCmd("SBIT25=0");
	if ret == "FAIL" then
		return -1;
	end
	return tonumber(ret)/1000;
end
function ResetCircuitPower(par)
	local ret = armboard.ResetCircuitPower();
--	armboard.SendCmd("SBIT10=0","\r\n",200);
	if ret == "FAIL" then
		return -1;
	end
	return tonumber(ret)*1000;
end
function ResetCircuitHard(par)
	Initial();
	armboard.SendCmd("DAC1=3.7");
	armboard.SendCmd("SBIT15=1");
	local ret = armboard.ResetCircuitHard();
	--armboard.SendCmd("SBIT10,21=,0","\r\n",200);
	if ret == "FAIL" then
		return -1;
	end
	return tonumber(ret)/1000;
end
function SoftLatch(par)	
	Initial();
	armboard.SendCmd("DAC1=3.7");
	armboard.SendCmd("SBIT15=1");
	Delay(100)
	local ret = armboard.SoftLatch();
	armboard.SendCmd("SBIT10=0");
	if ret == "FAIL" then
		return -1,"FAIL";
	end
	return tostring(ret);	
end
-----------------------------------------------------------------------------------------
---------------------DUT communicate test------------------------------------------------
function SetMotionMode()
	local mode = "I2CWRITE D4 20 01 = 70";
	local cmd = string.format("SBIT%d,%d,%d,%d=%d,%d,%d,%d",38,37,35,1,1,0,1,0);
	armboard.SendCmd(cmd);
	Delay(10);
	armboard.SendCmd("I2CWRITE D4 20 01 = 70");
	Delay(50)
end

-- accelerometer = register*sensitivity

function MotionAccelerometerX(par)
	local I2CX = "I2CREAD D5 28 02";
--	local cmd = string.format("SBIT%d,%d,%d,%d=%d,%d,%d,%d",38,37,35,1,1,0,1,0);
--	armboard.SendCmd(cmd,"\r\n",200);
	armboard.SendCmd(I2CX);
	Delay(20);
	local motionX =armboard.ReadString();
	if nil == motionX then 
	 	return 99999;
	end
	local motionXresult = string.gsub(motionX,"\r\n","");
	motionXresult = string.match(motionXresult,"I2CREAD OK:(.+)");
--	MessageBox(motionXresult)
	if	nil == motionXresult then
		return 99999;
	end
	local i,j = string.find(motionXresult," ");
	local motionXH = string.sub(motionXresult,i+1,#motionXresult);
	local motionXL = string.sub(motionXresult,1,i-1);
	local XR = string.format("%d","0x"..motionXH);
	local XL = string.format("%d","0x"..motionXL);
--	MessageBox(XL)
	local motionXA = tonumber(XR)*256 + tonumber(XL);
	motionXA = ComplementToOriginal(motionXA);	
	return motionXA;
--send cmd read x,y,z from i2c
end

function MotionAccelerometerY(par)
	local I2CY = "I2CREAD D5 2A 02";
--	local cmd = string.format("SBIT%d,%d,%d,%d=%d,%d,%d,%d",38,37,35,1,1,0,1,0);
--	armboard.SendCmd(cmd,"\r\n",200);
	armboard.SendCmd(I2CY);
	Delay(100);
	local motionY =armboard.ReadString();
--	MessageBox(motionY);
	if nil == motionY then 
	 	return 99999;
	end
	local motionYresult = string.gsub(motionY,"\r\n","");
	motionYresult = string.match(motionYresult,"I2CREAD OK:(.+)");
	if	nil == motionYresult then
		return 99999;
	end
	local i,j = string.find(motionYresult," ");
	local motionYH = string.sub(motionYresult,i+1,#motionYresult);
	local motionYL = string.sub(motionYresult,1,i-1);
	local YR = string.format("%d","0x"..motionYH);
	local YL = string.format("%d","0x"..motionYL);
	local motionYA = tonumber(YR)*256 + tonumber(YL);
	motionYA = ComplementToOriginal(motionYA);
	return motionYA;
--send cmd read x,y,z from i2c
end

function MotionAccelerometerZ(par)
	local I2CZ = "I2CREAD D5 2C 02";
--	local cmd = string.format("SBIT%d,%d,%d,%d=%d,%d,%d,%d",38,37,35,1,1,0,1,0);
--	armboard.SendCmd(cmd,"\r\n",200);
	armboard.SendCmd(I2CZ);
	Delay(100);
	local motionZ =armboard.ReadString();
--	MessageBox(motionZ)
	if nil == motionZ then 
	 	return 99999;
	end
	local motionZresult = string.gsub(motionZ,"\r\n","");
	motionZresult = string.match(motionZresult,"I2CREAD OK:(.+)");
	if	nil == motionZresult then
		return 99999;
	end
	local i,j = string.find(motionZresult," ");
	local motionZH = string.sub(motionZresult,i+1,#motionZresult);
	local motionZL = string.sub(motionZresult,1,i-1);
	local ZR = string.format("%d","0x"..motionZH);
	local ZL = string.format("%d","0x"..motionZL);
	local motionZA = tonumber(ZR)*256 + tonumber(ZL);
	motionZA = ComplementToOriginal(motionZA);
	return motionZA;
--send cmd read x,y,z from i2c
end
function ReadPMIC(par)
	local cmd = string.format("SBIT%d,%d,%d,%d,%d=%d,%d,%d,%d,%d",38,37,35,7,9,1,0,1,1,1);	
	armboard.SendCmd(cmd);
	Delay(50);
	local pmicCmd = "I2CREAD 90 01 01"
	armboard.SendCmd(pmicCmd);
	Delay(100);
	local pmicRegister = armboard.ReadString();
	msgbox(pmicRegister,"133",1);
	if pmicRegister == nil then
		return -1,"FAIL";
	end
	pmicRegister = string.match(pmicRegister,"I2CREAD OK:(.+)");
	if pmicRegister == nil then
		return -1,"FAIL";
	end
	if string.match(pmicRegister,"c") then
		return "PASS";
	end
	return -1,"FAIL";
--send cmd read register from I2C	
end

function CommunicateWithDut()
	armboard.SendCmd("DAC1=0");
	Delay(300);
	local ret = armboard.ReadString();
	armboard.SendCmd("DAC1=3.7");
	Delay(300)
	local ret = armboard.ReadString();
	armboard.SendCmd("SBIT12,14,15,52,50,49=1,1,1,1,1,0");
	Delay(1000);
	local ret = armboard.ReadString();
	Execute("c:\\tools\\DUT.bat")
end 

function SP1M25Flash(par)
	local buffer = io.open("c:\\tools\\log.txt","r");
	if buffer == nil then
	    return nil;
	end
	
	local strRead = buffer:read("*all");
	--MessageBox(strRead);
	buffer:close();
	if (string.match(strRead,"0x54 0x65 0x73 0x74 0x31 0x32 0x33")) then
		return "PASS";
	end
	return  -1,"FAIL";
		
end

function USARTNRFFlash(par)
	local buffer = io.open("c:\\tools\\log.txt","r");
	if buffer == nil then
	    return nil;
	end
	
	local strRead = buffer:read("*all");
	--MessageBox(strRead);
	buffer:close();
	if (string.match(strRead,"Unlocking FW for diagnostics... SUCCESS")) then
		return "PASS";
	end
	return  -1,"FAIL";



end

function DeviceID()
	local buffer = io.open("c:\\tools\\log.txt","r");
	if buffer == nil then
	    return nil;
	end
	
	local strRead = buffer:read("*all");
	--MessageBox(strRead);
	buffer:close();
	local BluethID = (string.match(strRead,"Bluetooth Address: (.+)Detecting port: com4...Found!"))
	msgbox(BluethID,"123",1)
	if BluethID == nil then
		return -1,"FAIL";
	end
	return BluethID;


end

function BatteryVoltage()
	local buffer = io.open("c:\\tools\\log.txt","r");
	if buffer == nil then
	    return nil;
	end
	
	local strRead = buffer:read("*all");
	--MessageBox(strRead);
	buffer:close();
	local volt = (string.match(strRead,"Current battery voltage: (.+)mV"))
	msgbox(volt,"123",1);
	if volt == nil then
		return -1;
	end
	return tonumber(volt)/1000;

end
-----------------------------------------------------------------------------------------
---------------------Program FW----------------------------------------------------------

function ProgramFirmware(par)
	fixture.WriteString("DownLoad start\r\n");
--[[	local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d",7,9,35,37,38,44,48,0,1,0,1,1,1,0);
	armboard.SendCmd(cmd1);
	armboard.ReadString();
	armboard.SendCmd("GPIOC02P22R1");
	local ret = armboard.ReadString();
	if ret == nil then
	
	    fixture.WriteString("Down fail\r\n");
		return -1,"FAIL";
		
	end
	if string.match(ret,"GPIOC02P22S1") then
		fixture.WriteString("Down pass\r\n");
		return "Pass";
	end
	fixture.WriteString("Down fail\r\n");
	return -1,"FAIL";]]
	Execute("c:\\tools\\Download.cmd");
	local buffer = io.open("c:\\tools\\download.txt","r");
	if buffer == nil then
	    return nil;
	end	
	local strRead = buffer:read("*all");
	buffer:close();
	local ret = (string.match(strRead,"ERROR"))
	if ret == nil then
		return "PASS";
	end
	return -1,"FAIL";
end


function ComplementToOriginal(par)
	local re = nil;
	if par >=32768 then
		re = -(65536-par);
		return re;
	end
    re = par;
    return re;
end

function Test4(par)
	if(tonumber(ID)==1 and par.state == 2) then
		Delay(1000);
	else
		Delay(200);
	end
	return 4+tonumber(ID);
end
function Test1(par)
	local ret  =tc.ID();
	if(tonumber(ID)==1) then
		Delay(100);
	else
		Delay(200);
	end
	return 1;
end
function Test2(par)
	if(tonumber(ID)==1 and par.state == 2) then
		Delay(1000);
	else
		Delay(200);
	end
	return 2+tonumber(ID);
end
function Test5(par)
	if(tonumber(ID)==1 and par.state == 2) then
		Delay(1000);
	else
		Delay(200);
	end
	return 5+tonumber(ID);
end
function Test3(par)
	if(tonumber(ID)==1 and par.state == 2) then
		Delay(1000);
	else
		Delay(200);
	end
	return 3+tonumber(ID);
end
function Test6(par)
	if(tonumber(ID)==1 and par.state == 2) then
		Delay(1000);
	else
		Delay(200);
	end
	return 6+tonumber(ID);
end
function Test()
	Delay(1000);
end

function TestLock()
	Lock()
	Delay(1000);
	
	UnLock();
	return 12;
end
local FunctionTest = {
    {name="Apply_VBATT_Enable_System1",lower=1,upper=2,unit=nil,entry=Test1,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 1},
	{name="Apply_VBATT_Enable_System2",lower=0,upper=1,unit=nil,entry=Test1,parameter={index="VBATT",volt="3.7",state=2},skip=0,visible = 1},
	{name="Apply_VBATT_Enable_System3",lower=0,upper=1,unit=nil,entry=TestLock,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 1},
	{name="Apply_VBATT_Enable_System4",lower=0,upper=1,unit=nil,entry=Test2,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 1},
	{name="Apply_VBATT_Enable_System5",lower=0,upper=1,unit=nil,entry=Test3,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 1},
	{name="Apply_VBATT_Enable_System6",lower=0,upper=1,unit=nil,entry=Test4,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 1},

};
local Function_Items={name="Function",entry=nil,parameter=nil,sub=FunctionTest};

items = {
	Function_Items,
};