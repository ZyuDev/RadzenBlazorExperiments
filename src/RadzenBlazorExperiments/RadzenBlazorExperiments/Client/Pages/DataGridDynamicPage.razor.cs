using Microsoft.AspNetCore.Components;

namespace RadzenBlazorExperiments.Client.Pages
{
    public partial class DataGridDynamicPage : ComponentBase
    {
        private List<IDictionary<string, object>> _data { get; set; } = new List<IDictionary<string, object>>();
        private IDictionary<string, Type> _columns { get; set; } = new Dictionary<string, Type>();

        protected override async Task OnInitializedAsync()
        {
            _columns = new Dictionary<string, Type>(){
            { "PropName", typeof(string) },
            { "Value1", typeof(string) },
            { "Value2", typeof(string) }
            };

            _data = new List<IDictionary<string, object>>();

            for(var i = 0; i <= 100; i++)
            {
                var newRow = new Dictionary<string, object>();
                newRow.Add("PropName", $"Prop {i}");
                newRow.Add("Value1", $"Value 1.{i}");
                newRow.Add("Value2", $"Value 2.{i}");

                _data.Add(newRow);
            }
        }

        public string GetColumnPropertyExpression(string name)
        {
            var expression = $@"it[""{name}""].ToString()";
            return expression;
        }
    }
}
