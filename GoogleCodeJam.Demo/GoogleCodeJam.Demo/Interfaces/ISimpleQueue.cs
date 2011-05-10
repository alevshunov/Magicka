using System.Collections.Generic;

namespace GoogleCodeJam.Demo.Interfaces
{
    internal interface ISimpleQueue
    {
        void AddElement(char element);
        void RemoveElement();
        void Clear();

        int Length { get; }
        string Result { get; }

        char LastItem { get; }
        char[] TwoLatestItems { get; }
        IEnumerable<char> UniqueItems { get; }
    }
}

