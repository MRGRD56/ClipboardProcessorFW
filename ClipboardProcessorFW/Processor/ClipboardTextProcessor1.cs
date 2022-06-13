namespace ClipboardProcessorFW.Processor
{
    public class ClipboardTextProcessor1 : IClipboardTextProcessor
    {
        public string Process(string text)
        {
            if (!int.TryParse(text, out var number))
            {
                return null;
            }

            return (number + 24).ToString();
        }
    }
}