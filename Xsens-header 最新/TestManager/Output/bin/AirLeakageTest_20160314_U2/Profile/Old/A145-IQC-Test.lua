Module="A145-FCT-Test"			--Module Name
Version="Script Version 20150930 V1.0"						--Version add write factor
Customer="Apple"					--Customer ID
StationID=""					--Station ID
LineID=""					--Line ID
FixtureID=""					--Fixture ID
DirInLogPath="FCT"

local IDTable={};

function DbgOut(fmt,...)
	DbgLog(string.format(tostring(fmt),...),ID);
end

if lock_uut == nil then 
	lock_uut = Lock;
	unlock_uut = UnLock;
end

--dummy function for platfrom test.
function __DCR_Real_ohm_Test()
	DbgOut("__DCR_Real_ohm_Test Start");
	lock_uut();--lock all the uut,just wait here!
	DbgOut("__DCR_Real_ohm_Test write");
	Delay(2000);
	unlock_uut();--unlock all the uut,all the thread can continue running.
	DbgOut("__DCR_Real_ohm_Test End");
end


function __DCR_Test(par)
	--return A34972.GetOhmData(par.id);
	DbgOut("__DCR_Test Start");
	local data={-1,99999,88.8888,99.9999,500.00,
				20.0,22.0,28.0,29.0001,32.000, --Correct.
				-1,2323,88.8888,99.9999,500.00,
				-1,99999,312,99.9999,500.00,
				-1,1111,88.8888,55,500.00,
				-1,2222,33,44,500.00
				};--Need to get the max value.
	DbgOut("__DCR_Test End");
	return data[par.id+1];
end



function __OpenShort_Pretest(par)
	DbgOut("__OpenShort_Pretest start");
	--fct.WriteString("SBIT50,51,52,53,54,55,56=1,0,0,0,0,0,1")--Initial setting
	DbgOut("fct WriteString:SBIT50,51,52,53,54,55,56=1,0,0,0,0,0,1");
	if(par=="VBUS") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,0,0");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,0,0");
	elseif(par=="VCON") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,0,0,0,0,0");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,1,0,0,0,0,0,0");
	elseif(par=="CC1") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,1,0,0,0,0");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,0,1,1,0,0,0,0");
	elseif(par=="DP1") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,0,0,0,0,0");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,0,1,0,0,0,0,0");		
	elseif(par=="DN1") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,0,1,0,0,0,0");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,0,0,1,0,0,0,0");
	elseif(par=="VBUSTOCC1") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,1,1");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,1,1");
	elseif(par=="VBUSTOVCON") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,1,0,0");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,1,0,0");
	elseif(par=="CC1TODP1") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,1,0,0,1,0");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,0,1,1,0,0,1,0");
	elseif(par=="DP1TODN1") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,0,0,0,1,1");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,0,1,0,0,0,1,1");
	elseif(par=="VBUSTODN1") then
		--fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,0,1");
		DbgOut("fct WriteString:SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,0,1");
	end
	DbgOut("__OpenShort_Pretest end");
end 

function __OpenShort_Test(par)
	DbgOut("__OpenShort_Test Start");
	lock_uut();
	__OpenShort_Pretest(par.Item)
	--fct.WriteString("SBIT57,58=1,1");
	Delay(100);
	str = nil;
	if(par.id==0) then
		--fct.WriteString(par.cmd);
		DbgOut("fct WriteString:"..tostring(par.cmd));
		--str= fct.ReadString();
		str = "0.1";
	elseif(par.id==1) then
		--fct.WriteString(par.cmd);
		--str= fct.ReadString();
		DbgOut("fct WriteString:"..tostring(par.cmd));
		str = "0.0";
	elseif(par.id==2) then
		--fct.WriteString(par.cmd);
		--return fct.ReadString();
		DbgOut("fct WriteString:"..tostring(par.cmd));
		str = "-1.0";
	elseif(par.id==3) then
		--fct.WriteString(par.cmd);
		--return fct.ReadString();
		DbgOut("fct WriteString:"..tostring(par.cmd));
		str = "99999.0";
	elseif(par.id==4) then
		--fct.WriteString(par.cmd);
		--return fct.ReadString();
		DbgOut("fct WriteString:"..tostring(par.cmd));
		str = "99999.0";
	elseif(par.id==5) then
		--fct.WriteString(par.cmd);
		--return fct.ReadString();
		DbgOut("fct WriteString:"..tostring(par.cmd));
		str = "99999.0";
	end
	--fct.WriteString("SBIT57,58=0,0");
	DbgOut("fct WriteString:SBIT57,58=0,0");
	unlock_uut();
	DbgOut("__OpenShort_Test End");
	return 	str;
