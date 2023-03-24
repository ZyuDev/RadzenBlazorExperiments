using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using RadzenBlazorExperiments.Client.Models;

namespace RadzenBlazorExperiments.Client.Pages;

public partial class SheetExperimentalPage : ComponentBase
{
    private List<SheetRow> _sheet = new List<SheetRow>();
    private List<SheetColumn> _columns = new List<SheetColumn>();
    private SheetCell _selectedCell;
    private SheetCell _prevCell;
    private int RowMax = 30;
    private int ColumnMax = 15;

    protected override void OnInitialized()
    {
        for (var r = 1; r <= RowMax; r++)
        {
            var newRow = new SheetRow();
            newRow.RowNumber = r;
            for (var c = 1; c <= ColumnMax; c++)
            {
                var newCell = new SheetCell()
                {
                    Row = r,
                    Column = c,
                };
                newRow.Cells.Add(newCell);
            }

            _sheet.Add(newRow);
        }

        for (var c = 1; c <= ColumnMax; c++)
        {
            var newColumn = new SheetColumn()
            {
                Title = c.ToString(),
                ColumnNumber = c
            };
            _columns.Add(newColumn);
        }
    }

    private int RowNumber(SheetRow row)
    {
        return _sheet.IndexOf(row) + 1;
    }

    private SheetCell GetCell(SheetRow row, SheetColumn column)
    {
        var i = column.ColumnNumber - 1;
        var cell = row.Cells[i];

        return cell;
    }

    private bool IsCellEditing(SheetRow row, SheetColumn column)
    {
        if (_selectedCell == null)
        {
            return false;
        }
        
        var i = column.ColumnNumber - 1;
        var cell = row.Cells[i];

        return _selectedCell.Equals(cell);
    }

    private void OnCellClick(DataGridCellMouseEventArgs<SheetRow> args)
    {
        Console.WriteLine("Cell click");

        var property = args.Column.Property;

        if (int.TryParse(property, out var columnNumber))
        {
            var i = columnNumber - 1;
            _selectedCell = args.Data.Cells[i];
            this.StateHasChanged();

            Console.WriteLine($"Select cell {_selectedCell}");
        }
    }

    private void OnCellRender(DataGridCellRenderEventArgs<SheetRow> args)
    {
        if (_selectedCell == null)
        {
            return;
        }
        
        var property = args.Column.Property;
        if (int.TryParse(property, out var columnNumber))
        {
            if (_selectedCell.Column == columnNumber && args.Data.RowNumber == _selectedCell.Row)
            {
                args.Attributes.Add("style", $"background-color: azure;");
            }
        }
    }

    private void OnKeyDown(KeyboardEventArgs e)
    {
        
    }

    private void OnInputKeyDown(KeyboardEventArgs e)
    {
        if (e.Code == "Enter")
        {
            if (_selectedCell != null)
            {
                var currentRow = _sheet[_selectedCell.Row - 1];
                var i = _selectedCell.Column;
                var nextCell = currentRow.Cells[i];

                _prevCell = _selectedCell;
                _selectedCell = nextCell;

            }
        }
    }

    private async Task OnValueChange(ChangeEventArgs e)
    {
        var inputValue = e.Value?.ToString();

        if (_prevCell == null 
            && _selectedCell != null)
        {
            _selectedCell.Text = inputValue;
        }

        if (_prevCell != null)
        {
            _prevCell.Text = inputValue;
            _prevCell = null;
        }
    }
}