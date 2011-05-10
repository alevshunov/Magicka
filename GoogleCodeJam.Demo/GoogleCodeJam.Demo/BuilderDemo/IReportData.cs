namespace GoogleCodeJam.Demo.BuilderDemo
{
    /// <summary>
    /// Данные для отчета
    /// </summary>
    internal interface IReportData
    {
        /// <summary>
        /// Отчетный период
        /// </summary>
        int Year { get; }

        /// <summary>
        /// Доход компании
        /// </summary>
        decimal Profit { get; }
    }
}