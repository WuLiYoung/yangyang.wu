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
	return Scanner:SetDetectString(str);
end
function M.WriteString(str)
	return Scanner:WriteString(str);
end

function M.ReadString()
	return Scanner:ReadString();
end

function M.WaitForString(ntime)
	return Scanner:WaitForString(ntime);
end


function M.Enable_Scanner()
	capture=">start capture";
	M.WriteString(capture);
end	

function M.GetQRCode()
	M.SetDetectString("\r\n");
	M.Enable_Scanner();
	if(M.WaitForString(1000) == -1) then
		
	else
		str =scanner.ReadString();
		if(str ~=nil) and (string.len(str)>5) then
			ret  = string.sub(str,2,string.len(str)-2);
			return tostring(ret);	
		end
	end
	return nil;
end