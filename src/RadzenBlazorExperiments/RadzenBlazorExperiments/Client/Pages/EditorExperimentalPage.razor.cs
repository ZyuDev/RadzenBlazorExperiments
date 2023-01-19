using Microsoft.AspNetCore.Components;
using Radzen;

namespace RadzenBlazorExperiments.Client.Pages
{
    public partial class EditorExperimentalPage: ComponentBase
    {
        private string _text;

        void OnPaste(HtmlEditorPasteEventArgs args)
        {
            Console.WriteLine($"Paste: {args.Html}");
        }

        void OnChange(string html)
        {
            Console.WriteLine($"Change: {html}");
        }

        void OnExecute(HtmlEditorExecuteEventArgs args)
        {
            Console.WriteLine($"Execute: {args.CommandName}");
        }
    }
}
