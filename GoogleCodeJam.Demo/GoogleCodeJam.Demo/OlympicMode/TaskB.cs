using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleCodeJam.Demo.OlympicMode
{
    class TaskB
    {
        static string[] _result;

        public static void Main2(string[] args)
        {
            using (var r = new StreamReader("input.txt"))
            using (var w = new StreamWriter("output.txt"))
            {
                int n = Int32.Parse(r.ReadLine());
                _result = new string[n];
                var bg = new Task[n];
                for (int i=0;i<n;i++)
                {
                    var t = new TaskB(r, i);
                    var task = Task.Factory.StartNew(t.Solve);
                    bg[i] = task;
                }

                Task.WaitAll(bg);

                for (int i=0;i<n;i++)
                {
                    if (i > 0)
                        w.WriteLine();
                        w.Write("Case #" + (i+1) + ": [" + String.Join(", ", _result[i].ToCharArray()) + "]");
                }
            }
        }

        private int _num;

        Dictionary<char, Dictionary<char, char>> _combine = new Dictionary<char, Dictionary<char, char>>();
        Dictionary<char, HashSet<char>> _opposed = new Dictionary<char, HashSet<char>>();
        private string _query;

        private TaskB(StreamReader r, int num)
        {
            _num = num;

            var line = r.ReadLine().Split(' ');
            int i = 0;
            int k = Int32.Parse(line[i++]);
            
            for (int j=0;j<k;j++)
            {
                var tmp = line[i++];
                
                if (!_combine.ContainsKey(tmp[0]))
                    _combine[tmp[0]] = new Dictionary<char, char>();
                if (!_combine.ContainsKey(tmp[1]))
                    _combine[tmp[1]] = new Dictionary<char, char>();

                _combine[tmp[0]][tmp[1]] = tmp[2];
                _combine[tmp[1]][tmp[0]] = tmp[2];
            }

            k = Int32.Parse(line[i++]);
            for (int j=0; j<k; j++)
            {
                var tmp = line[i++];
                if (!_opposed.ContainsKey(tmp[0]))
                    _opposed[tmp[0]] = new HashSet<char>();
                if (!_opposed.ContainsKey(tmp[1]))
                    _opposed[tmp[1]] = new HashSet<char>();

                _opposed[tmp[0]].Add(tmp[1]);
                _opposed[tmp[1]].Add(tmp[0]);
            }
            _query = line[++i];
        }

        private void Solve()
        {
            string res = string.Empty;
            var e = new Dictionary<char, int>();

            int i = 0;
            char last = '#';
            while (i<_query.Length)
            {
                char next = _query[i];
                if (last != '#')
                {
                    if (_combine.ContainsKey(next)
                        && _combine[next].ContainsKey(last))
                    {
                        next = _combine[next][last];
                        res = res.Remove(res.Length - 1);

                        e[last]--;
                        if (e[last] == 0)
                            e.Remove(last);
                    }

                    bool doClear = false;
                    var t = e.Keys.ToArray();
                    for (int j = 0; j < t.Length; j++)
                    {
                        if (_opposed.ContainsKey(next)
                            && _opposed[next].Contains(t[j]))
                        {
                            doClear = true;
                            break;
                        }
                    }

                    if (doClear)
                    {
                        res = string.Empty;
                        e.Clear();
                        next = '#';
                        last = next;
                        i++;
                        continue;
                    }
                }

                res += next;
                if (!e.ContainsKey(next))
                    e[next] = 1;
                else
                    e[next]++;

                last = next;
                i++;
            }

            _result[_num] = res;
        }
    }
}
