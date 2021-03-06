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

public class XsIntArray : XsIntArrayImpl {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal XsIntArray(global::System.IntPtr cPtr, bool cMemoryOwn) : base(xsensdeviceapiPINVOKE.XsIntArray_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(XsIntArray obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~XsIntArray() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          xsensdeviceapiPINVOKE.delete_XsIntArray(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public XsIntArray(uint sz, SWIGTYPE_p_int src) : this(xsensdeviceapiPINVOKE.new_XsIntArray__SWIG_0(sz, SWIGTYPE_p_int.getCPtr(src)), true) {
  }

  public XsIntArray(uint sz) : this(xsensdeviceapiPINVOKE.new_XsIntArray__SWIG_1(sz), true) {
  }

  public XsIntArray() : this(xsensdeviceapiPINVOKE.new_XsIntArray__SWIG_2(), true) {
  }

  public XsIntArray(XsIntArray other) : this(xsensdeviceapiPINVOKE.new_XsIntArray__SWIG_3(XsIntArray.getCPtr(other)), true) {
    if (xsensdeviceapiPINVOKE.SWIGPendingException.Pending) throw xsensdeviceapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public XsIntArray(SWIGTYPE_p_int arg0, uint sz, XsDataFlags flags) : this(xsensdeviceapiPINVOKE.new_XsIntArray__SWIG_4(SWIGTYPE_p_int.getCPtr(arg0), sz, (int)flags), true) {
  }

  public XsIntArray(SWIGTYPE_p_int arg0, uint sz) : this(xsensdeviceapiPINVOKE.new_XsIntArray__SWIG_5(SWIGTYPE_p_int.getCPtr(arg0), sz), true) {
  }

}

}
