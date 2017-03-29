using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Enter a string of text. This text will be searched on the MSDN");
            Console.Out.WriteLine("Enter \"STOP\" to exit");
            string input = Console.In.ReadLine();
            while (input != "STOP")
            {
                List<char> c = new List<char>(input.ToCharArray());

                List<string> s = new List<string>(c.Capacity);

                for (int i = 0; i < c.Capacity; i++)
                {
                    if (c[i] == ' ') c[i] = '+';
                    s.Add("" + c[i]);
                }

                input = "";

                for (int i = 0; i < s.Count; i++)
                {
                    if (@"!@#$%^&*()=[]/:\,.;'`~".Contains(s[i]))
                    {
                        s.Insert(i, "%" + ((int)c[i]).ToString("X"));
                        if(i != s.Capacity - 1) s.RemoveAt(i+1);
                    }
                    input += s[i];
                }

                System.Diagnostics.Process.Start("https://social.msdn.microsoft.com/search/en-US?query=" + input);

                input = Console.In.ReadLine();
            }
        }
    }
}