end


function __Standby_Cur_Test(par)
	DbgOut("__Standby_Cur_Test start");
	str = "MEAS:CURR:DC? 10mA,1E-6,";
	--string cmd = "";
	cmd = nil;
	if(par==0) then 
	cmd = str.."(@121)";
	elseif(par==1) then
	cmd = str.."(@122)";
	elseif(par==2) then
	cmd = str.."(@221)";
	elseif(par==3) then
	cmd = str.."(@222)";
	elseif(par==4) then
	cmd = str.."(@321)";
	elseif(par==5) then
	cmd = str.."(@322)";
	end
	--return A34972.ReadCur(cmd);
	DbgOut("A34972.ReadCur:"..cmd);
	local data ={300,301,209,350,400,401,9999}; --Lex dummy return.
	DbgOut("__Standby_Cur_Test End");
	return data[par+1];
end

function __Standby_Cur_PreTest(par)
	DbgOut("__Standby_Cur_PreTest Start");
	lock_uut();
	if (par.Vol==4.75) then
		--fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,1,0,1,0,1,0,1,0,1,0,1,0");
		--DbgOut("fct.WriteString:SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,1,0,1,0,1,0,1,0,1,0,1,0");
		if(par.Item=='Vcc1') then
			if (par.id==0) then
				 --fct.WriteString("SBIT26,27,28,29=0,0,1,1");
			elseif (par.id==1)then
				 --fct.WriteString("SBIT30,31,32,33=0,0,1,1");
			elseif (par.id==2) then
				 --fct.WriteString("SBIT34,35,36,37=0,0,1,1");
			elseif (par.id==3)then
				 --fct.WriteString("SBIT38,39,40,41=0,0,1,1");
			elseif (par.id==4) then
				 --fct.WriteString("SBIT42,43,44,45=0,0,1,1");
			elseif (par.id==5)then
				 --fct.WriteString("SBIT46,47,48,49=0,0,1,1");
			end
		elseif(par.Item=='Vcon') then
			if (par.id==0) then
				 --fct.WriteString("SBIT26,27,28,29=0,1,1,0");
			elseif (par.id==1)then
				 --fct.WriteString("SBIT30,31,32,33=0,1,1,0");
			elseif (par.id==2) then
				 --fct.WriteString("SBIT34,35,36,37=0,1,1,0");
			elseif (par.id==3)then
				 --fct.WriteString("SBIT38,39,40,41=0,1,1,0");
			elseif (par.id==4) then
				 --fct.WriteString("SBIT42,43,44,45=0,1,1,0");
			elseif (par.id==5)then
				 --fct.WriteString("SBIT46,47,48,49=0,1,1,0");
				 
			end
		end
	elseif(par.Vol==5.5) then
		--fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,0,1,0,1,0,1,0,1,0,1,0,1");
		if(par.Item=='Vcc1') then
			if (par.id==0) then
				 --fct.WriteString("SBIT26,27,28,29=1,0,1,1");
			elseif (par.id==1)then
				 --fct.WriteString("SBIT30,31,32,33=1,0,1,1");
			elseif (par.id==2) then
				 --fct.WriteString("SBIT34,35,36,37=1,0,1,1");
			elseif (par.id==3)then
				 --fct.WriteString("SBIT38,39,40,41=1,0,1,1");
			elseif (par.id==4) then
				 --fct.WriteString("SBIT42,43,44,45=1,0,1,1");
			elseif (par.id==5)then
				 --fct.WriteString("SBIT46,47,48,49=1,0,1,1");
			end
		elseif(par.Item=='Vcon') then
			if (par.id==0) then
				 --fct.WriteString("SBIT26,27,28,29=1,1,1,0");
			elseif (par.id==1)then
				 --fct.WriteString("SBIT30,31,32,33=1,1,1,0");
			elseif (par.id==2) then
				 --fct.WriteString("SBIT34,35,36,37=1,1,1,0");
			elseif (par.id==3)then
				 --fct.WriteString("SBIT38,39,40,41=1,1,1,0");
			elseif (par.id==4) then
				 --fct.WriteString("SBIT42,43,44,45=1,1,1,0");
			elseif (par.id==5)then
				 --fct.WriteString("SBIT46,47,48,49=1,1,1,0");
			end
		end
	end	
	ret = __Standby_Cur_Test(par.id);
	unlock_uut();
	DbgOut("__Standby_Cur_PreTest End");
	return ret;
