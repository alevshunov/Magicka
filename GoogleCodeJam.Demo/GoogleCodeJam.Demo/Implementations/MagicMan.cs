using GoogleCodeJam.Demo.Interfaces;

namespace GoogleCodeJam.Demo.Implementations
{
    internal class MagicMan : IMagicMan
    {
        private readonly IMagicQueue _q;

        public MagicMan(IMagicQueue q)
        {
            _q = q;
        }

        public void InvokeElements(string items)
        {
            foreach (var c in items)
            {
                _q.AddElement(c);
            }
        }
    }
}