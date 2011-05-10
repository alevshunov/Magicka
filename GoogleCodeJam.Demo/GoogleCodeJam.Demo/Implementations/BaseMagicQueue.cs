using GoogleCodeJam.Demo.Interfaces;

namespace GoogleCodeJam.Demo.Implementations
{
    /// <summary>
    /// Base magic queue.
    /// </summary>
    internal abstract class BaseMagicQueue : IMagicQueue
    {
        /// <summary>
        /// Result storage.
        /// </summary>
        protected ISimpleQueue Sq;

        /// <summary>
        /// Configuration provider.
        /// </summary>
        protected IMagicQueueConfiguration Qc;

        /// <summary>
        /// Create new instance nased on result storage and configuration provider.
        /// </summary>
        /// <param name="sq">Storage result.</param>
        /// <param name="qc">Configuration provider.</param>
        protected BaseMagicQueue(ISimpleQueue sq, IMagicQueueConfiguration qc)
        {
            Qc = qc;
            Sq = sq;
        }
        
        #region Abstract methods

        public abstract void Oppose();
        public abstract void Combine();

        #endregion

        /// <summary>
        /// Create new element and process comination and opposing.
        /// </summary>
        /// <param name="c">New element value</param>
        public void AddElement(char c)
        {
            Sq.AddElement(c);
            Combine();
            Oppose();
        }
    }
}