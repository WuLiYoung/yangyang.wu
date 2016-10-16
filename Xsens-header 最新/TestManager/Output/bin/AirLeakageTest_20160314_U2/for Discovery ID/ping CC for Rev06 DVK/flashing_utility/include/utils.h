/*
## Cypress CCG1 HPI: Utilities Header File
## ===========================
##
##  Copyright Cypress Semiconductor Corporation, 2013-2014,
##  All Rights Reserved
##  UNPUBLISHED, LICENSED SOFTWARE.
##
##  CONFIDENTIAL AND PROPRIETARY INFORMATION
##  WHICH IS THE PROPERTY OF CYPRESS.
##
##  Use of this file is governed
##  by the license agreement included in the file
##
##     <install>/license/license.txt
##
##  where <install> is the Cypress software
##  installation root directory path.
##
## ===========================
*/

#ifndef _UTILS__
#define _UTILS__

/*****************************************************************************
* Enumeration Name: status_t
******************************************************************************
* Summary:
* This data type enumerates the return values used by API.
*****************************************************************************/
typedef enum {

	STATUS_SUCCESS,
	STATUS_ERROR,

} status_t;

/*****************************************************************************
* Structure Name: status_t
******************************************************************************
* Summary:
* This data type is the structure to hold Command line arguments.
*****************************************************************************/

typedef struct {
	char	filename[128];
	char	file_type[32];
	int		file_type_int;	
	UINT8	packet_type[32];
	UINT8	sop_type;
	UINT8   fw_mode;
}agr_t;

extern agr_t received_arg;

/*****************************************************************************
* Structure Name: vdm_header_t
******************************************************************************
* Summary:
* This data type is the structure to hold CY defined VDM header.
*****************************************************************************/
typedef struct
{
	UINT32 vdm_cmd :		5;
	UINT32 seq_num :		3;	
	UINT32 res :			3;
	UINT32 vdm_cmd_type :   2;
	UINT32 vdm_cmd_v :		2;
	UINT32 vdm_type :		1;
	UINT32 svid :			16;
	
}u_vdm_header_t;

/*****************************************************************************
* Structure Name: s_vdm_header_t
******************************************************************************
* Summary:
* This data type is the structure to hold PD specific Standard VDM header.
*****************************************************************************/
typedef struct
{
	UINT32 vdm_cmd :		5;
	UINT32 res0 :			1;	
	UINT32 cmd_type :	    2;
	UINT32 obj_pos :		3;
	UINT32 res1 :			2;
	UINT32 vdm_ver :		2;
	UINT32 vdm_type :		1;
	UINT32 svid :			16;
	
}s_vdm_header_t;

/*****************************************************************************
* Structure Name: vdm_packet_t
******************************************************************************
* Summary:
* This data type is the structure to hold CY defined VDM Message.
*****************************************************************************/
typedef struct
{
	UINT8 packet_header[4];
	u_vdm_header_t header;
	UINT32		 data[6];

}u_vdm_packet_t;

typedef struct
{
	UINT8 packet_header[4];
	s_vdm_header_t header;
	UINT32 data[6];
} s_vdm_packet_t;

extern u_vdm_packet_t vdm_resp_packet;

#endif /* _UTILS__ */