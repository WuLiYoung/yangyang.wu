//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.5
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace XDA {

public enum XsCalibratedDataMode {
  XCDM_None = 0,
  XCDM_Acceleration = (1 << 0),
  XCDM_GyroscopeData = (1 << 1),
  XCDM_MagneticField = (1 << 2),
  XCDM_AccGyr = XCDM_Acceleration|XCDM_GyroscopeData,
  XCDM_AccMag = XCDM_Acceleration|XCDM_MagneticField,
  XCDM_GyrMag = XCDM_GyroscopeData|XCDM_MagneticField,
  XCDM_All = XCDM_Acceleration|XCDM_GyroscopeData|XCDM_MagneticField
}

}
