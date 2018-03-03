using Presentation.Linechart.Design;

namespace Presentation.Linechart.Generics.Linechart.Model
{
    public class Axis : ILinechartAxis
    {
        public bool IsVisible { get; set; }
        public ILinechartAxisLabel Label { get; set; }
    }
}