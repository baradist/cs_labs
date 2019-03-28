using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4
{
    [Serializable]
    public class SaveContainer
    {
        public List<Word> Words { get; set; }
        public List<QuizResult> QuizResults { get; set; }
    }
}
