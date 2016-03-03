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
            sort(input, 0);
        }

        private void swap(char[] nums, int i, int j)
        {
            char tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
        public void sort(char[] A, int lev)
        {
            if (A.Length < 2 || lev == A.Length - 1)
                return;

            sort(A, lev + 1);
            if (A[lev] > A[lev + 1])
            {
                swap(A, lev, lev + 1);
                sort(A, lev + 1);
            };
        }

    }
}
