using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherQuestions.Questions.Q1
{
    public class Solution
    {
        public string[,] FindAllPalindromePair(string[] dicts)
        {
            List<string> result = new List<string>();

            SegmentNode suffixNode = new SegmentNode();
            int tL = dicts.Length;
            for (int j = 0; j < tL; j++)
            {
                string s = dicts[j];
                int len = s.Length;
                SegmentNode n2 = suffixNode;
                for (int i = 0; i < len; i++)
                {
                    if (n2.Children[s[len - 1 - i] - 'a'] == null)
                    {
                        n2.Children[s[len - 1 - i] - 'a'] = new SegmentNode();
                    }

                    n2 = n2.Children[s[len - 1 - i] - 'a'];
                }

                n2.IsWord = true;
                n2.Index = j;
            }

            bool[,] visited = new bool[tL, tL];

            for (int j = 0; j < tL; j++)
            {
                string s = dicts[j];

                SegmentNode n = suffixNode;
                bool found = true;
                foreach (char c in s)
                {
                    if (n.Children[c - 'a'] == null)
                    {
                        found = false;
                        break;
                    }

                    n = n.Children[c - 'a'];
                }

                if (!found)
                {
                    continue;
                }

                List<int> subResult = new List<int>();

                if (n.RemainPanilList == null)
                {
                    FinAllChildrenPalindrome(n, "", subResult);
                    n.RemainPanilList = subResult;
                }
                else
                {
                    subResult = n.RemainPanilList;
                }


                foreach (var item in subResult)
                {
                    if (j != item && !visited[item, j] && !visited[j, item])
                    {
                        visited[j, item] = true;

                        result.Add(dicts[j] + "," + dicts[item]);
                    }

                }
            }

            int totalLen = result.Count;

            string[,] r1 = new string[totalLen, 2];

            for (int i = 0; i < totalLen; i++)
            {
                string[] splits = result[i].Split(new char[] { ',' });
                r1[i, 0] = splits[0];
                r1[i, 1] = splits[1];
            }

            return r1;
        }

        private void FinAllChildrenPalindrome(SegmentNode node, string s, List<int> result)
        {
            if (node.IsWord && isPalindrome(s))
            {
                result.Add(node.Index);
            }

            foreach (var item in node.Children)
            {
                if (item != null)
                {
                    FinAllChildrenPalindrome(item, s + item.Val, result);
                }
            }
        }

        private bool isPalindrome(string s)
        {
            int low = 0;
            int high = s.Length - 1;
            while (low < high)
            {
                if (s[low] != s[high])
                {
                    return false;
                }
                low++;
                high--;
            }

            return true;
        }


        public class SegmentNode
        {
            private SegmentNode[] _children = new SegmentNode[26];

            public char Val { get; set; }

            public SegmentNode[] Children { get { return _children; } }

            public bool IsWord { get; set; }

            public int Index { get; set; }

            public List<int> RemainPanilList { get; set; }
        }
    }

    public class SegmentNode
    {
        public SegmentNode(int _maxIndex, int _minIndex, int _value)
        {
            MaxIndex = _maxIndex;
            MinIndex = _minIndex;
            Value = _value;
        }

        public int MaxIndex { get; set; }
        public int MinIndex { get; set; }
        public int Value { get; set; }
        public SegmentNode Left { get; set; }
        public SegmentNode Right { get; set; }
    }
}
