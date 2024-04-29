using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Individual_work
{
    public partial class ChartForm : Form
    {
        //наименования продуктов и соответствующий данные для них
        public List<string> productsNamesChecked;
        public List<Tuple<DateTime, string, int>> resultData;

        public ChartForm(List<string> productsNamesChecked, List<Tuple<DateTime, string, int>> resultData)
        {
            /*
             Функция-конструктор, которая формирует график
             */

            InitializeComponent();
            this.productsNamesChecked = productsNamesChecked;
            this.resultData = resultData;
            this.chart.Series.Clear();

            //добавляем данные на график
            foreach (string productName in productsNamesChecked)
            {
                this.chart.Series.Add(productName);
                this.chart.Series[productName].ChartType = SeriesChartType.Column;
                //фильтруем данные по названию товара
                var filteredData = this.resultData.Where(data => data.Item2 == productName);
                //добавляем точки на график
                foreach (var data in filteredData)
                {
                    this.chart.Series[productName].Points.AddXY(data.Item1, data.Item3);
                    this.chart.Series[productName].Points.Last().AxisLabel = data.Item1.ToShortDateString();
                    this.chart.Series[productName].CustomProperties = "PixelPointWidth=30";
                }
            }
            this.chart.ChartAreas[0].AxisX.Interval = 1;
            this.chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            this.chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.YYYY";
            this.chart.ChartAreas[0].AxisY.Interval = 1000;
        }
    }
}
