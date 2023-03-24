namespace RadzenBlazorExperiments.Client.Models;

public class SheetColumn
{
    public int ColumnNumber { get; set; }
    public string Title { get; set; }
    public int WidthValue { get; set; } = 150;
    public string Width => $"{WidthValue}px";
}