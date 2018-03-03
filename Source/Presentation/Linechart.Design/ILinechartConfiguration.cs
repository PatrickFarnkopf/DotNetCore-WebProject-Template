namespace Presentation.Linechart.Design
{
    public interface ILinechartConfiguration<TX, TY>
    {
        IChartDimensions Dimensions { get; set; }
        ILinechartAxis AxisX { get; set; }
        ILinechartAxis AxisY { get; set; }
        ILinechartColorScheme ColorScheme { get; set; }
        bool AutoScale { get; set; }
        bool ShowLegend { get; set; }
        bool WithGradient { get; set; }
        ILinechartDataSet<TX, TY>[] Data { get; set; }
    }
}