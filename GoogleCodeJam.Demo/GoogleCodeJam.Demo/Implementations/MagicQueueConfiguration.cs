using GoogleCodeJam.Demo.Interfaces;

namespace GoogleCodeJam.Demo.Implementations
{
    internal class MagicQueueConfiguration : IMagicQueueConfiguration
    {
        /// <summary>
        /// Combination matrix.
        /// </summary>
        protected readonly char[,] Combine = new char[255, 255];

        /// <summary>
        /// Opposed matrix.
        /// </summary>
        protected readonly bool[,] Opposed = new bool[255, 255];

        /// <summary>
        /// Create new combination rule.
        /// </summary>
        /// <param name="a">First element.</param>
        /// <param name="b">Second element.</param>
        /// <param name="result">Combination result.</param>
        public void AddCombine(char a, char b, char result)
        {
            Combine[a, b] = result;
            Combine[b, a] = result;
        }

        /// <summary>
        /// Create new opposing rule.
        /// </summary>
        /// <param name="a">First element.</param>
        /// <param name="b">Second element.</param>
        public void AddOpposed(char a, char b)
        {
            Opposed[a, b] = true;
            Opposed[b, a] = true;
        }

        /// <summary>
        /// Checking for opposing.
        /// </summary>
        /// <param name="a">First element.</param>
        /// <param name="b">Second element.</param>
        /// <returns>True when these elements is opposed, or false when not.</returns>
        public bool IsOpposed(char a, char b)
        {
            return Opposed[a, b];
        }

        /// <summary>
        /// Get combination rule. Zero when no combination is available.
        /// </summary>
        /// <param name="a">First element.</param>
        /// <param name="b">Second element.</param>
        /// <returns>Result of a combination of these elements.</returns>
        public char GetCombine(char a, char b)
        {
            return Combine[a, b];
        }
    }
}