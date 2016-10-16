/// <summary> 
/// <para> �� Ȩ : Copyright (c) 20010-2011 </para> 
/// <para> �� Ŀ : xxxxx/RD/xxxx </para> 
/// <para> �ļ����� : </para>
/// <para> �� �� �� : lizhi </para>
/// <para> �������� : 2010-11-22 </para>
/// <remarks> �� ע : 
///     ddgooo@sina.com
/// </remarks>
/// </summary> 
///  
     public class Win32Message
    {
        /// <summary>
        /// ��Ϣ
        /// </summary>
        public const int WM_COPYDATA = 0x004A;

        /// <summary>
        /// WM_COPYDATA��Ϣ�ṹ��
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYDATASTRUCT
        {
            /// <summary>
            /// �û���������
            /// </summary>
            public IntPtr   dwData;
            /// <summary>
            /// ���ݴ�С
            /// </summary>
            public int      cbData;
            /// <summary>
            /// ָ�����ݵ�ָ��
            /// </summary>            
            public IntPtr lpData;
        }

        /// <summary>
        /// ע����Ϣ��
        /// ��win7�У�����Թ���Ա��ʽ���У���Ҫ�������䣬ע��WM_COPYDATA��Ϣ��������˵�����Ϣ��
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool ChangeWindowMessageFilter(int msg, int flags);
        

        /// <summary>
        /// ����WM_COPYDATA��Ϣ
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// ����WM_COPYDATA��Ϣ
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool PostMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam); 
                        
        /// <summary>
        /// ���Ҿ��
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);

        /// <summary>
        /// ���Ҿ��
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="hwndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent,IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    }