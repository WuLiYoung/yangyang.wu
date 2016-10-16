Module="MKone Splinter Tester"		--Module Name
Version="SequenceVersion:1.6"			--Version
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
	Lock();
--	fixture.Up();
	UnLock();
end

function Test_OnAbort(par)
	Initial();
--	fixture.WriteString("Test fail\r\n");
	Lock();
	fixture.Up();
	UnLock();
end

function Test_OnDone(par)
	Initial();
	--fixture.WriteString("Test pass\r\n");
	Lock();
	fixture.Up();
	UnLock();
end


current = 0;
-----------------------------------------------------------------------------------------
-----------------------Volt Current test-------------------------------------------------

function Initial(par)
	
	armboard.SendCmd("SBIT1,5,6,11,33,38,39=1,1,1,1,1,1,1");
	Delay(100);
	armboard.SendCmd("SBIT2,4,8,9,10,13,14,21,25,35,37,49,47,52,15,26=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0")
	Delay(50)
	armboard.SendCmd("DAC1=0");
	Delay(10)
	armboard.SendCmd("DAC3=0");
	Delay(10)
	
--[[	armboard.SendCmd("SBIT1,2,3,4,5,6,7,8,9,10=1,0,1,0,1,1,0,0,0,0");
	Delay(10)
	armboard.SendCmd("SBIT11,12,13,14,15,20,21=1,1,0,0,0,0,0");
	Delay(10)
	--armboard.SendCmd("SBIT22,23,24,25,26,28,33=0,1,0,0,0,1,1","\r\n",200);
	armboard.SendCmd("SBIT22,23,24,25,26,33=0,1,0,0,0,1");
	Delay(10)
	armboard.SendCmd("SBIT45,47,49,50,52,53=0,0,0,0,0,1");
	Delay(10)
	armboard.SendCmd("SBIT35,36,37,38,39,41,43=0,1,0,0,1,0,0");
	Delay(10)
	--armboard.SendCmd("SBIT45,47,49,50,51,52,53=0,0,0,0,1,0,1","\r\n",200);
	armboard.SendCmd("DAC0=0");
	Delay(10)
	armboard.SendCmd("DAC1=0");
	Delay(10)
	armboard.SendCmd("DAC2=0");
	Delay(10)
	armboard.SendCmd("DAC3=0");
	Delay(10)
]]
end

function OutPutOnOff(par)
	if par.index == "VBATT" then
		local cmd1 = string.format("DAC1=%.03f",par.volt);
		local cmd2 = string.format("SBIT15=%d",par.state);
		local cmdEnable = string.format("SBIT%d,%d,%d=%d,%d,%d",15,12,14,1,1,1);
		armboard.SendCmd(cmd1);
		Delay(100)		
		armboard.SendCmd(cmdEnable);	
		Delay(1500);
	--	armboard.SendCmd("SBIT14=0");
	end
	if par.index == "USB" then
		local cmd3 = string.format("DAC3=%.03f",par.volt);
		local cmd4 = string.format("SBIT26=%d",par.state);
		armboard.SendCmd(cmd3);
		Delay(100);
		armboard.SendCmd(cmd4);
		Delay(100);
		
	end
	if par.index == "QuiescentVBATT" then
	--	msgbox("123","133",1)
		local cmd1 = string.format("DAC1=%.03f",par.volt);
		local cmd2 = string.format("SBIT15=%d",par.state);
		armboard.SendCmd(cmd1);
		Delay(100)
		armboard.SendCmd(cmd2);
		Delay(100);
	end
	
end

function LoadCurrent(par)
	if par == "PP3V0Load400mA" then
		armboard.SendCmd("DAC0=2");
		Delay(10);
		armboard.SendCmd("SBIT2=1");
	
	elseif par == "LDOLoad50mA" then
		armboard.SendCmd("DAC0=0.5");
		Delay(10);
		armboard.SendCmd("SBIT8=1");
		
	elseif par == "Load10mA" then
		armboard.SendCmd("DAC0=0.1");
		Delay(10);
		armboard.SendCmd("SBIT6=0");
	
	elseif par == "PP3V7Load400mA" then
		armboard.SendCmd("DAC0=4");
		Delay(10);
		armboard.SendCmd("SBIT4=1");
	elseif par == "7V2Load50mA" then
		armboard.SendCmd("DAC0=0.5");
		Delay(10);
		armboard.SendCmd("SBIT11=0");
	end	
