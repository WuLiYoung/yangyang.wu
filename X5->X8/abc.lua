function __split(str, reps)
	local r = {};
	if (str == nil) then 
		return nil; 
	end
	string.gsub(str, "[^"..reps.."]+", function(w) table.insert(r, w) end);
	return r;
end

local a = "1!1,123,456,789"
local b = __split(a,",")
for i=1,#b do
	print(b[i])
end