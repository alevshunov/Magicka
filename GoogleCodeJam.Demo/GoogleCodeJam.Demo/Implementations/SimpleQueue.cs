using System;
using System.Collections.Generic;
using System.Text;
using GoogleCodeJam.Demo.Interfaces;

namespace GoogleCodeJam.Demo.Implementations
{
    internal class SimpleQueue : ISimpleQueue
    {
        /// <summary>
        /// Count of each elements.
        /// </summary>
        private readonly int[] _available;

        /// <summary>
        /// Set of unique elements.
        /// </summary>
        private readonly HashSet<char> _history;

        /// <summary>
        /// Current queue state.
        /// </summary>
        private readonly StringBuilder _queue;

        /// <summary>
        /// Create new instance of SimpleQueue with default values.
        /// </summary>
        public SimpleQueue()
        {
            _available = new int[255];
            _history = new HashSet<char>();
            _queue = new StringBuilder();
        }

        /// <summary>
        /// Current queue state.
        /// </summary>
        public string Result
        {
            get { return _queue.ToString(); }
        }

        /// <summary>
        /// Current queue length.
        /// </summary>
        public int Length
        {
            get { return _queue.Length; }
        }

        /// <summary>
        /// Remove last element from the queue.
        /// </summary>
        public void RemoveElement()
        {
            var l = _queue.Length;
            var c = _queue[l - 1];
            _queue.Remove(l - 1, 1);
            _available[c]--;
            if (_available[c] == 0)
                _history.Remove(c);
        }

        /// <summary>
        /// Add new element to the end of the queue.
        /// </summary>
        /// <param name="element">Element that should be added.</param>
        public void AddElement(char element)
        {
            // append element to end of queue
            _queue.Append(element);

            // increase count of elements
            _available[element]++;

            // add element to unique set of elements
            if (_available[element] == 1)
                _history.Add(element);
        }

        /// <summary>
        /// Clear current queue state.
        /// </summary>
        public void Clear()
        {
            // clear queue.
            _queue.Clear();

            // clear element counters.
            Array.Clear(_available, 0, _available.Length);

            // clear unique elements set.
            _history.Clear();
        }

        /// <summary>
        /// Last queue element.
        /// </summary>
        public char LastItem
        {
            get { return _queue[_queue.Length - 1]; }
        }

        /// <summary>
        /// Two latest items in the queue.
        /// </summary>
        public char[] TwoLatestItems
        {
            get { return new[] { _queue[_queue.Length - 2], _queue[_queue.Length - 1] }; }
        }

        /// <summary>
        /// Unique elements that present in the queue.
        /// </summary>
        public IEnumerable<char> UniqueItems
        {
            get { return _history; }
        }

    }
}