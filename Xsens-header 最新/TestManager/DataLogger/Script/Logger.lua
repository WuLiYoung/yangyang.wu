--DUT操作函数模块

local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
local DL_LOG = 1;	--记录调试信息

local function DL_log(fmt,...)
	if (DL_LOG ~=0) then
		DbgLog("	:)"..string.format(fmt,...),ID);
	end
end

function M.SetFileHeader(fileheader)
	return DataLogger:SetFileHeader(fileheader);
end

ICT_OS_items="";
ICT_MDA_items="";
local items_names={};
local items_upper={};
local items_lower={};
local items_units={};
local items_value={};


--枚举当前测试项目的递归函数
local function EnumItemList(its)
	for index,value in ipairs(its) do
		if (value.sub==nil) then		--不处理key item
			if ((value.visible~=false) and (value.visible ~=0)) then	--不处理被隐藏的item
				--DbgOut("Name : %s, Value : %s\r\n",tostring(value.name),tostring(value.value));
				if (value.value) then
					items_value[#items_value+1]=string.gsub(tostring(value.value),",",";");	--test reult;
				else
					items_value[#items_value+1]="";	--no test,has been stop
				end
				items_names[#items_names+1]=string.gsub(value.name,",",";");	--replace , with ; for match csv file format
				if (value.upper) then
					if (#tostring(value.upper)==0) then
						items_upper[#items_upper+1]="N/A";		--""
					else
						items_upper[#items_upper+1]=value.upper;
					end
				else
					items_upper[#items_upper+1]="N/A";
				end
				
				if (value.lower) then
					if (#tostring(value.lower)==0) then			--""
						items_lower[#items_lower+1]="N/A";
					else
						items_lower[#items_lower+1]=value.lower;
					end
				else
					items_lower[#items_lower+1]="N/A";
				end
				
				if (value.unit) then
					items_units[#items_units+1]=value.unit;
				else
					items_units[#items_units+1]="N/A";
				end
			end
		else	--get sub items
			EnumItemList(value.sub);
		end
	end
end

--创建Csv文件头
function M.BuildCsvLogFileHeader(its)
	local csv_header="Intelligent,V1.00,FCT\r\n";		--first Line
	local csv_header=csv_header.."Serial Number,Station ID,PASS/FAIL,Site ID,Fail Item,Start time,Test time,";
	
	--reintial header
	items_names={};
	items_upper={};
	items_lower={};
	items_units={};
	items_value={};
	EnumItemList(its);
	
	csv_header = csv_header..table.concat(items_names,",").."\r\n";
	csv_header=csv_header..ICT_OS_items;
	csv_header=csv_header..ICT_MDA_items;
	
	csv_header = csv_header.."upper Limited----------->,,,,,,,"..table.concat(items_upper,",").."\r\n";
	csv_header = csv_header.."Lower Limited----------->,,,,,,,"..table.concat(items_lower,",").."\r\n";
	
	csv_header = csv_header.."Unit		   ----------->,,,,,,,"..table.concat(items_units,",").."\r\n";
	--csv_header = csv_header.."Unit         ----------->,,,,,,,,,"..table.concat(items_units,",").."\r\n";
	
	--csv_header = csv_header.."Unit----------->,,,,,"..table.concat(items_units,",").."\r\n";
	
	M.SetFileHeader(csv_header);
end

function make_datestring()
	t = os.date("*t");
	ret = tostring(t.year).."-"..tostring(t.month).."-"..tostring(t.day);
	--t = os.time("*t");
	--ret = tostring(t.day)..tostring(t.hour)..tostring(t.min)..tostring(t.sec)
	return ret;
end
--创建CSV数据文件报表
local function CsvReport(result)
	--local filepath = tc.AppDir().."/"..tc.CsvLogPath.."/"..os.date("%Y-%m-%d %H:%M:%S.csv")
	--local filepath = tc.LogPath().."\\"..tostring(tc.mlbSN()).."_"..make_datestring()..".csv";--os.date("%Y-%m-%d.csv")
	local filepath = tc.LogPath().."\\"..make_datestring()..".csv";--os.date("%Y-%m-%d.csv")	
	--if DirInLogPath~=nil then
	--	if LogName ~=nil  then
	--		filepath = tc.LogPath().."\\"..DirInLogPath.."\\"..tostring(LogName).."-"..make_datestring()..".csv";--..os.date("%Y-%m-%d.csv");
	--	else
	--		filepath = tc.LogPath().."\\"..DirInLogPath.."\\"..make_datestring()..".csv";--os.date("%Y-%m-%d.csv");
	--	end
	--else
	--	filepath = tc.LogPath().."\\"..make_datestring()..".csv";--os.date("%Y-%m-%d.csv");
	--end

	
	DbgOut(tostring(filepath));
	
	--local td = "[sn],[cfg],[station id],[site id],[pass/fail],[error msg],[fail item],[start time],[test time],";
	local td = "[sn],[station id],[pass/fail],[site id],[fail item],[start time],[test time],";
	td = string.gsub(td,"%[sn%]",tostring(tc.mlbSN()));
	
	--td = string.gsub(td,"%[cfg%]","'"..tostring(tc.cfgSN()).."\r\n");
	--td = string.gsub(td,"%[station id%]",tostring(tc.LineName()));
	td = string.gsub(td,"%[station id%]",tostring(tc.StationName()));
	td = string.gsub(td,"%[site id%]",tostring(tonumber(ID)+1));
	
	if (result>0) then
		td = string.gsub(td,"%[pass/fail%]","PASS");
	else
		td = string.gsub(td,"%[pass/fail%]","FAIL");
	end
	
	--td = string.gsub(td,"%[error msg%]","");
	
	local f = table.concat(ItemFail,";");
	f = string.gsub(f,",",";");--replace , with ; for match csv file format
	td = string.gsub(td,"%[fail item%]",f);
	
	td = string.gsub(td,"%[start time%]",tostring(tc.StartTime()));
	td = string.gsub(td,"%[test time%]",tostring(tc.TestTime()));
	--td = string.gsub(td,"%[open short%]","PASS");
	--td = string.gsub(td,"%[mda test%]","PASS");
	--td = string.gsub(td,"%[rail short%]","PASS");
	td = td..table.concat(items_value,",").."\r\n";
--	DataLogger:AddRecord(td);
	DataLogger:push_CSV(td);		--添加所有的记录
	
	return DataLogger:csvReport(filepath);	--保存到数据文件
end

--UART Log 报表
local function UartReport(filepath)
	--local filepath = "[LOG_DIR]/uart_log/[sn]_[station id]_[sit id]_[timestamp]_uart.txt";
	local filepath = tostring(tc.VaultPath()).."/"..tostring(tc.UartLogPath()).."/"..tostring(tc.StationName()).."_"..tostring(tc.mlbSN()).."_"..tostring(tc.ID()).."_"..os.date("%Y-%m-%d-%H-%M-%S").."_uart.txt";
	return DataLogger:uartLog(filepath);
end

--Test Flow报表
local function TestFlowReport()
	local filepath = tostring(tc.VaultPath()).."/"..tostring(tc.TestFlowPath()).."/"..tostring(tc.StationName()).."_"..tostring(tc.mlbSN()).."_"..tostring(tc.ID()).."_"..os.date("%Y-%m-%d-%H-%M-%S").."_flow.txt";
	return DataLogger:testflowLog(filepath);
end

--PDCA pudding entry
function M.Pudding_Attribute(key,value)
end

--int push_item(char * name,int status,char * value=NULL,char * lower=NULL,char * upper=NULL,char * unit=NULL);
function M.Pudding_Item(name,statue,value,lower,upper,unit)
end

function M.Pudding_Result()
end

function M.Pudding_Blob(name,path)
end

function M.Pudding_Blob_Buffer(name,buffer)
end

function M.SaveToFile(result)
	M.BuildCsvLogFileHeader(items);
	CsvReport(result);
	--UartReport();
	--TestFlowReport();
--	return DataLogger:SaveToFile(filepath);
end


---Global message
function __InitialReport(it)
end

function __SaveReport(ret)
	M.SaveToFile(ret);
end

-- For Flex
function __GetUnitInfo(info)
	return DataLogger:GetUnitInfo(info)
end


function __SaveResult(info)
	return DataLogger:SaveResult(info)
end