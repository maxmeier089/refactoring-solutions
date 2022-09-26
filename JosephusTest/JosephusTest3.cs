using Josephus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JosephusTest
{
    public class JosephusTest3
    {

        [Test]
        public void JoesphusTest([Range(0, 99)] int n)
        {
            Assert.That(JosephusGood.GetSolution(n), Is.EqualTo(JosephusBad.GetSolution(n)));
        }


    }
}
