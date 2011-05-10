namespace GoogleCodeJam.Demo.Interfaces
{
    internal interface IMagicQueueConfiguration
    {
        /// <summary>
        /// Checking for opposing.
        /// </summary>
        /// <param name="a">First element.</param>
        /// <param name="b">Second element.</param>
        /// <returns>True when these elements is opposed, or false when not.</returns>
        bool IsOpposed(char a, char b);

        /// <summary>
        /// Get combination rule. Zero when no combination is available.
        /// </summary>
        /// <param name="a">First element.</param>
        /// <param name="b">Second element.</param>
        /// <returns>Result of a combination of these elements.</returns>
        char GetCombine(char a, char b);
    }
}