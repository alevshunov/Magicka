using System.Collections.Generic;
using GoogleCodeJam.Demo.BuilderDemo.Builders;

namespace GoogleCodeJam.Demo.BuilderDemo
{
    class Source
    {
        public void ReportButtonClick()
        {
            // Пользователь кликнул по кнопке генерации отчета.

            // Создаем построитель
            IReportBuilder builder = new TextReportBuilder();

            // Директора
            Director director = new Director(builder);

            // Строим отчет
            director.BuildGlobalReport("KudInc", GetFullReport());

            // Получаем отчет.
            string result = builder.GetResult();
        }

        private List<IReportData> GetFullReport()
        {
            var result = new List<IReportData>();


            return result;
        }
    }
}
