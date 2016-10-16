Module="A145-FCT"			--Module Name
Version="Script Version 20150918 V1.0"						--Version add write factor
Customer="Apple"					--Customer ID
StationID=""					--Station ID
LineID=""					--Line ID
FixtureID=""					--Fixture ID
DirInLogPath="FCT"


local IDTable={};
local SF=1;

function Test_OnEntry(par)		--Initial function for startup test,you can add test initial code in here
	A34972.ResetOhmExecuted();
	--fct.WriteString("reset");
end

function Test_OnAbort(par)
	--A34972.ResetOhmExecuted();
	--fct.closePort();
	fixture.FixtureUp();
	
end

function Test_OnFail(par)		--Clear function for test failed,you can add clear function code in here when test failed.
	--A34972.ResetOhmExecuted();
	--fct.closePort();
	fixture.FixtureUp();
end

function Test_OnDone(par)		--Clear function for normal test finish.you can add clear function code in there when test normally finish.
	--A34972.ResetOhmExecuted();
	fixture.FixtureUp();
	--fct.closePort();
	
end
function MES_CHECK(par)
	if(par.id==1 or par.id==3 or par.id==5) then
	--SF=1;
	return 0;
	else
	return 1;
	end
end

function DCR_Real_ohm_Test(par)
	Lock();--lock all the uut,just wait here!
	if(A34972.checkOhmExecuted()==false) then		
		A34972.setOhmExecuted();	
		DbgOut(tostring(A34972.checkOhmExecuted()),ID);
		A34972.storyOhmData(par.cmd,3000);
	end
	UnLock();--unlock all the uut,all the thread can continue running.
end

function DCR_Test(par)
	local ret=nil;
	ret=A34972.GetOhmData(par.id)*1000;
	DbgOut(ret,ID);
	return ret;
end



function OpenShort_Pretest(par)
	
	--fct.WriteString("SBIT50,51,52,53,54,55,56=0,0,1,0,0,0,1\r\n")--Initial setting
	--fct.WriteString("SBIT055,056=0,0\r\n");---2W OR 4W SELECT
	--Delay(100);
	fct.WriteString("SBIT050,051,052=0,0,1\r\n");
	Delay(200);
	--fct.WriteString("SBIT053,054=0,0\r\n");
	Delay(100);
	if(par=="VBUS") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,0,1,0,0,1,1,1\r\n");
	elseif(par=="VCON") then
		fct.WriteString("SBIT050,051,052=0,1,0\r\n");
		Delay(200);
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,0,1,1,0,1,1,1\r\n");
	elseif(par=="CC1") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,1,0,0,0,1,1,1\r\n");
	elseif(par=="DP1") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,1,0,1,0,1,1,1\r\n");	
	elseif(par=="DN1") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,1,1,0,0,1,1,1\r\n");
	elseif(par=="VBUSTOCC1") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,0,1,0,0,1,0,0\r\n");
	elseif(par=="VBUSTOVCON") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,0,1,0,0,0,1,1\r\n");
	elseif(par=="CC1TODP1") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,1,0,0,0,1,0,1\r\n");
	elseif(par=="DP1TODN1") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,1,0,1,0,1,1,0\r\n");
	elseif(par=="VBUSTODN1") then
		fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,0,1,0,0,1,1,0\r\n");
	end
	Delay(500);
	--fct.WriteString("SBIT57,58=1,1");
end 

function OpenShort(par)
	local ret,ret1,ret2,ret3,ret4;
	
	ret1 = fct.ReadString();
	
	if(ret1 ~= nil)then
		ret2 = string.match(ret1,"[+-]? %d+");
		if(ret2~=nil) then
			ret3 = string.gsub(ret2," ","");
		else 
			return 0;
		end
		--ret3="1100";
		if(ret3 ~= nil) then
			ret4= tonumber(ret3);
			if(par=="VCON") then
			ret=(ret4/(100000-ret4))*2000000;
			else
			ret=(ret4/(1000-ret4))*2000000;
			end
		end
		return ret;
			
		
	else 
		return 0;
	end
	
