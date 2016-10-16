#ifndef	_CC_FLASH__
#define _CC_FLASH__\

typedef enum {
	HPI_FAILSAFE_FW_MODE = 1,
	HPI_MAIN_FW_MODE
}firmware_mode_t;

typedef enum
{
	BOOTLOADER,
	CONFIGTABLE
} file_option_t;

typedef enum {
	VDM_BOOT_MODE,
	VDM_FAILSAFE_MODE,
	VDM_MAINFW_MODE
}device_mode_t;

typedef enum {
	CY_PD_VDM_RECEIVED = 0x94
}event_rec_t;

typedef enum
{
	S_VDM_RESERVED,
	VDM_GET_DISCOVER_ID,
	VDM_GET_DISCOVER_SVID,
	VDM_GET_DISCOVER_MODE,
	VDM_ENTER_MODE,

} s_vdm_cmd_t;

typedef enum
{
	VDM_RESERVED,
	VDM_GET_DEVICE_MODE,
	VDM_GET_DEVICE_VERSION,
	VDM_GET_SILICON_ID,  
	VDM_DEVICE_RESET,
	VDM_JUMP_TO_BOOT,
	VDM_ENTER_FLASHING_MODE, 
	VDM_SEND_DATA, 
	VDM_FLASH_WRITE,
	VDM_READ_DATA,
	VDM_FLASH_READ,
	VDM_VALIDATE_FW,
	VDM_REASON_FOR_BOOT_MODE,
	VDM_GET_CHECKSUM

}vdm_cmd_t;

/* CC bootloader state machine states */
typedef enum
{
    CC_FLASH_DISABLED,
	CC_FLASH_GET_DISCOVER_ID,
	CC_FLASH_GET_DISCOVER_SVID,
	CC_FLASH_GET_DISCOVER_MODE,
	CC_FLASH_ENTER_MODE,
    CC_FLASH_GET_SILICON_ID,
    CC_FLASH_GET_MODE,
	CC_FLASH_GET_VERSION,
    CC_FLASH_JUMP_TO_BOOT,
    CC_FLASH_ENTER_FLASH_MODE,
	CC_FLASH_SEND_DATA,
    CC_FLASH_FLASH_WRITE,
	CC_FLASH_GET_CHECKSUM,
	CC_FLASH_FLASH_READ,
	CC_FLASH_READ_DATA,
    CC_FLASH_VALIDATE_FW,
    CC_FLASH_RESET,
    CC_FLASH_COMPLETE,

} tCC_FLASH_STATE;

typedef struct
{
	UINT16 row_num;
	UINT16 row_size;
	UINT8 datap[128];
} tCC_FLASH_INFO;

extern tCC_FLASH_STATE cc_flash_state;

/*
	State machine to update the cc flash firmware
*/
int cc_flash_state_machine(void);

/*
	 Initialize the flash and open the file to be flashed.
	 file_option: whether to flash boot loader or config table
*/
BOOL cc_flash_init (firmware_mode_t fw_mode);


BOOL
handle_flashing_controller_reset (
				void);

#endif /* _CC_FLASH__ */