using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleCodeJam.Demo.BuilderDemo.Builders
{
    /// <summary>
    /// Реализация построителя текстового отчета
    /// </summary>
    internal class TextReportBuilder : IReportBuilder
    {
        private readonly StringBuilder _result = new StringBuilder();

        public void BuildHeader(string companyName)
        {
            _result.AppendFormat("Report for {0}\n", companyName);
        }

        public void BuildData(List<IReportData> data)
        {
            foreach (var reportData in data)
            {
                _result.AppendFormat("Year {0}, profit: ${1}\n", reportData.Year, reportData.Profit);
            }
        }

        public void BuildChart(List<IReportData> chartData)
        {
            _result.AppendFormat("Generated time:" + DateTime.Now);
        }

        public string GetResult()
        {
            return _result.ToString();
        }
    }
}