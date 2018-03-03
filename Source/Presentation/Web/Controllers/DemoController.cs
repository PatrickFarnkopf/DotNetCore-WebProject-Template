using System;
using System.Drawing;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork.Design;
using Microsoft.AspNetCore.Mvc;
using Presentation.Linechart.Design;
using Presentation.Linechart.Generics.Linechart;
using Presentation.Linechart.Generics.Linechart.Model;

namespace Presentation.Web.Controllers
{
    [Route("api/[controller]")]
    public class DemoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DemoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ILinechartConfiguration<DateTime, int>> GetTestChart()
        {
            return new LinechartBuilder<DateTime, int>()
                .SetDimensions(1000, 400)
                .SetAxis(LinechartAxisType.AxisX, true, "X-Achse", true)
                .SetAxis(LinechartAxisType.AxisY, true, "Y-Achse", true)
                .SetWithGradient(true)
                .SetAutoScale(true)
                .SetShowLegend(true)
                .AddDataSet("Test Graph 1", Color.Red, new ILinechartDataRow<DateTime, int>[]
                {
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 1), Value = 5 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 2), Value = 11 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 3), Value = 13 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 4), Value = 17 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 5), Value = 14 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 6), Value = 15 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 7), Value = 24 }
                })
                .AddDataSet("Test Graph 2", Color.Green, new ILinechartDataRow<DateTime, int>[]
                {
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 1), Value = 20 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 2), Value = 10 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 3), Value = 14 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 4), Value = 11 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 5), Value = 18 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 6), Value = 26 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 7), Value = 22 },
                    new DataRow<DateTime, int> { Name = new DateTime(2018, 1, 8), Value = 30 }
                }).Build();
        }
    }
}