end
	
	
function __DisconverID_Test_Pre(par)
	DbgOut("__DisconverID_Test_Pre Start");
	lock_uut();
	--[[
	if (par.id==0) then
		fct.WriteString("SBIT16,17,18,19,20,21=1,0,0,0,0,0");
	elseif (par.id==1)then
		fct.WriteString("SBIT16,17,18,19,20,21=0,1,0,0,0,0");
	elseif (par.id==2) then
		fct.WriteString("SBIT16,17,18,19,20,21=0,0,1,0,0,0");
	elseif (par.id==3)then
		fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,1,0,0");
	elseif (par.id==4) then
		fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,1,0");
	elseif (par.id==5)then
		fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,0,1");
	end	
	--]]
	Delay(500);
	local data={"0xff008041","0x1c0004b4","00000000","0xf6810000"};
	IDTable[ID]= data;--CYPress.getID();
	unlock_uut();
	DbgOut("__DisconverID_Test_Pre End");
end

function __DisconverID_Test(par)
	return IDTable[par.index];
end

function __IDRead_VolSet(par)
	lock_uut();
	DbgOut("__IDRead_VolSet Start");
	--[[if (par.Vol==4.75) then
		fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,1,0,1,0,1,0,1,0,1,0,1,0");
	elseif(par.Vol==5.5) then
		fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,0,1,0,1,0,1,0,1,0,1,0,1");
	end
	if (par.id==0) then
			 fct.WriteString("SBIT26,27,28,29=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=1,0,0,0,0,0");
	elseif (par.id==1)then
			 fct.WriteString("SBIT30,31,32,33=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,1,0,0,0,0");
	elseif (par.id==2) then
			 fct.WriteString("SBIT34,35,36,37=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,1,0,0,0");
	elseif (par.id==3)then
			 fct.WriteString("SBIT38,39,40,41=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,1,0,0");
	elseif (par.id==4) then
			 fct.WriteString("SBIT42,43,44,45=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,1,0");
	elseif (par.id==5)then
			 fct.WriteString("SBIT46,47,48,49=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,0,1");
	end
	--]]
	Delay(500);
	local data={"0xff008041","0xff008040","0xff008041","0xff008041","0xff008041","0xff008041"};
	IDTable[par.id]= data[par.id+1];--CYPress.getID();
	unlock_uut();
	DbgOut("__IDRead_VolSet End");	
end	
--end of dummy function.

function Test_OnEntry(par)		--Initial function for startup test,you can add test initial code in here
	
end

function Test_OnAbort(par)
	--A34972.ResetOhmExecuted();
end

function Test_OnFail(par)		--Clear function for test failed,you can add clear function code in here when test failed.
	fixture.FixtureUp();
end

function Test_OnDone(par)		--Clear function for normal test finish.you can add clear function code in there when test normally finish.
	--A34972.ResetOhmExecuted();
	fixture.FixtureUp();
end


function DCR_Real_ohm_Test(par)
	lock_uut();--lock all the uut,just wait here!
	if(A34972.checkOhmExecuted()==false) then		
		A34972.setOhmExecuted();	
		A34972.storyOhmData(par.cmd,2000);
	end
	unlock_uut();--unlock all the uut,all the thread can continue running.
end

function DCR_Test(par)
	return A34972.GetOhmData(par.id);
end



