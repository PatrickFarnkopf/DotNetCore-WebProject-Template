using Presentation.Linechart.Design;

namespace Presentation.Linechart.Generics.Linechart.Model
{
    public class AxisLabel : ILinechartAxisLabel
    {
        public bool IsVisible { get; set; }
        public string Text { get; set; }
    }
}