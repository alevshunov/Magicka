using GoogleCodeJam.Demo.Interfaces;

namespace GoogleCodeJam.Demo.Implementations
{
    /// <summary>
    /// Magic queue with Oppose and Combine implementation.
    /// </summary>
    internal class MagicQueue : BaseMagicQueue
    {
        /// <summary>
        /// Create new instance nased on result storage and configuration provider.
        /// </summary>
        /// <param name="sq">Storage result.</param>
        /// <param name="qc">Configuration provider.</param>
        public MagicQueue(ISimpleQueue sq, IMagicQueueConfiguration qc) : base(sq, qc)
        {
        }

        /// <summary>
        /// Oppose queue.
        /// </summary>
        public override void Oppose()
        {
            if (Sq.Length < 2)
                return;

            var c = Sq.LastItem;
            foreach (char item in Sq.UniqueItems)
            {
                if (Qc.IsOpposed(item, c))
                {
                    Sq.Clear();

                    return;
                }
            }
        }

        /// <summary>
        /// Combine queue.
        /// </summary>
        public override void Combine()
        {
            if (Sq.Length < 2)
                return;

            char[] items = Sq.TwoLatestItems;

            var t = Qc.GetCombine(items[0], items[1]);
            if (t != 0)
            {
                Sq.RemoveElement();
                Sq.RemoveElement();
                Sq.AddElement(t);
            }
        }

    }
}