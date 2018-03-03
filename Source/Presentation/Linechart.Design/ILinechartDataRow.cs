namespace Presentation.Linechart.Design
{
    public interface ILinechartDataRow<TX, TY>
    {
        TX Name { get; set; }
        TY Value { get; set; }
    }
}