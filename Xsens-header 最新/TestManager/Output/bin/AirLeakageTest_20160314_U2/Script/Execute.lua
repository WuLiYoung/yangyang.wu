--//
--//  Excute.lua
--//  iTMP
--//
--//  Created by Ryan on 12-2-3.
--//  Copyright 2012年 __MyCompanyName__. All rights reserved.
--//
--require "Modules"

--Step function list
--测试步骤函数list
--require "RLdb"
local version = 1.2

PDCA_ATTR="Attribute"
PDCA_VALUE="value"

DEBUG = 1;

PASS=1;
FAIL=0;
ERROR=-1;
SKIP=2;

function DbgOut(fmt,...)
	if (DEBUG ~=0) then
		DbgLog(string.format(tostring(fmt),...),ID);
	end
end

function TestFlowOut(fmt,...)
	--[[if (DEBUG ~=0) then
		Log(string.format(tostring(fmt),...),ID);
	end--]]
end

local EN_DEBUG = 0;
function Entry(fun,...)		--Log Function
	if (EN_DEBUG == 0) then return; end
	str = tostring(fun);
	if(...) then
		for i,v in ipairs{...}do
			str=str.." "..tostring(v);
		end
	end
	DbgOut(str);
end

function CheckResult(lower,upper,value)				--根据spec检验测试结果，PASS:在spec之内 FAIL:在spec范围之外
	TestFlowOut("lower:%s upper:%s value:%s",tostring(lower),tostring(upper),tostring(value));
--	if (not value) then do return PASS end end;		--value 为nil
	local res=PASS;		--all pass
	if (lower) or (upper) then
		if (type(lower)=="number") or (type(upper)=="number") then			--spec为数字类型
			--assert(type(value)=="number","Returen value with incorrect format,expect number ,reutrn format is "..type(value));
						--根据spec强制转换结果，避免产生错误
			value=tonumber(value);
			if (not value) then return FAIL end;
			if (lower) then
				if (value<lower) then
					res = FAIL;
				end
			end
			if (upper) then
				if (value>upper) then
					res = FAIL;
				end
			end
		elseif (type(lower)=="string") or (type(upper)=="string")  then		--spec为字符串类型
			--assert(type(value)=="string","Returen value with incorrect format,expect string ,reutrn format is "..type(value));
