using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    [Serializable]
    public class Word
    {
        public enum Type
        {
            Noun, Verb, Adjective
        }

        public Word()
        {
        }

        public Word(Type type, string v1, params string[] translations) : this()
        {
            this.type = type;
            this.word = v1;
            this.translations = new List<string>(translations);
        }

        public Type type { set; get; }
        public string word { set; get; }
        public List<string> translations { set; get; }
        
        public override string ToString()
        {
            return word + ", " + type;
        }
    }
}