end

function OpenShort_Test(par)
	local ret,ret1,ret2;
	Lock();
	ret1=OpenShort_Pretest(par.Item);
	fct.WriteString("SBIT057,058=1,1\r\n");
	--local ret;
	Delay(1000);
	if(par.id==0) then
		fct.WriteString("MADD01R05\r\n");
		--ret=OpenShort();
	elseif(par.id==1) then
		fct.WriteString("MADD02R05\r\n");
		--ret=OpenShort();
	elseif(par.id==2) then
		fct.WriteString("MADD03R05\r\n");
		--ret=OpenShort();
	elseif(par.id==3) then
		fct.WriteString("MADD04R05\r\n");
		--ret=OpenShort();
	elseif(par.id==4) then
		fct.WriteString("MADD05R05\r\n");
		--ret=OpenShort();
	elseif(par.id==5) then
		fct.WriteString("MADD06R05\r\n");
		--ret=OpenShort();
	end
	Delay(2000);
	ret=OpenShort(par.Item);
	fct.WriteString("SBIT057,058=0,0\r\n");
	Delay(300);
	fct.WriteString("SBIT050,051,052=0,0,0\r\n");
	Delay(300);
	fct.WriteString("SBIT062,061,060,059,066,065,064,063=0,0,0,0,0,0,0,0\r\n");
	Delay(500);
	UnLock();
	return ret;
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
	Delay(300);
	return A34972.ReadCur(cmd)*1000000;
end
function Standby_Cur_PreTest(par)
	Lock();
	local ret,ret1,ret2,ret3,ret4,ret5= nil,nil,nil,nil,nil,nil;
	
	fct.WriteString("SBIT001=1\r\n");
	Delay(500);
	if (par.Vol==4.75) then
		fct.WriteString("SBIT002,003,004,005,006,007,008,009,022,023,024,025=0,1,0,1,0,1,0,1,0,1,0,1\r\n");
		Delay(500);
		if(par.Item=="Vcc1") then
			fct.WriteString("SBIT026,027,028,029,030,031,032,033,034,035,036,037=0,0,1,1,0,0,1,1,0,0,1,1\r\n");
			Delay(500);
			fct.WriteString("SBIT038,039,040,041,042,043,044,045,046,047,048,049=0,0,1,1,0,0,1,1,0,0,1,1\r\n");
		elseif(par.Item=="Vcon") then
			--fct.WriteString("SBIT026,027,028,029,030,031,032,033,034,035,036,037,038,039,040,041,042,043,044,045,046,047,048,049=0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0\r\n");
			fct.WriteString("SBIT026,027,028,029,030,031,032,033,034,035,036,037=0,1,1,0,0,1,1,0,0,1,1,0\r\n");
			Delay(500);
			fct.WriteString("SBIT038,039,040,041,042,043,044,045,046,047,048,049=0,1,1,0,0,1,1,0,0,1,1,0\r\n");
		end
	elseif(par.Vol==5.5) then
		fct.WriteString("SBIT002,003,004,005,006,007,008,009,022,023,024,025=1,0,1,0,1,0,1,0,1,0,1,0\r\n");
		Delay(500);
		if(par.Item=="Vcc1") then
			--fct.WriteString("SSBIT026,027,028,029,030,031,032,033,034,035,036,037,038,039,040,041,042,043,044,045,046,047,048,049=1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1\r\n");
			fct.WriteString("SBIT026,027,028,029,030,031,032,033,034,035,036,037=1,0,1,1,1,0,1,1,1,0,1,1\r\n");
			Delay(500);
			fct.WriteString("SBIT038,039,040,041,042,043,044,045,046,047,048,049=1,0,1,1,1,0,1,1,1,0,1,1\r\n");
		elseif(par.Item=="Vcon") then
			--fct.WriteString("SBIT026,027,028,029,030,031,032,033,034,035,036,037,038,039,040,041,042,043,044,045,046,047,048,049=1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1,0\r\n");
			fct.WriteString("SBIT026,027,028,029,030,031,032,033,034,035,036,037=1,1,1,0,1,1,1,0,1,1,1,0\r\n");
			Delay(500);
			fct.WriteString("SBIT038,039,040,041,042,043,044,045,046,047,048,049=1,1,1,0,1,1,1,0,1,1,1,0\r\n");
		end
	end	
	Delay(1000);
	ret= Standby_Cur_Test(par.id);
	-- local resultTable={};
	-- for i=1,10,1 do
	  -- ret= Standby_Cur_Test(par.id);
	  -- table.insert(resultTable,ret);
	-- end
	-- ret=Calculate_Average(resultTable);
	
	fct.WriteString("SBIT001=0\r\n");
	Delay(500);
	fct.WriteString("SBIT002,003,004,005,006,007,008,009,022,023,024,025=1,1,1,1,1,1,1,1,1,1,1,1\r\n");
	Delay(500);
	fct.WriteString("SBIT026,027,028,029,030,031,032,033,034,035,036,037=0,0,0,0,0,0,0,0,0,0,0,0,0\r\n");
	Delay(500);
	fct.WriteString("SBIT038,039,040,041,042,043,044,045,046,047,048,049=0,0,0,0,0,0,0,0,0,0,0,0,0\r\n");
	Delay(500);
	UnLock();
	return ret;
