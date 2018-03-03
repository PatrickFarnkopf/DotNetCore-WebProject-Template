using Presentation.Linechart.Design;

namespace Presentation.Linechart.Generics.Linechart.Model
{
    public class DataSet<TX, TY> : ILinechartDataSet<TX, TY>
    {
        public string Name { get; set; }
        public ILinechartDataRow<TX, TY>[] Series { get; set; }
    }
}