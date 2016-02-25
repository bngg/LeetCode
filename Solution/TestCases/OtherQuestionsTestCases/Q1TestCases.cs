using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCases.OtherQuestionsTestCases
{
    [TestClass]
    public class Q1TestCases
    {
        [TestMethod]
        public void Q1TestCase1()
        {
            OtherQuestions.Questions.Q1.Solution solution = new OtherQuestions.Questions.Q1.Solution();

            string[] inputs = new string[] { "abcd", "dcba", "lls", "s", "sssll" };

            string[,] outPut =  solution.FindAllPalindromePair(inputs);

            string[,] expectOutPut = new string[3, 2];
        }
    }
}