function OpenShort_Pretest(par)
	
	fct.WriteString("SBIT50,51,52,53,54,55,56=1,0,0,0,0,0,1")--Initial setting
	if(par=="VBUS") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,0,0");
	elseif(par=="VCON") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,0,0,0,0,0");
	elseif(par=="CC1") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,1,0,0,0,0");
	elseif(par=="DP1") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,0,0,0,0,0");	
	elseif(par=="DN1") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,0,1,0,0,0,0");
	elseif(par=="VBUSTOCC1") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,1,1");
	elseif(par=="VBUSTOVCON") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,1,0,0");
	elseif(par=="CC1TODP1") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,1,0,0,1,0");
	elseif(par=="DP1TODN1") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,0,1,0,0,0,1,1");
	elseif(par=="VBUSTODN1") then
		fct.WriteString("SBIT59,60,61,62,63,64,65,66=0,1,0,1,0,0,0,1");
	end
	--fct.WriteString("SBIT57,58=1,1");
end 

function OpenShort_Test(par)
	lock_uut();
	OpenShort_Pretest(par.Item)
	fct.WriteString("SBIT57,58=1,1");
	Delay(100);
	if(par.id==0) then
		fct.WriteString(par.cmd);
		return fct.ReadString();
	elseif(par.id==1) then
		fct.WriteString(par.cmd);
		return fct.ReadString();
	elseif(par.id==2) then
		fct.WriteString(par.cmd);
		return fct.ReadString();
	elseif(par.id==3) then
		fct.WriteString(par.cmd);
		return fct.ReadString();
	elseif(par.id==4) then
		fct.WriteString(par.cmd);
		return fct.ReadString();
	elseif(par.id==5) then
		fct.WriteString(par.cmd);
		return fct.ReadString();
	end
	fct.WriteString("SBIT57,58=0,0");
	unlock_uut();
end


function Standby_Cur_Test(par)
	 str = "MEAS:CURR:DC? 10mA,1E-6,";
	--string cmd = "";
	if(par==0) then 
	cmd = str.."(@121)";
	elseif(par==1) then
	cmd = str.."(@122)";
	elseif(par==2) then
	cmd = str.."(@221)";
	elseif(par==3) then
	cmd = str.."(@222)";
	elseif(par==4) then
	cmd = str.."(@321)";
	elseif(par==5) then
	cmd = str.."(@322)";
	end
	return A34972.ReadCur(cmd);
