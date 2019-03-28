using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4
{
    [Serializable]
    public struct QuizResult
    {
        public int Fails { get; set; }
        public int Questions { get; set; }

        public override string ToString()
        {
            return "Fails: " + Fails + " of " + Questions;
        }
    }
}
