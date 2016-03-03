using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherQuestions.Questions.Q3
{
    public class Solution
    {
        public void SortWithoutLoop(char[] input)
        {
            int len = input.Length;

            SortFun(input, 0, 1, len);
        }

        private void SortFun(char[] arr, int low, int high, int len)
        {
            if (low >= len)
            {
                return;
            }
            else if (high >= len)
            {
                SortFun(arr, low + 1, low + 2, len);
            }
            else
            {
                if (arr[low] > arr[high])
                {
                    char c = arr[low];
                    arr[low] = arr[high];
                    arr[high] = c;
                }

                SortFun(arr, low, high + 1, len);
            }
        }
    }
}