end
function Standby_Cur_PreTest(par)
	lock_uut();
	if (par.Vol==4.75) then
		fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,1,0,1,0,1,0,1,0,1,0,1,0");
		if(par.Item==Vcc1) then
			if (par.id==0) then
				 fct.WriteString("SBIT26,27,28,29=0,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==1)then
				 fct.WriteString("SBIT30,31,32,33=0,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==2) then
				 fct.WriteString("SBIT34,35,36,37=0,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==3)then
				 fct.WriteString("SBIT38,39,40,41=0,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==4) then
				 fct.WriteString("SBIT42,43,44,45=0,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==5)then
				 fct.WriteString("SBIT46,47,48,49=0,0,1,1");
				 return Standby_Cur_Test(par.id);
			end
		elseif(par.Item==Vcon) then
			if (par.id==0) then
				 fct.WriteString("SBIT26,27,28,29=0,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==1)then
				 fct.WriteString("SBIT30,31,32,33=0,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==2) then
				 fct.WriteString("SBIT34,35,36,37=0,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==3)then
				 fct.WriteString("SBIT38,39,40,41=0,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==4) then
				 fct.WriteString("SBIT42,43,44,45=0,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==5)then
				 fct.WriteString("SBIT46,47,48,49=0,1,1,0");
				 return Standby_Cur_Test(par.id);
			end
		end
	elseif(par.Vol==5.5) then
		fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,0,1,0,1,0,1,0,1,0,1,0,1");
		if(par.Item==Vcc1) then
			if (par.id==0) then
				 fct.WriteString("SBIT26,27,28,29=1,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==1)then
				 fct.WriteString("SBIT30,31,32,33=1,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==2) then
				 fct.WriteString("SBIT34,35,36,37=1,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==3)then
				 fct.WriteString("SBIT38,39,40,41=1,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==4) then
				 fct.WriteString("SBIT42,43,44,45=1,0,1,1");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==5)then
				 fct.WriteString("SBIT46,47,48,49=1,0,1,1");
				 return Standby_Cur_Test(par.id);
			end
		elseif(par.Item==Vcon) then
			if (par.id==0) then
				 fct.WriteString("SBIT26,27,28,29=1,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==1)then
				 fct.WriteString("SBIT30,31,32,33=1,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==2) then
				 fct.WriteString("SBIT34,35,36,37=1,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==3)then
				 fct.WriteString("SBIT38,39,40,41=1,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==4) then
				 fct.WriteString("SBIT42,43,44,45=1,1,1,0");
				 return Standby_Cur_Test(par.id);
			elseif (par.id==5)then
				 fct.WriteString("SBIT46,47,48,49=1,1,1,0");
				 return Standby_Cur_Test(par.id);
			end
		end
	end	
	unlock_uut();
end
	
	
function DisconverID_Test_Pre(par)
	lock_uut();
		if (par.id==0) then
			fct.WriteString("SBIT16,17,18,19,20,21=1,0,0,0,0,0");
		elseif (par.id==1)then
			fct.WriteString("SBIT16,17,18,19,20,21=0,1,0,0,0,0");
		elseif (par.id==2) then
			fct.WriteString("SBIT16,17,18,19,20,21=0,0,1,0,0,0");
		elseif (par.id==3)then
			fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,1,0,0");
		elseif (par.id==4) then
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,1,0");
		elseif (par.id==5)then
			fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,0,1");
		end	
		Delay(500);
		IDTable[ID]=CYPress.getID();
	unlock_uut();
end

function DisconverID_Test(par)
	return IDTable[par.id][par.index];
end

function IDRead_VolSet(par)
	lock_uut();
	if (par.Vol==4.75) then
		fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,1,0,1,0,1,0,1,0,1,0,1,0");
	elseif(par.Vol==5.5) then
		fct.WriteString("SBIT1,2,3,4,5,6,7,8,9,22,23,24,25=1,0,1,0,1,0,1,0,1,0,1,0,1");
	end
	if (par.id==0) then
			 fct.WriteString("SBIT26,27,28,29=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=1,0,0,0,0,0");
	elseif (par.id==1)then
			 fct.WriteString("SBIT30,31,32,33=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,1,0,0,0,0");
	elseif (par.id==2) then
			 fct.WriteString("SBIT34,35,36,37=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,1,0,0,0");
	elseif (par.id==3)then
			 fct.WriteString("SBIT38,39,40,41=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,1,0,0");
	elseif (par.id==4) then
			 fct.WriteString("SBIT42,43,44,45=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,1,0");
	elseif (par.id==5)then
			 fct.WriteString("SBIT46,47,48,49=0,1,1,1");
			 fct.WriteString("SBIT16,17,18,19,20,21=0,0,0,0,0,1");
	end
	Delay(500);
	IDTable[par.id]=CYPress.getID();
	unlock_uut();	
end	
	
local DCR_Item_Sub={
	{name="Real Ohm Test",lower=nil,upper=nil,unit=mOhm,entry=__DCR_Real_ohm_Test,parameter={cmd="MEAS:FRES? 100,DEF,(@101:110,201:210,301:310)"},visible=0},
	{name="PP_USBC_VBUS",lower=18,upper=25,unit=mOhm,entry=__DCR_Test,parameter={id=ID*5+0},visible=1},
	{name="TP0304",lower=19,upper=27,unit=mOhm,entry=__DCR_Test,parameter={id=ID*5+1},visible=1},
	{name="USBC_CC1",lower=25,upper=33,unit=mOhm,entry=__DCR_Test,parameter={id=ID*5+2},visible=1},
	{name="USB_DP1",lower=24,upper=32,unit=mOhm,entry=__DCR_Test,parameter={id=ID*5+3},visible=1},
	{name="USB_DN1",lower=28,upper=36,unit=mOhm,entry=__DCR_Test,parameter={id=ID*5+4},visible=1},
};


local Standby_Item_Sub={
	{name="Current CC1_4.75V",lower=300,upper=400,unit=mA,entry=__Standby_Cur_PreTest,parameter={Vol=4.75,Item="Vcc1",id=ID},visible=1},
	{name="Current Vconn_4.75V",lower=300,upper=400,unit=mA,entry=__Standby_Cur_PreTest,parameter={Vol=4.75,Item="Vcon",id=ID},visible=1},
	{name="Current CC1_5.5V",lower=300,upper=400,unit=mA,entry=__Standby_Cur_PreTest,parameter={Vol=5.5,Item="Vcc1",id=ID},visible=1},
	{name="Current Vconn_5.5V",lower=300,upper=400,unit=mA,entry=__Standby_Cur_PreTest,parameter={Vol=5.5,Item="Vcon",id=ID},visible=1},
};


local OpenShort_Item_Sub={
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"VBUS"},visible=0},	
	{name="PP_USBC_VBUS to GND",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="VBUS",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"VCON"},visible=0},
	{name="PP_USBC_VCONN to GND",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="VCON",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"CC1"},visible=0},
	{name="USBC_CC1 to GND",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="CC1",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"DP1"},visible=0},
	{name="USB_DP1 to GND",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="DP1",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"DN1"},visible=0},
	{name="USB_DN1 to GND",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="DN1",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"VBUSTOCC1"},visible=0},
	{name="PP_USBC_VBUS to USBC_CC1",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="VBUSTOCC1",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"VBUSTOVCON"},visible=0},
	{name="PP_USBC_VBUS to PP_USBC_VCONN",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="VBUSTOVCON",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"CC1TODP1"},visible=0},
	{name="USBC_CC1 to USB_DP1",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="CC1TODP1",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"DP1TODN1"},visible=0},
	{name="USB_DP1 to USB_DN1",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="DP1TODN1",id=ID},visible=1},
	{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Pretest,parameter={"VBUSTODN1"},visible=0},
	{name="PP_USBC_VBUS to USB_DN1",lower=nil,upper=nil,unit=nil,entry=__OpenShort_Test,parameter={Item="VBUSTODN1",id=ID},visible=1},
};

local DisconverID_Item_Sub={
	{name="VoltageSet",lower=nil,upper=nil,unit=nil,entry=__IDRead_VolSet,parameter={id=ID,Vol=4.75},visible=0,stopfail=1},--Lex check if the uut is stop when end.
	{name="Read Buf[0] 4.75V",lower="0xff008041",upper="0xff008041",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=0},visible=1},
	{name="Read Buf[1] 4.75V",lower="0x1c0004b4",upper="0x1c0004b4",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=1},visible=1},
	{name="Read Buf[2] 4.75V",lower="00000000",upper="00000000",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=2},visible=1},
	{name="Read Buf[3] 4.75V",lower="0xf6810000",upper="0xf6810000",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=3},visible=1},
	{name="Read Buf[4] 4.75V",lower="0x082fb2",upper="0x082fb2",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=4},visible=1},
	{name="VoltageSet",lower=nil,upper=nil,unit=nil,entry=__DisconverID_Test_Pre,parameter={Vol=5.5,id=ID},visible=0},
	{name="Read Buf[0] 5.5V",lower="0xff008041",upper="0xff008041",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=0},visible=1},
	{name="Read Buf[1] 5.5V",lower="0x1c0004b4",upper="0x1c0004b4",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=1},visible=1},
	{name="Read Buf[2] 5.5V",lower="00000000",upper="00000000",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=2},visible=1},
	{name="Read Buf[3] 5.5V",lower="0xf6810000",upper="0xf6810000",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=3},visible=1},
	{name="Read Buf[4] 5.5V",lower="0x082fb2",upper="0x082fb2",unit=nil,entry=__DisconverID_Test,parameter={id=ID,index=4},visible=1},
};

local DCR_Item={name="DCR_Item",entry=nil,parameter=nil,sub=DCR_Item_Sub};

local Standby_Item={name="Standby_Item",entry=nil,parameter=nil,sub=Standby_Item_Sub};

local OpenShort_Item={name="OpenShort_Item",entry=nil,parameter=nil,sub=OpenShort_Item_Sub};

local DisconverID_Item={name="DisconverID_Item",entry=nil,parameter=nil,sub=DisconverID_Item_Sub};

items = {
   DCR_Item,---ok
   Standby_Item,
   OpenShort_Item,
   --DisconverID_Item,--ok
}