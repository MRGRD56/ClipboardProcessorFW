using System;
using System.Diagnostics;
using GlobalLowLevelHooks;
using System.Windows.Forms;
using ClipboardProcessorFW.ClipboardOperations;
using ClipboardProcessorFW.Processor;
using GlobalKeyboardHookLib;

namespace ClipboardProcessorFW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var clipboardProcessor = new ClipboardProcessor();
            var keyboardHook = new GlobalKeyboardHook();

            keyboardHook.KeyboardPressed += (sender, e) =>
            {
                if (e.KeyboardData.VirtualCode != (int) KeyboardHook.VKeys.OEM_3 
                    || e.KeyboardState != GlobalKeyboardHook.KeyboardState.KeyDown)
                {
                    return;
                }

                try
                {
                    clipboardProcessor.ProcessText(new ClipboardTextProcessor1());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    e.Handled = true;
                }
            };
        }
    }
}