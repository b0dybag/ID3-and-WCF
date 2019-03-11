using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PClient
{
    class Parsing
    {
            public List<string> LineParsing(string line)
            {
                string word = "";
                bool isWord = false;
                List<string> result = new List<string>();
                foreach (var item in line)
                {
                    if (item != ' ')
                    {
                        isWord = true;
                        word += item.ToString();
                    }
                    else if (isWord)
                    {
                        isWord = false;
                        result.Add(word);
                        word = "";
                    }
                }
                return result;
            }

            public int GetDecisionPos(string[] text)
            {
                int bodyStart = 0;
                int decisionPos = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].IndexOf("<") != -1)
                    {
                        bodyStart = i;
                        break;
                    }
                }
                foreach (var item in text[bodyStart])
                {
                    if (item == 's') decisionPos++;
                    if (item == 'd') break;
                }
                return decisionPos;
            }

            public List<string> GetHead(string[] text)
            {
                bool isHead = false;
                string headText = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].IndexOf("[") != -1) isHead = true;
                    if (isHead) headText += " " + text[i];
                    if (text[i].IndexOf("]") != -1)
                    {
                        headText = headText.Remove(headText.IndexOf('['), 1);
                        headText = headText.Remove(headText.IndexOf(']'), 1);
                        break;
                    }
                }
                return LineParsing(headText);
            }

            public List<List<string>> GetBody(string[] text)
            {
                int bodyStart = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].IndexOf("]") != -1) { bodyStart = ++i; break; }
                }
                List<List<string>> result = new List<List<string>>();

                for (int i = bodyStart; i < text.Length; i++)
                {
                    if (text[i].Length > 3) result.Add(LineParsing(text[i]));
                }
                return result;
            }
        
        }
}
