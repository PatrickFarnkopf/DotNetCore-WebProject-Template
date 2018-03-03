using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Presentation.Linechart.Design;
using Presentation.Linechart.Generics.Linechart.Model;

namespace Presentation.Linechart.Generics.Linechart
{
    public enum LinechartAxisType
    {
        AxisX, AxisY
    }
    
    public class LinechartBuilder<TX, TY>
    {
        private readonly ILinechartConfiguration<TX, TY> _chart;
        private readonly List<ILinechartDataSet<TX, TY>> _dataSets;
        private readonly List<Color> _colors;
        
        public LinechartBuilder(ILinechartConfiguration<TX, TY> chart)
        {
            _chart = chart;
            _dataSets = new List<ILinechartDataSet<TX, TY>>();
            _colors = new List<Color>();
        }
        
        public LinechartBuilder() : this(new Linechart<TX, TY>()) { }

        public LinechartBuilder<TX, TY> SetDimensions(int width, int height)
        {
            _chart.Dimensions = new Dimensions { Width = width, Height = height };
            return this;
        }

        public LinechartBuilder<TX, TY> SetAxis(LinechartAxisType type, bool isVisible, string labelText, bool isLabelVisible)
        {
            switch (type)
            {
                case LinechartAxisType.AxisX:
                    _chart.AxisX = GetAxis(isVisible, labelText, isLabelVisible);
                    break;
                case LinechartAxisType.AxisY:
                    _chart.AxisY = GetAxis(isVisible, labelText, isLabelVisible);
                    break;
                default:
                    throw new InvalidOperationException("axis type not supported!");
            }

            return this;
        }
        
        public ILinechartAxis GetAxis(bool isVisible, string labelText, bool isLabelVisible)
        {
            return new Axis
            {
                IsVisible = isVisible,
                Label = new AxisLabel
                {
                    Text = labelText,
                    IsVisible = isLabelVisible
                }
            };
        }

        public LinechartBuilder<TX, TY> AddDataSet(string name, Color color, ILinechartDataRow<TX, TY>[] data)
        {
            _dataSets.Add(new DataSet<TX, TY>()
            {
                Name = name,
                Series = data
            });
            
            _colors.Add(color);

            return this;
        }

        public LinechartBuilder<TX, TY> SetShowLegend(bool isVisible)
        {
            _chart.ShowLegend = isVisible;
            return this;
        }

        public LinechartBuilder<TX, TY> SetAutoScale(bool autoscale)
        {
            _chart.AutoScale = autoscale;
            return this;
        }

        public LinechartBuilder<TX, TY> SetWithGradient(bool withGradient)
        {
            _chart.WithGradient = withGradient;
            return this;
        }

        public ILinechartConfiguration<TX, TY> Build()
        {
            _chart.Data = _dataSets.ToArray();
            _chart.ColorScheme = new ColorScheme()
            {
                Domain = _colors.Select(x => $"#{x.R.ToString("X2")}{x.G.ToString("X2")}{x.B.ToString("X2")}").ToArray()
            };
            return _chart;
        }
    }
}