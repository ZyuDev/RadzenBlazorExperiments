using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using RadzenBlazorExperiments.Shared.Models;

namespace RadzenBlazorExperiments.Client.Pages;

public partial class RightsPageWithoutModelPage:ComponentBase
{
    private RadzenDataGrid<RightsRow> _dataGrid;
    private List<RightsRow> _rights = new List<RightsRow>();

    protected override void OnInitialized()
    {
        AddRow();
        AddRow();
        AddRow();
    }

    private void OnAddClick()
    {
        AddRow();
        _dataGrid.Reload();
    }

    private void AddRow()
    {
        var newName = $"Object {_rights.Count + 1}";
        var newRow = new RightsRow()
        {
            ObjectName = newName
        };

        _rights.Add(newRow);
    }
}