end

function ReadVoltTest(par)		
	current = 0;
	local ret = nil;
	if par == "PP3V0"then
		for i =1,5,1 do
			Initial();
			local VBATT={index="VBATT",volt="3.7",state=1}
			OutPutOnOff(VBATT);
			LoadCurrent("PP3V0Load400mA");
			local cmdAd = string.format("SBIT%d,%d,%d,%d=%d,%d,%d,%d",47,45,43,41,1,0,0,0);
			armboard.SendCmd(cmdAd);
			Delay(50);
			armboard.SendCmd("ADD00R01");
			Delay(50);
			ret = armboard.ReadString();
			DbgOut("Read PP3V0 volt is :"..ret);
			local volt = string.match(ret,"ADD00G01D (.+)");
		--	msgbox(volt,"123",1)
			if tonumber(volt) > 2 then
				break;
			end
		end
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current=string.gsub(current,"\r\n","");
		current = string.match(current,"ADD04G01D (.+)")
		current = tonumber(current)*100;
		armboard.SendCmd("SBIT2=0");	
		Delay(50)
		armboard.SendCmd("DAC0=0");		
		

	elseif par == "PP3V0_LDO" then
		LoadCurrent("LDOLoad50mA");
		armboard.SendCmd("SBIT47,41,43,45=1,1,1,0");
		Delay(50);
		armboard.SendCmd("ADD00R01");
		Delay(50);
		ret = armboard.ReadString();
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current=string.gsub(current,"\r\n","");
		current = string.match(current,"ADD04G01D (.+)")
		current = tonumber(current)*100;
		armboard.SendCmd("SBIT8=0");
		Delay(50);
		armboard.SendCmd("DAC0=0");		

	elseif par == "PP3V0_VBAT_LDO" then
		LoadCurrent("Load10mA");
		armboard.SendCmd("SBIT47,41,43,45=1,0,1,0");
		armboard.SendCmd("ADD00R01");
		Delay(50);
		ret = armboard.ReadString();
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current=string.gsub(current,"\r\n","");
		current = string.match(current,"ADD04G01D (.+)")
		current = tonumber(current)*100;
		armboard.SendCmd("SBIT6=1");
		
	elseif par == "PP3V7" then
		LoadCurrent("PP3V7Load400mA");
		armboard.SendCmd("SBIT47,41,43,45=1,1,0,0");
		armboard.SendCmd("ADD00R01");
		Delay(50);
		ret = armboard.ReadString();
		armboard.SendCmd("ADD04R01");
		Delay(50);
		current =armboard.ReadString();
		current=string.gsub(current,"\r\n","");
		current = string.match(current,"ADD04G01D (.+)")
		current = tonumber(current)*100;
		armboard.SendCmd("SBIT4=0");
		Delay(50)
		armboard.SendCmd("DAC0=0");
		Delay(50);
	elseif par == "PP7V2" then
		local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d,%d",13,5,3,11,39,44,7,9,0,1,0,1,1,0,0,0);
		armboard.SendCmd(cmd1);
		LoadCurrent("7V2Load50mA");
		armboard.SendCmd("ADD01R01");
		ret = armboard.ReadString();
		armboard.SendCmd("ADD04R01");
		current =armboard.ReadString();
		current=string.gsub(current,"\r\n","");
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
	local cmd = string.format("SBIT%d,%d,%d,%d=%d,%d,%d,%d",47,45,43,41,0,0,0,0,0);
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

BatteryCurrent =0;
function ReadCurrentTest(par)
BatteryCurrent=0;
	local ret = nil;
	if par == "USBCharging" then
		Delay(2000)
		armboard.SendCmd("ADD03R01");
		Delay(100);
		ret = armboard.ReadString();
	end
	if par == "SystemOff" then
		Initial();
		Delay(50);
		armboard.SendCmd("SBIT13=1");
		Delay(50);		
		local VBATT={index="QuiescentVBATT",volt="3.7",state=1}
		local vusbOn ={index="USB",volt="3.2",state=1} 
		local vusbOff ={index="USB",volt="0",state=0} 
		OutPutOnOff(VBATT);
		OutPutOnOff(vusbOn);
		OutPutOnOff(vusbOff);
