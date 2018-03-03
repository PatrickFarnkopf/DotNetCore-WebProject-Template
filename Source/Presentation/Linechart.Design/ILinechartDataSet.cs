namespace Presentation.Linechart.Design
{
    public interface ILinechartDataSet<TX, TY>
    {
        string Name { get; set; }
        ILinechartDataRow<TX, TY>[] Series { get; set; }
    }
}