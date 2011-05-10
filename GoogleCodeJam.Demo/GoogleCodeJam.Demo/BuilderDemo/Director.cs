using System.Collections.Generic;
using GoogleCodeJam.Demo.BuilderDemo.Builders;

namespace GoogleCodeJam.Demo.BuilderDemo
{
    /// <summary>
    /// Директор
    /// </summary>
    class Director
    {
        private readonly IReportBuilder _builder;

        /// <summary>
        /// Создание директора на основе построителя
        /// </summary>
        /// <param name="builder">Построитель</param>
        public Director(IReportBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Постройка отчета
        /// </summary>
        /// <param name="companyName">Имя компании</param>
        /// <param name="data">Данные для отчета</param>
        public void BuildGlobalReport(string companyName, List<IReportData> data)
        {
            // Строим отчет не зависимо от конкретной реализации построителя отчетов.

            _builder.BuildHeader(companyName);
            _builder.BuildData(data);
            _builder.BuildChart(data);
        }
    }
}