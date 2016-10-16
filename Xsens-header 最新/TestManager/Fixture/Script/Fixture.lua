--配置搜索路径
--package.path = package.path..";".."/Users/ryan/Project/XCode/iTMP/iTMP/script/?.lua"
local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

function M.Up()
    FIXTURE:FixtureUp(tonumber(ID));
end

function M.Down()
    FIXTURE:FixtureDown(tc.ID());
end

function M.ReadString()
    local ret = FIXTURE:ReadString();
    return ret;
end

function M.WriteString(par)
    FIXTURE:WriteString(par);
end

function M.FixtureID()
    return "1";
--[[
    local ret = FIXTURE:SendCmd("readid\r\n");
	local ret = FIXTURE:SendCmd("readid\r\n");
	local ret = FIXTURE:SendCmd("readid\r\n");
	assert(ret>=0,string.format("Fixture Send Cmd failed! ret : %d",ret));
	local ret = FIXTURE:ReadString();
	ret = string.match(tostring(ret),"ReadID%s*(.-)%*_%*");
	return ret;
--]]
end

function M.T_Ver()
	FIXTURE:SendCmd("readver\r\n");
	FIXTURE:SendCmd("readver\r\n");
	FIXTURE:SendCmd("readver\r\n");
	local ret = FIXTURE:ReadString();
    local Buffer = tostring(ret);
	print("Translation Board Version : "..tostring(ret));
	ret = string.match(tostring(ret),"ReadVER%s*(.-)%*_%*");
    assert(ret,"Read translation board version failed!please check the electric controller connection is OK,and the transltation ver had been set! Buffer : \r\n"..tostring(Buffer));
	return ret;
end