--[[			if (not value) then
				return FAIL; 
			end	--返回为nil

			value=tostring(value);
]]
			if (not value) then
				return FAIL;
			end	--返回为nil
			if (string.upper(value)=="NIL") then
				return FAIL;
			end
			if (type(value)=="number") then
				if (value==0) then
					return PASS;
                    else
					return FAIL;
				end
			end
			--assert(type(value)=="string","Error,The return value is "..tostring(value)..",with type : "..type(value).."but the spec is string.");
            
			value=tostring(value);
            
			if (#(tostring(lower))==0) and (#(tostring(upper))==0) then 
				return PASS; 
			end	--spec为空字符串，匹配任意字符

			if (tostring(value)==lower) then 
				return PASS;
			else
				return FAIL;
			end
		end
	else							--没有设定spec,处理成P/F值
		if (tonumber(value)==0) or (value == nil) then	--返回0或没有返回值，当作PASS处理
			res = PASS;
		else
			res = FAIL;
		end
	end
	return res;
end

local result=PASS;

this={};				--当前测试项目

--执行一个测试Item
local steps=-1;
local function Excute_Item(item)
		Entry("Entry \""..item.name.."\" Item");		--Log message
		--DbgOut("Test Item : '"..item.name.."'".." upper is :"..tostring(item.lower).." lower is :"..tostring(item.upper));

		this=item;
		local value=0;
		local state=0;
		if (type(item.entry)=="function") then		--Do test function
			Entry("Call "..tostring(item.entry));
			if (item.parameter==nil) then item.parameter = {} end;
			value,display =item.entry(item.parameter); --在这里执行entry
--			value=0;	--just for debug
			
			--判定测试结果
		--			DbgOut("value1 : %s value2 : %s value3 : %s value4 : %s",tostring(value1),tostring(value2),tostring(value3),tostring(value4)); 
			state = CheckResult(item.lower,item.upper,value);
			
			if (item.lower == nil) and (item.upper==nil) then		--无值型测试项，一般用于执行一个动作
				if (tonumber(value)==0) or (value == nil) then	--返回0或没有返回值，当作PASS处理
					value="PASS"
					state=1;
				else 
					value="FAIL" 
					state=0;
				end
			end
			
			if (state>0) then
				TestFlowOut("\tPASS");
			else
				TestFlowOut("\tFAIL");
			end

		elseif(type(item.entry) == "string") then		--为字符串形式，直接执行该字符串
			DbgOut("value.entry : %s",tostring(item.entry));
			local func,err = loadstring(item.entry);
			assert(func~=nil,tostring(err));			--exception
			value = func();
			
			--判定测试结果
		--			DbgOut("value1 : %s value2 : %s value3 : %s value4 : %s",tostring(value1),tostring(value2),tostring(value3),tostring(value4)); 
			state = CheckResult(item.lower,item.upper,value);

			if (item.lower == nil) then		--无值型测试项
				if (tonumber(value)==0) then
					value="PASS" 
					state=1;
				else 
					value="FAIL" 
					state=0;
				end
			end
			
			if (state>0) then
				TestFlowOut("\tPASS");
			else
				TestFlowOut("\tFAIL");
			end
		else	--其他任意格式，不执行处理
			display="Skipped"
			value="Skipped";
--			item_state=0x0F;
			state=2;
		end
		
		Entry("Leave \""..item.name.."\" Item\r\n");
		TestFlowOut("");
	
		return value, state,display;

end

---[[
ItemFail={};	--fail items conllection
SHOW_ALL_ITEM=0;
local count_index=0;

function DoTest(ti)	--测试主循环入口TestEntry,执行test sequence
--	sfasfsdf();
	local test_result = PASS;
	for index,value in ipairs(ti) do
		--UUT_SYNCH(ID);
		--处理Debug消息
		if (value.sub==nil) then		--Sub test item
			TestFlowOut("==SubTest: %s",value.name);
			steps=steps+1;
		else
			TestFlowOut("==Test: %s",value.name);		--Key item
		end		
		-- 运行debug.prf才会执行的 lxl	
		-- nil == nil	
		if (DEBUG_CMD == DEBUG_DISABLE) then
			--Do Nothing...
		elseif (DEBUG_CMD==DEBUG_STEP) then		--Step
			if (value.sub==nil) then
				pause();	--不是key item
			end
		else
			if (CheckBreakPoints(tostring(value.name))>0) then		--Capture break point
				pause();
			end
		end
		
		value.value=nil		--clear test result;
	
--		if ((SHOW_ALL_ITEM==1) or (value.visible ~=0)) then	--显示指定隐藏该项目的显示，则不显示该项目，缺省显示该项目	
		if ((not value.sub) and (value.visible ~=0)) then	--显示指定隐藏该项目的显示，则不显示该项目，缺省显示该项目	
			ui.ITEM_START();		--Update UI of current item
		end

		local ret,state,display

	--this item should be skipped or not.
		local isskip = false;
		if (value.skip) then		--this item has been set need to care is skipped or not
			local skip = value.skip;
			isskip = skip;
			if (type(skip)=="function") then
				isskip = skip();
				DbgOut("isskip : "..tostring(isskip));
			elseif (type(skip)=="string") then
				local func,err = loadstring(skip);
				assert(func~=nil,tostring(err));			--exception
				isskip = func();
			else
				if (isskip==0) then
					isskip = false;
				end
			end
		end
		
		if (isskip) then		--this item should be skipped
				DbgOut("Item : '"..value.name.."'".." has been skipped!");
				ret,state,display = nil,2,"Skipped";
				value.value="Skipped";
		else
---[[
			ret,state,display = Excute_Item(value);	--Execute test item entry function, and check the return value.
--]]
			if (not ret) then
				ret = tostring(ret);
			end
			value.value=ret;
		end
		
--record test result and storage		
        if (state<=0) then
            test_result = FAIL;
            ItemFail[#ItemFail+1]=value.name;
        end

--		if ((SHOW_ALL_ITEM==1) or (value.visible ~=0)) then	--显示指定隐藏该项目的显示，则不显示该项目，缺省显示该项目	
		if ((not value.sub) and (value.visible ~=0)) then	--显示指定隐藏该项目的显示，则不显示该项目，缺省显示该项目	
			ui.ITEM_FINISH(ret,state,display,tostring(value.exinfo));		--Update UI
			if (value.sub==nil) then
				--处理PDCA项目
				if (not value.PDCA) or (not value.PDCA.ATTR) then	--没有指定PDCA,或没有指定为attribute,则当作测试项目来处理
				end
			end
		---[[
		elseif(value.visible == 0 and value.exinfo ~=nil) then --如果有exinfo同时是不可见的也话更新UI
			ui.ItemUpdateExInfo(ret,state,display,tostring(value.exinfo));
		--]]
		end
		
--if need stop when test fail
		if ((value.stopfail) and (value.stopfail~=0)) then	--stop if fail
			if (state<=0) then
				TestCancel();
				break;	--break current loop
			end
		end

--check fail count 
		local fc = tc.FailCount();
		
		if (not fc) then
			fc=-1 
		else
			fc=tonumber(fc);
		end
		
		if (fc==0) then
			if (#ItemFail>fc) then
				stoptest = true;
				
				break;
			end
		elseif (fc>0) then
			if (#ItemFail>=fc) then
				DbgOut("Stop running ")
				stoptest = true;
				break;
			end
		end

		--执行子项目
		if (value.sub) then
			local ret = DoTest(value.sub);
			if (ret<=0) then
				test_result=FAIL;
			end
		end
		
		--stop current test?

		if (stoptest) then
			if (value.sub) then
				DbgOut("Stop running by stoptest!!!");
				Test_OnAbort();
			end

			break;
		end

	end
    return test_result;
end
--]]


local function __Initial_Test()
	--initial global variant	
	ItemFail = {};
	stoptest = false;
	if (__InitialReport) then
		__InitialReport(items);
	end
end

local function __Finish_Test(result)
	if (__SaveReport) then
		__SaveReport(result);
	end
	if stoptest == true then
		Test_OnAbort();
	end
end


--Main function entry
function main(...)
--start test	
	__Initial_Test();
	ui.TEST_START();		--Update UI to start test
	Test_OnEntry();		--Call
	local ret = DoTest(items);		--do test
	
    DbgOut("result : %d",tonumber(ret));
    DbgOut("Fail Item : \r\n"..table.concat(ItemFail,","));
 --   Test_OnDone();		--Call back function
	if (ret == 0) then
        Test_OnFail();
    else
        Test_OnDone();
    end
	if(stoptest == false) then	    --no need to save the log when test abort		
		DbgOut("stoptest == false")
		ui.TEST_FINISH(ret);			--Show test ressult
		__Finish_Test(ret);
	else
		DbgOut("stoptest == true")
		ret = 2;
		ui.TEST_FINISH(ret);			--Show test ressult
	end
end