end
	
	
	
function DisconverID_Test_Pre(par)
	Lock();
		if (par.id==0) then
			fct.WriteString("SBIT016,017,018,019,020,021=1,0,0,0,0,0\r\n");
		elseif (par.id==1)then
			fct.WriteString("SBIT016,017,018,019,020,021=0,1,0,0,0,0\r\n");
		elseif (par.id==2) then
			fct.WriteString("SBIT016,017,018,019,020,021=0,0,1,0,0,0\r\n");
		elseif (par.id==3)then
			fct.WriteString("SBIT016,017,018,019,020,021=0,0,0,1,0,0\r\n");
		elseif (par.id==4) then
			 fct.WriteString("SBIT016,017,018,019,020,021=0,0,0,0,1,0\r\n");
		elseif (par.id==5)then
			fct.WriteString("SBIT016,017,018,019,020,021=0,0,0,0,0,1\r\n");
		end	
		Delay(2000);
		IDTable[ID]=CYPress.getID();
	UnLock();
end

function Calculate_Average(Get_Table)
    if(Get_Table[1]==nil) then
	Get_Table={0};
	end
	local max=Get_Table[1];
	local min=Get_Table[1];
	local sum=0;
	local count=0;
	for a,b in ipairs(Get_Table) do
	  count=a;
	  sum=sum+b;
	  if(b>min) then
	    if(b>max) then
		max=b;
		end
	  else
	    if(b<min) then
		min=b;
		end
	  end
	end
	local average=(sum-max-min)/(count-2);
	return tonumber(average);
end

function DisconverID_Test(par)
	return IDTable[par.id][par.index];
end