--		armboard.SendCmd("SBIT14,12=1,0");
		Delay(100);
--		armboard.SendCmd("SBIT14,12=0,0");
--		local cmd1 = string.format("SBIT%d,%d,%d,%d,%d,%d,%d=%d,%d,%d,%d,%d,%d,%d",38,37,35,24,22,20,33,1,0,0,1,0,0,0);
--		armboard.SendCmd(cmd1);
--		Delay(80);
--		local ret = armboard.ReadString();
		armboard.SendCmd("DMMSETRG 100");
		Delay(80);
		local ret = armboard.ReadString();
		armboard.SendCmd("DMMREADCRR");
		Delay(500);
--read dmmm	
		local ret = armboard.ReadString();
		
--Add batteryCurrent
		armboard.SendCmd("ADD03R01");
		Delay(100);
		BatteryCurrent = armboard.ReadString();
		BatteryCurrent=string.gsub(BatteryCurrent,"\r\n","");
		BatteryCurrent = string.match(BatteryCurrent,"ADD03G01D (.+)")

----------------------------	
		if nil == ret then
			return -1;
		end
	--	msgbox(ret,"123",1)
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
	armboard.SendCmd("SBIT25,21=0,0");
	if ret == "FAIL" then
		return -1;
	end
	return tonumber(ret)/1000;
end
function ResetCircuitPower(par)
--	local ret = armboard.ResetCircuitPower();
	armboard.SendCmd("SBIT47,45,43,41=1,0,0,0");
	Delay(50);
	armboard.SendCmd("SADD00R10");
	while(1) 
	do
	local ret = armboard.ReadString();
	--msgbox(ret,"112",1);
		if #ret~=0 then
			local time = string.match(ret,"ACK (.+) ms");
			if time == nil then
				return -1;
			end
			return time;
		end
	end	
end
function ResetCircuitHard(par)
	local ret = armboard.ResetCircuitHard();
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
	Delay(20);
	armboard.SendCmd("I2CWRITE D4 20 01 = 70");
	Delay(300)
end

-- accelerometer = register*sensitivity

function MotionAccelerometerX(par)
	local I2CX = "I2CREAD D5 28 02";
--	local cmd = string.format("SBIT%d,%d,%d,%d=%d,%d,%d,%d",38,37,35,1,1,0,1,0);
--	armboard.SendCmd(cmd,"\r\n",200);
	armboard.SendCmd(I2CX);
	Delay(50);
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
--	msgbox(pmicRegister,"133",1);
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
	armboard.SendCmd("SBIT12,14,15,52,50,49=1,1,1,1,1,0");
	Delay(200)
	armboard.SendCmd("DAC1=3.7");		
	Delay(1000);	
	dut.ReadString();
end 

function SP1M25Flash(par)
	dut.SendCmd("3");
	Delay(300);
	local ret = dut.ReadString();
--	msgbox(ret,"1223",1)
	if #ret == 0 then
		return -1,"FAIL";
	end
	if 1 == tonumber(ret) then
		return "PASS";
	end
	return -1,"FAIL";
	
end

function USARTNRFFlash(par)
	

end

function DeviceID()
	dut.SendCmd("1");
	Delay(300);
	local ret = dut.ReadString();
--	msgbox(ret,"123",1)
	if #ret == 0 then
		return -1,"FAIL";
	end
	ret = string.gsub(ret,"\n","")
	return ret;
end

function BatteryVoltage()
	dut.SendCmd("2");
	Delay(300);
	local ret = dut.ReadString();
	if #ret == 0 then
		return -1,"FAIL";
	end
--	msgbox(ret);
	local volt = string.format("%d","0x"..ret);
	return volt/1000;
end
-----------------------------------------------------------------------------------------
---------------------Program FW----------------------------------------------------------

