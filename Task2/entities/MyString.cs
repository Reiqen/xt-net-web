using System;

namespace com.GitHub.Reiqen.Task2.entities
{
    class MyString
    {
        public string First { get; set; }
        public string Second { get; set; }
        public char Ch { get; set; }

        private char[] ConvertToChar(string str)
        {
            char[] chars = str.ToCharArray();
            return chars;
        }
        private string ConvertToString(char[] chars)
        {
            var str = new String(chars);
            return str;
        }

        private bool IsSame(char[] firstChars, char[] secondChars)
        {
            var b = true;
            if (firstChars.Length != secondChars.Length) b = false;
            else
            {
                for (var i = 0; i < firstChars.Length; i++)
                {
                    if (firstChars[i] != secondChars[i]) b = false;
                }
            }
            return b;
        }

        private char[] Concat(char[] firstChars, char[] secondChars)
        {
            var concated = new char[firstChars.Length + secondChars.Length];
            for (var i = 0; i < firstChars.Length; i++) concated[i] = firstChars[i];   
            for (var j = firstChars.Length; j < firstChars.Length + secondChars.Length; j++) concated[j] = secondChars[j - firstChars.Length];
            return concated;
        }

        private string[] Search(char[] firstChars, char[] secondChars, char singleChar)
        {
            var i = new string[2];
            for (var j = 0; j < firstChars.Length; j++)
            {
                if (firstChars[j] == singleChar)
                {
                    i[0] = "первое совпадение в позиции " + (j + 1) + " строки 1";
                    break;
                }
                else i[0] = "нет символа в строке 1";
            }
            for (var k = 0; k < secondChars.Length; k++)
            {
                if (secondChars[k] == singleChar)
                {
                    i[1] = "первое совпадение в позиции " + (k + 1) + " строки 2";
                    break;
                }
                else i[1] = "нет символа в строке 2";
            }
            return i;
        }

        public override string ToString()
        {
            string info = string.Format("Равны ли строки - {0}, общая строка - {1}," +
                                        " позиция символа в первой и второй строках соответственно: {2}",
                                        IsSame(ConvertToChar(First), ConvertToChar(Second)),
                                        ConvertToString(Concat(ConvertToChar(First), ConvertToChar(Second))),
                                        string.Join(", ", Search(ConvertToChar(First), ConvertToChar(Second), Ch))) ;
            return info;
        }
    }
}