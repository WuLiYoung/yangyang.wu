
// PulsarOQC.h : PROJECT_NAME Ӧ�ó������ͷ�ļ�
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"		// ������


// CPulsarOQCApp:
// �йش����ʵ�֣������ PulsarOQC.cpp
//

class CPulsarOQCApp : public CWinApp
{
public:
	CPulsarOQCApp();

// ��д
public:
	virtual BOOL InitInstance();

// ʵ��

	DECLARE_MESSAGE_MAP()
};

extern CPulsarOQCApp theApp;