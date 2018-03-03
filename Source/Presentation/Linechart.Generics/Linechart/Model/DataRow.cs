using Presentation.Linechart.Design;

namespace Presentation.Linechart.Generics.Linechart.Model
{
    public class DataRow<TX, TY> : ILinechartDataRow<TX, TY>
    {
        public TX Name { get; set; }
        public TY Value { get; set; }
    }
}