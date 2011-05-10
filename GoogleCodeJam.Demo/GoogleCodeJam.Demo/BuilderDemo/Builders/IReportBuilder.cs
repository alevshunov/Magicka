using System.Collections.Generic;

namespace GoogleCodeJam.Demo.BuilderDemo.Builders
{
    /// <summary>
    /// Интерфейс построителя
    /// </summary>
    interface IReportBuilder
    {
        void BuildHeader(string companyName);
        void BuildData(List<IReportData> data);
        void BuildChart(List<IReportData> chartData);
        string GetResult();
    }
}