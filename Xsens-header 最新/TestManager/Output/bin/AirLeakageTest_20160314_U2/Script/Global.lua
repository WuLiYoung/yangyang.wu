--≈‰÷√À—À˜¬∑æ∂
--package.path = package.path..";".."/Users/ryan/Project/XCode/iTMP/iTMP/script/?.lua"
local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;


LED_NUM = 17;
Pulsar_SIZE = 2;

declimer ="\r\n";
stoptest = false;

--[[
#define kContextStationName     @"StationName"
#define kContextLineName        @"LineName"
#define kContextVaultPath       @"VaultPath"
#define kContextCsvPath         @"CsvLogPath"
#define kContextUartPath        @"UartLogPath"
#define kContextTestFlow        @"TestFlowPath"
#define kContextPdcaServer      @"PDCA_Server"
#define kContextSfcServer       @"SFC_server"


#define kContextID              @"uid"
#define kContextUsbLocation     @"USBlocation"
#define kContextMLBSN           @"MLB_SN"
#define kContextCFG             @"CFG"
#define kContextStartTime       @"StartTime"
#define kContextTotalTime       @"TotalTime"
#define kContextEnableTest      @"IsEnableTest"

#define kConfigScanBarcode              @"scan_barcode?"
#define kConfigScanCFG                  @"Scan_Cfg?"
#define kConfigPuddingPDCA              @"Pudding_PDCA?"
#define kConfigTriggerType              @"Trigger_Type"
#define kConfigProfilePath              @"profile_path"
#define kConfigFailCount                @"approve_fail_count"  //-1:continue test,0:stop if fail,N:stop if fail count==N
]]


--station information

function M.StationName()
    return TestContext:getContext("StationName",2);
end



function M.StationID()

    return TestContext:getContext("DEVID",2);
end

function M.LineName()
    return TestContext:getContext("LineName",1);
end

function M.VaultPath()
    return TestContext:getContext("VaultPath",1);
end

function M.CsvLogPath()
    return TestContext:getContext("CsvLogPath",1);
end

function M.UartLogPath()
    return TestContext:getContext("UartLogPath",1);
end

function M.TestFlowPath()
    return TestContext:getContext("TestFlowPath",1);
end

function M.PdcaServer()
    return TestContext:getContext("PDCA_Server",1);
end

function M.SfcServer()
    return TestContext:getContext("SFC_server",1);
end

function M.AppDir()
	return TestContext:getContext("AppDir",1);
end


--test unit information
function M.ID()
	return TestContext:getContext("uid",0);
end

function M.UsbLocation()
    return TestContext:getContext("USBlocation",0);
end

function M.mlbSN()
    return TestContext:getContext("MLB_SN",0);
end

function M.cfgSN()
    return TestContext:getContext("CFG",0);
end

function M.StartTime()
    return TestContext:getContext("StartTime",0);
end

function M.TestTime()
	return TestContext:getContext("TestTime",0);
end

function M.EndTime()
    return TestContext:getContext("EndTime",0);
end

function M.IsSNInput()
	return TestContext:getContext("IsSNInput",0);
end


--system configuration
function M.IsEnable()
    return TestContext:getContext("IsEnableTest",2);
end

function M.FailCount()
	return 100
--return TestContext:getContext("approve_fail_count",2);
end


function M.LogPath()
	return TestContext:getContext("LogDir",2);
end

function M.IsLoop()
	return TestContext:getContext("Loop",2);
end

function M.NeedBarCode()
	return TestContext:getContext("ScanBarCode?",2);
end

-- return 0 fail return 1
function M.IsAdminLogin()
	return TestContext:getContext("isadminlogin",1);
end
function  getsn()
   local ret;
   ret=M.mlbSN();
   return ret;
 end

--Global function;
function msgbox(msg,title,button,icon)
	if (not title) then
		title="Test Mananger";
	end
	if (not button) then
		button=0;
	end
	if(not icon) then
		icon=0;
	end
	Msgbox(tostring(msg),tostring(title),tonumber(button),tonumber(icon));
end



function Convert_HexString(nvalue)
	high= rshift(nvalue,8);
	low = bit_and(nvalue,255);
	return string.char(high,low);
end

function HexString2Value(hexstr)
	high= lshift(string.byte(hexstr,1),8);
	low   = string.byte(hexstr,2);
	return high+low;
end

function Get_Min(par,nstart,count)
	ret = par[nstart];
	for i= nstart+1,nstart+count-1 do
		if(par[i]~=nil and par[i] <ret) then
			ret = par[i];
		end
	end
	return ret;
end

function Get_Max(par,nstart,count)
	ret = par[nstart];
	for i= nstart+1,nstart+count-1 do
		if(par[i]~=nil and par[i] >ret) then
			ret = par[i];
		end
	end
	return ret;
end		

function TestCancel()
	stoptest = true;
end

function TestErrorMsg(msg)
	Log(msg,ID);	
end