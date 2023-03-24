using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using RadzenBlazorExperiments.Client.Models;
using RadzenBlazorExperiments.Shared.Models;

namespace RadzenBlazorExperiments.Client.Pages;

public partial class RightsPage: ComponentBase
{
    private RightsPageViewModel _model = new RightsPageViewModel();
    private RadzenDataGrid<RightsRow> _dataGrid;

    protected override void OnInitialized()
    {
        _model.Init(50);
    }

    private void OnAddClick()
    {
        var newName = $"Object {_model.Rights.Count + 1}";
        _model.AddRow(newName);

        _dataGrid.Reload();

    }
    
}