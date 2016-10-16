

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = ../../Run/Debug/TestLua.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../../Run/Debug/LuaInterface.dll
BUILD_DIR = ../../Run/Debug

TESTLUA_EXE_MDB_SOURCE=../../Run/Debug/TestLua.exe.mdb
TESTLUA_EXE_MDB=$(BUILD_DIR)/TestLua.exe.mdb
LUAINTERFACE_DLL_SOURCE=../../Run/Debug/LuaInterface.dll
LUAINTERFACE_DLL_MDB_SOURCE=../../Run/Debug/LuaInterface.dll.mdb
LUAINTERFACE_DLL_MDB=$(BUILD_DIR)/LuaInterface.dll.mdb
KOPILUA_DLL_SOURCE=../../Run/Debug/KopiLua.dll
KOPILUA_DLL_MDB_SOURCE=../../Run/Debug/KopiLua.dll.mdb
KOPILUA_DLL_MDB=$(BUILD_DIR)/KopiLua.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:RELEASE"
ASSEMBLY = ../../Run/Release/TestLua.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../../Run/Release/LuaInterface.dll
BUILD_DIR = ../../Run/Release

TESTLUA_EXE_MDB=
LUAINTERFACE_DLL_SOURCE=../../Run/Release/LuaInterface.dll
LUAINTERFACE_DLL_MDB=
KOPILUA_DLL_SOURCE=../../Run/Release/KopiLua.dll
KOPILUA_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(TESTLUA_EXE_MDB) \
	$(LUAINTERFACE_DLL) \
	$(LUAINTERFACE_DLL_MDB) \
	$(KOPILUA_DLL) \
	$(KOPILUA_DLL_MDB)  

BINARIES = \
	$(TESTLUAINTERFACE)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Entity.cs \
	TestLua.cs \
	TestLuaInterface.cs \
	Properties/AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Properties \
	Readme.txt \
	testluainterface.in 

REFERENCES =  \
	System \
	System.Data \
	System.Xml

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

LUAINTERFACE_DLL = $(BUILD_DIR)/LuaInterface.dll
KOPILUA_DLL = $(BUILD_DIR)/KopiLua.dll
TESTLUAINTERFACE = $(BUILD_DIR)/testluainterface

$(eval $(call emit-deploy-wrapper,TESTLUAINTERFACE,testluainterface,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
