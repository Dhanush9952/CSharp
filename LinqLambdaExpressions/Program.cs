using System;
using System.Linq;
using System.Web.Providers.Entities;

namespace LinqLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] { "falcon", "tree", "water", "bird", "sky" };
            var res = from w in words
                      where w.Contains('a')
                      select w;
            foreach (var w in res)
            {
                Console.WriteLine(w);
            }
            Console.WriteLine("-----------------");
            var res2 = words.Where(v => v.Contains('a'));
            foreach(var v in words)
            {
                Console.WriteLine(v);
            }
        }
    }
}