function ProgramFirmware(par)
	Lock();
	fixture.WriteString("DownLoad start\r\n");
	UnLock();
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
	if tonumber(ID) == 0 then 
		Execute("c:\\tools\\FW1\\Download1.cmd");
		local buffer = io.open("c:\\tools\\FW1\\download1.txt","r");
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
	if tonumber(ID) == 1 then 
		Execute("c:\\tools\\FW2\\Download2.cmd");
		local buffer = io.open("c:\\tools\\FW2\\download2.txt","r");
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
	if tonumber(ID) == 2 then 
		Execute("c:\\tools\\FW3\\Download3.cmd");
		local buffer = io.open("c:\\tools\\FW3\\download3.txt","r");
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
	if tonumber(ID) == 3 then 
		Execute("c:\\tools\\FW4\\Download4.cmd");
		local buffer = io.open("c:\\tools\\FW4\\download4.txt","r");
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
	if tonumber(ID) == 4 then 
		Execute("c:\\tools\\FW5\\Download5.cmd");
		local buffer = io.open("c:\\tools\\FW5\\download5.txt","r");
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
	if tonumber(ID) == 5 then 
		Execute("c:\\tools\\FW6\\Download6.cmd");
		local buffer = io.open("c:\\tools\\FW6\\download6.txt","r");
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


local FunctionTest = {
     {name="Apply_VBATT_Enable_System",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 0},
--	 {name="Apply_USBVBUS_Power_On",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="USB",volt="3.15",state=1}, skip=0,visible = 0},

	 {name="FCT001_Power_PP3V0",lower=2.7,upper=3.3,unit="V",entry=ReadVoltTest,parameter="PP3V0", skip=0},
	 {name="FCT002_Power_PP3V0_Current",lower=0,upper=400,unit="mA",entry="return current;",parameter="PP3V0", skip=0},
	 
	 {name="FCT003_Power_PP3V0_LDO",lower=2.7,upper=3.3,unit="V",entry=ReadVoltTest,parameter="PP3V0_LDO", skip=0},
	 {name="FCT004_Power_PP3V0_LDO_Current",lower=0,upper=50,unit="mA",entry="return current;",parameter="PP3V0_LDO", skip=0},

	 {name="FCT005_Power_PP3V0_VBAT_LDO",lower=2.7,upper=3.3,unit="V",entry=ReadVoltTest,parameter="PP3V0_VBAT_LDO", skip=0},
	 {name="FCT006_Power_PP3V0_VBAT_LDO_Current",lower=0,upper=10,unit="mA",entry="return current;",parameter="PP3V0_VBAT_LDO", skip=0},

	 {name="FCT007_Power_PP3V7",lower=3.33,upper=4.07,unit="V",entry=ReadVoltTest,parameter="PP3V7", skip=0},
	 {name="FCT008_Power_PP3V7_Current",lower=0,upper=400,unit="mA",entry="return current;",parameter="PP3V7", skip=0},
	 {name="Reset",lower=nil,upper=nil,unit=nil,entry=Initial,parameter=nil, skip=0,visible = 0},

	 {name="Apply_USBVBUS_Power_On",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="USB",volt="3.2",state=1}, skip=0,visible = 0},
     {name="Delay",lower=nil,upper=nil,unit=nil,entry=Delay,parameter=100,skip=0,visible=0},

	 {name="Apply_QuiescentVBATT_Enable",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="QuiescentVBATT",volt="3.3",state=1},skip=0,visible = 0},		
	 {name="Delay",lower=nil,upper=nil,unit=nil,entry=Delay,parameter=100,skip=0,visible=0},
	 {name="FCT009_USB_Charging",lower=150,upper=400,unit="mA",entry=ReadCurrentTest,parameter="USBCharging", skip=0},

	 {name="Reset",lower=nil,upper=nil,unit=nil,entry=Initial,parameter=nil, skip=0,visible = 0},
     {name="Apply_QuiescentVBATT_Enable",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="QuiescentVBATT",volt="3.7",state=1},skip=0,visible = 0},		
     {name="FCT010_Reset_Circuit_Soft",lower=6.9,upper=8.9,unit="s",entry=ResetCircuitSoft,parameter=nil,skip=0},
	 {name="FCT011_Reset_Circuit_Power",lower=50,upper=150,unit="ms",entry=ResetCircuitPower,parameter=nil,skip=0},
	 {name="FCT012_Reset_Circuit_Hard",lower=13.8,upper=17.8,unit="s",entry=ResetCircuitHard,parameter=nil,skip=0},	 
	 {name="FCT014_Soft_Latch",lower="",upper="",unit=nil,entry=SoftLatch,parameter=nil,skip=0},
	 {name="Reset",lower=nil,upper=nil,unit=nil,entry=Initial,parameter=nil, skip=0,visible = 0},
     {name="Apply_VBATT_Enable_System",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 0},
	 {name="set_motion_mode",lower="",upper="",unit=nil,entry=SetMotionMode,parameter=nil,skip=0,visible=0},
