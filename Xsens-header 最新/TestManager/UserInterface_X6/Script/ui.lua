--��������·��
--package.path = package.path..";".."/Users/ryan/Project/XCode/iTMP/iTMP/script/?.lua"
local modname=...;
local M={};
_G[modname]=M;
package.loaded[modname]=M;

local item_index=0;
local item_remark="";

--local ID=1;
--FCT ���Գ���wapper����
function M.TEST_START()		--���Կ�ʼ����UI
	item_index=0;		--����index
	UI:ShowTestStart(ID);
end

--public int ShowItemStart(int id, int index)
function M.ITEM_START()		--ʹһ����������ʾ��ʼ����
	--item_remark="";
	UI:ShowItemStart(ID,item_index);
end


--int ShowItemFinish(int id, int index, string display, int status, string remark)
function M.ITEM_FINISH(value,state,display,remark)	--��ʾһ����Խ������ȷ���ڸú�����ItemStart�����ĵ������Ӧ
	UI:ShowItemFinish(ID,item_index,tostring(display or value),state,remark);
	item_index=item_index+1;	--�Զ��ۼ�index
end

function M.ItemUpdateExInfo(value,state,display,remark)
	UI:ShowItemExInfo(ID,tostring(display or value),state,remark);
end

function M.TEST_FINISH(result)		--���������ʾPASS or FAIL	-1:ERROR 0:FAIL 1:PASS
	UI:ShowTestFinish(ID,result);		--PASS
end

function M.UiSetSN(cmd)
	UI:UiSetSN(ID,cmd);
end
--side is string "Left" "Right" nindex is start form 0
function M.UiHighlightLamp(side,nindex)
	local nside;
	if side=="Left" then
		nside = 0;
	elseif side =="Right" then
		nside = 1;
	else
		nside = -1;
	end
	UI:UiHighlightLamp(ID,nside,nindex);
end
--side is string "Left" "Right" 
function M.UiDisplayARMINMAX(side,nindex,ret,resultstatue)
	local nside;
	if side=="Left" then
		nside = 0;
	elseif side =="Right" then
		nside = 1;
	else
		nside = -1;
	end
	UI:UiDisplayARMinMax(ID,nside,nindex,ret,resultstatue);
end

function M.UiShowStatue(value,delay)
	
end
