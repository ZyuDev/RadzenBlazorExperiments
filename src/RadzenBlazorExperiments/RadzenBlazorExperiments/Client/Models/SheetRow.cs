namespace RadzenBlazorExperiments.Client.Models;

public class SheetRow
{
    public int RowNumber { get; set; }
    public List<SheetCell> Cells { get; set; } = new List<SheetCell>();
}