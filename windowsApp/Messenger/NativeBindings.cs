using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    using System;
    using System.Runtime.InteropServices;

    class NativeBindings
    {
        private const string DllName = "shared.dll"; // Replace with your DLL name without the extension

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr shared_symbols();

        [StructLayout(LayoutKind.Sequential)]
        public struct shared_ExportedSymbols
        {
            public IntPtr DisposeStablePointer;
            public IntPtr DisposeString;
            public IntPtr IsInstance;
            // Add other members as needed...

            public KotlinFunctions kotlin;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KotlinFunctions
        {
            public Root root;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Root
        {
            public Uz uz;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Uz
        {
            public Uniconsoft uniconsoft;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Uniconsoft
        {
            public Messenger messenger;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Messenger
        {
            public PlatformFunctions Platform;
            public GreetingFunctions Greeting;
            public WindowsPlatformFunctions WindowsPlatform;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PlatformFunctions
        {
            public IntPtr _type;
            public IntPtr get_name;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GreetingFunctions
        {
            public IntPtr _type;
            public IntPtr Greeting;
            public IntPtr greet;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WindowsPlatformFunctions
        {
            public IntPtr _type;
            public IntPtr WindowsPlatform;
            public IntPtr get_name;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr GetPlatformNameDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr CreateGreetingDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr GreetDelegate(IntPtr greetingInstance);
    }

}