--	 {name="Delay",lower=nil,upper=nil,unit=nil,entry=Delay,parameter=1000,skip=0,visible=0},
	 {name="FCT015_I2C3_Baseline_AccelerometerX",lower=-500,upper=500,unit="",entry=MotionAccelerometerX,parameter={1,35,37,38,1,1,0,1}, skip=0},
	 {name="FCT016_I2C3_Baseline_AccelerometerY",lower=-500,upper=500,unit="",entry=MotionAccelerometerY,parameter={1,35,37,38,1,1,0,1}, skip=0},
	 {name="FCT017_I2C3_Baseline_AccelerometerZ",lower=8000,upper=8400,unit="",entry=MotionAccelerometerZ,parameter={1,35,37,38,1,1,0,1}, skip=0},	
	 {name="Apply_USBVBUS_Power_On",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="USB",volt="3.2",state=1}, skip=0,visible = 0},	 
	 {name="FCT018_I2C3_PMIC_Read",lower="",upper="",unit=nil,entry=ReadPMIC,parameter=nil, skip=0},
	 {name="Reset",lower=nil,upper=nil,unit=nil,entry=Initial,parameter=nil, skip=0,visible = 0},
     {name="Apply_VBATT_Enable_System",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="VBATT",volt="3.7",state=1},skip=0,visible = 0},
	 {name="FCT019_Programming_Bootloader_Firmware",lower="",upper="",unit=nil,entry=ProgramFirmware,parameter=nil, skip=0},
	 {name="Reset",lower=nil,upper=nil,unit=nil,entry=Initial,parameter=nil, skip=0,visible = 0},
	 {name="Delay",lower=nil,upper=nil,unit=nil,entry=Delay,parameter=1000,skip=0,visible=0},
	 {name="DutCommunicate",lower="",upper="",unit=nil,entry=CommunicateWithDut,parameter=nil, skip=0,visible = 0},
	 {name="FCT020_SP1_External_Flash",lower="",upper="",unit=nil,entry=SP1M25Flash,parameter={33,1}, skip=0},
--	 {name="FCT021_USART1_Communication",lower="",upper="",unit=nil,entry=USARTNRFFlash,parameter={49,50,51,0,1,1}, skip=0},
	 {name="FCT022_Battery_Voltage_Measurement",lower=3.33,upper=4.07,unit="V",entry=BatteryVoltage,parameter=nil, skip=0},
	 {name="FCT023_Device_ID_Read",lower="",upper="",unit=nil,entry=DeviceID,parameter=nil, skip=0},	
--	 {name="Reset",lower=nil,upper=nil,unit=nil,entry=Initial,parameter=nil, skip=0,visible = 0},	
--	 {name="Apply_VBATT_Enable_System",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="VBATT",volt="3.7",state=1}, skip=0,visible = 0},
--	 {name="Apply_USBVBUS_Power_on",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="USB",volt="3.2",state=1}, skip=0,visible = 0},
--	 {name="Apply_USBVBUS_Power_Off",lower=nil,upper=nil,unit=nil,entry=OutPutOnOff,parameter={index="USB",volt="0",state=0}, skip=0,visible = 0},
	 {name="FCT024_System_Off_Quiescent_Current",lower=25,upper=45,unit=uA,entry=ReadCurrentTest,parameter="SystemOff", skip=0},
--	 {name="FCT025_Battery_Current",lower=25,upper=45,unit=uA,entry="return BatteryCurrent;",parameter="SystemOff", skip=0},

};
local Function_Items={name="Function",entry=nil,parameter=nil,sub=FunctionTest};

items = {
	Function_Items,
};