function IDRead_VolSet(par)
	Lock();
	if (par.Vol==4.75) then
		fct.WriteString("SBIT002,003,004,005,006,007,008,009,022,023,024,025=0,1,0,1,0,1,0,1,0,1,0,1\r\n");
	elseif(par.Vol==5.5) then
		fct.WriteString("SBIT002,003,004,005,006,007,008,009,022,023,024,025=1,0,1,0,1,0,1,0,1,0,1,0\r\n");
	end
	Delay(100);
	if (par.id==0) then
			 fct.WriteString("SBIT026,027,028,029=0,1,1,1\r\n");
			 Delay(100);
			 fct.WriteString("SBIT016,017,018,019,020,021=1,0,0,0,0,0\r\n");
	elseif (par.id==1)then
			 fct.WriteString("SBIT030,031,032,033=0,1,1,1\r\n");
			 Delay(100);
			 fct.WriteString("SBIT016,017,018,019,020,021=0,1,0,0,0,0\r\n");
	elseif (par.id==2) then
			 fct.WriteString("SBIT034,035,036,037=0,1,1,1\r\n");
			 Delay(100);
			 fct.WriteString("SBIT016,017,018,019,020,021=0,0,1,0,0,0\r\n");
	elseif (par.id==3)then
			 fct.WriteString("SBIT038,039,040,041=0,1,1,1\r\n");
			 Delay(100);
			 fct.WriteString("SBIT016,017,018,019,020,021=0,0,0,1,0,0\r\n");
	elseif (par.id==4) then
			 fct.WriteString("SBIT042,043,044,045=0,1,1,1\r\n");
			 Delay(100);
			 fct.WriteString("SBIT016,017,018,019,020,021=0,0,0,0,1,0\r\n");
	elseif (par.id==5)then
			 fct.WriteString("SBIT046,047,048,049=0,1,1,1\r\n");
			 Delay(100);
			 fct.WriteString("SBIT016,017,018,019,020,021=0,0,0,0,0,1\r\n");
	end
	Delay(1000);
	IDTable[par.id]=CYPress.getID();
	UnLock();	
end	
local MESCHECK_Sub={
	{name="MES_CHECK",lower=1,upper=nil,unit="mOhm",entry=MES_CHECK,parameter={id=ID},visible=1,stopfail=1}
};
local DCR_Item_Sub={
	{name="Real Ohm Test",lower=nil,upper=nil,unit="mOhm",entry=DCR_Real_ohm_Test,parameter={cmd="MEAS:FRES? 100,DEF,(@101:110,201:210,301:310)"},visible=0},
	{name="PP_USBC_VBUS",lower=20,upper=50,unit="mOhm",entry=DCR_Test,parameter={id=ID*5+0},visible=1},
	{name="TP0304",lower=4,upper=16,unit="mOhm",entry=DCR_Test,parameter={id=ID*5+1},visible=1},
	{name="USBC_CC1",lower=45,upper=75,unit="mOhm",entry=DCR_Test,parameter={id=ID*5+2},visible=1},
	{name="USB_DP1",lower=50,upper=80,unit="mOhm",entry=DCR_Test,parameter={id=ID*5+3},visible=1},
	{name="USB_DN1",lower=25,upper=55,unit="mOhm",entry=DCR_Test,parameter={id=ID*5+4},visible=1},
};


local Standby_Item_Sub={
	--{name="Standby_Cur_PreTest",lower=nil,upper=nil,unit=nil,entry=Standby_Cur_PreTest,parameter={Vol=4.75,Item=Vcc1,id=ID},visible=0},
	{name="Current CC1_4.75V",lower=-5,upper=40,unit="uA",entry=Standby_Cur_PreTest,parameter={Vol=4.75,Item="Vcc1",id=ID},visible=1},
	--{name="Standby_Cur_PreTest",lower=nil,upper=nil,unit=nil,entry=Standby_Cur_PreTest,parameter={Vol=4.75,Item=Vcon,id=ID},visible=0},
	{name="Current Vconn_4.75V",lower=200,upper=500,unit="uA",entry=Standby_Cur_PreTest,parameter={Vol=4.75,Item="Vcon",id=ID},visible=1},
	--{name="Standby_Cur_PreTest",lower=nil,upper=nil,unit=nil,entry=Standby_Cur_PreTest,parameter={Vol=5.5,Item=Vcc1,id=ID},visible=0},
	{name="Current CC1_5.5V",lower=-5,upper=40,unit="uA",entry=Standby_Cur_PreTest,parameter={Vol=5.5,Item="Vcc1",id=ID},visible=1},
	--{name="Standby_Cur_PreTest",lower=nil,upper=nil,unit=nil,entry=Standby_Cur_PreTest,parameter={Vol=5.5,Item=Vcon,id=ID},visible=0},
	{name="Current Vconn_5.5V",lower=200,upper=500,unit="uA",entry=Standby_Cur_PreTest,parameter={Vol=5.5,Item="Vcon",id=ID},visible=1},
};


