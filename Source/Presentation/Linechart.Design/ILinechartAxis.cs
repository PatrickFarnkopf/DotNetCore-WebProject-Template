namespace Presentation.Linechart.Design
{
    public interface ILinechartAxis
    {
        bool IsVisible { get; set; }
        ILinechartAxisLabel Label { get; set; }
    }
}