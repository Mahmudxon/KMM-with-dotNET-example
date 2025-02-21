using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

using TCP;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using static TCP.NativeBindings;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Messenger
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            IntPtr symbolsPtr = NativeBindings.shared_symbols();
            var symbols = Marshal.PtrToStructure<NativeBindings.shared_ExportedSymbols>(symbolsPtr);


            var getPlatformNamePtr = symbols.kotlin.root.uz.uniconsoft.messenger.Platform.get_name;
            var getPlatformName = Marshal.GetDelegateForFunctionPointer<GetPlatformNameDelegate>(getPlatformNamePtr);
            IntPtr platformNamePtr = getPlatformName();
            string platformName = Marshal.PtrToStringAnsi(platformNamePtr);
            Console.WriteLine($"Platform Name: {platformName}");

            // Call Greeting
            var createGreetingPtr = symbols.kotlin.root.uz.uniconsoft.messenger.Greeting.Greeting;
            var createGreeting = Marshal.GetDelegateForFunctionPointer<CreateGreetingDelegate>(createGreetingPtr);
            IntPtr greetingInstancePtr = createGreeting();

            var greetPtr = symbols.kotlin.root.uz.uniconsoft.messenger.Greeting.greet;
            var greet = Marshal.GetDelegateForFunctionPointer<GreetDelegate>(greetPtr);
            IntPtr greetingMessagePtr = greet(greetingInstancePtr);
            string greetingMessage = Marshal.PtrToStringAnsi(greetingMessagePtr);
            Console.WriteLine($"Greeting: {greetingMessage}");
        }
    }
}
