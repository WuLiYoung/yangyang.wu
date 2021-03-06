--DUT操作函数模块

local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

--Marco define
local DUT_LOG = 0;	--记录调试信息
local function DUT_log(fmt,...)
	if (DUT_LOG ~=0) then
		--Log("	:)"..string.format(fmt,...),ID);
        Log("	:)"..tostring(fmt),ID);
	end
end

function M.SetDetectString(str)
	return SensorR:SetDetectString(str);
end
function M.WriteString(str)
	return SensorR:WriteString(str);
end

function M.ReadString()
	return SensorR:ReadString();
end

function M.WaitForString(ntime)
	return SensorR:WaitForString(ntime);
end

function M.WaitString(str,ntimeout)
	return SensorR:WaitString(str,ntimeout);
end

function M.Get_LuxValue()
	M.SetDetectString("@_@\r");
	M.WriteString("Read Sensor Value\r\n");
	--[[if M.WaitForString(600)~=-1 then
		local ret = SensorR:ReadString();
		if ret ~=nil then
			sub =  string.gfind(ret,"Read Sensor Value CH0:");
			if sub ~=nil then
				DbgOut(tostring(ret));
			end
		end
	else
	end--]]
	return 0;
end

function M.Get_IntValue()
	return SensorR:GetLightValue();
end

function M.Get_LuxSafeValue()
	local ret = 0;
	trystep = 0;
	while trystep <=0 do
		M.Get_LuxValue();
		ret = M.Get_IntValue();
		trystep= trystep+1;
	end
	return ret;
end

function M.ResetSensor()
	M.SetDetectString("@_@");
	M.WriteString("Reset Sensor Board\r\n");
end