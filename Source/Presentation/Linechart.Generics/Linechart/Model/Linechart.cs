using Presentation.Linechart.Design;

namespace Presentation.Linechart.Generics.Linechart.Model
{
    public class Linechart<TX, TY> : ILinechartConfiguration<TX, TY>
    {
        public IChartDimensions Dimensions { get; set; }
        public ILinechartAxis AxisX { get; set; }
        public ILinechartAxis AxisY { get; set; }
        public ILinechartColorScheme ColorScheme { get; set; }
        public ILinechartDataSet<TX, TY>[] Data { get; set; }
        public bool AutoScale { get; set; }
        public bool ShowLegend { get; set; }
        public bool WithGradient { get; set; }
    }
}