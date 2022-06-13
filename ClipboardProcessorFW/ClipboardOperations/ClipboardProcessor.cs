using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipboardProcessorFW.Processor;
using Clipboard = System.Windows.Clipboard;

namespace ClipboardProcessorFW.ClipboardOperations
{
    public class ClipboardProcessor
    {
        public void ProcessText(IClipboardTextProcessor textProcessor)
        {
            var originalClipboardContent = Clipboard.GetDataObject();

            SendKeys.SendWait("^(c)");
            var processingText = Clipboard.GetText();
            if (!string.IsNullOrEmpty(processingText))
            {
                var newText = textProcessor.Process(processingText);
                if (newText != null)
                {
                    Clipboard.SetText(newText);

                    SendKeys.SendWait("^(v)");
                    Console.WriteLine($"'{processingText}' -> '{newText}'");
                }
            }

            // if (originalClipboardContent != null)
            // {
            //     Thread.Sleep(300);
            //     Clipboard.SetDataObject(originalClipboardContent);
            // }
        }
    }
}