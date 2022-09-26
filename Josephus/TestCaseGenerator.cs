using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josephus
{
    internal class TestCaseGenerator
    {

        internal static void GenerateParameterizedTests(int numberOfTestCases)
        {
            for (int n=0; n< numberOfTestCases; n++)
            {
                Console.WriteLine(String.Format("[TestCase({0}, {1})]", n, JosephusBad.GetSolution(n)));
            }

        }

        internal static void GenerateTestCaseSource(int numberOfTestCases)
        {
            for (int n = 0; n < numberOfTestCases; n++)
            {
                Console.WriteLine(String.Format("new object[]{{ {0}, {1} }}{2}", n, JosephusBad.GetSolution(n), (n < numberOfTestCases - 1) ? "," : ""));
            }
        }

    }
}