local OpenShort_Item_Sub={
	{name="USB_DP1 to GND",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="DP1",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"DN1"},visible=0},
	{name="USB_DN1 to GND",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="DN1",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"VBUS"},visible=0},	
	{name="USBC_VBUS to GND",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="VBUS",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"VCON"},visible=0},
	{name="USBC_VCONN to GND",lower=500,upper=1500,unit="Ohm",entry=OpenShort_Test,parameter={Item="VCON",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"CC1"},visible=0},
	{name="USBC_CC1 to GND",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="CC1",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"DP1"},visible=0},
	
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"VBUSTOCC1"},visible=0},
	{name="USBC_VBUS to USBC_CC1",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="VBUSTOCC1",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"VBUSTOVCON"},visible=0},
	{name="USBC_VBUS to USBC_VCONN",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="VBUSTOVCON",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"CC1TODP1"},visible=0},
	{name="USBC_CC1 to USB_DP1",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="CC1TODP1",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"DP1TODN1"},visible=0},
	{name="USB_DP1 to USB_DN1",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="DP1TODN1",id=ID},visible=1},
	--{name="OpenShort_Pretest",lower=nil,upper=nil,unit=nil,entry=OpenShort_Pretest,parameter={"VBUSTODN1"},visible=0},
	{name="USBC_VBUS to USB_DN1",lower=100000,upper=10000000,unit="Ohm",entry=OpenShort_Test,parameter={Item="VBUSTODN1",id=ID},visible=1},
};

local DisconverID_Item_Sub={
	{name="VoltageSet",lower=nil,upper=nil,unit=nil,entry=IDRead_VolSet,parameter={id=ID,Vol=4.75},visible=0},
	{name="Read Buf[0] 4.75V",lower="0xff008041",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=0},visible=1},
	{name="Read Buf[1] 4.75V",lower="0x1c0004b4",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=1},visible=1},
	{name="Read Buf[2] 4.75V",lower="00000000",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=2},visible=1},
	{name="Read Buf[3] 4.75V",lower="0xf6810000",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=3},visible=1},
	{name="Read Buf[4] 4.75V",lower="0x082fb2",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=4},visible=1},
	{name="VoltageSet",lower=nil,upper=nil,unit=nil,entry=DisconverID_Test_Pre,parameter={Vol=5.5,id=ID},visible=0},
	{name="Read Buf[0] 5.5V",lower="0xff008041",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=0},visible=1},
	{name="Read Buf[1] 5.5V",lower="0x1c0004b4",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=1},visible=1},
	{name="Read Buf[2] 5.5V",lower="00000000",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=2},visible=1},
	{name="Read Buf[3] 5.5V",lower="0xf6810000",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=3},visible=1},
	{name="Read Buf[4] 5.5V",lower="0x082fb2",upper="",unit=nil,entry=DisconverID_Test,parameter={id=ID,index=4},visible=1},
};
local MES_CHECK_Item={name="MES_CHECK_Item",entry=nil,parameter=nil,sub=MESCHECK_Sub};

local DCR_Item={name="DCR_Item",entry=nil,parameter=nil,sub=DCR_Item_Sub};

local Standby_Item={name="Standby_Item",entry=nil,parameter=nil,sub=Standby_Item_Sub};

local OpenShort_Item={name="OpenShort_Item",entry=nil,parameter=nil,sub=OpenShort_Item_Sub};

local DisconverID_Item={name="DisconverID_Item",entry=nil,parameter=nil,sub=DisconverID_Item_Sub};

items = 
{
	MES_CHECK_Item,
   --OpenShort_Item,
   DCR_Item,---ok
   
   --Standby_Item,--ok
   
   --DisconverID_Item,--ok
}