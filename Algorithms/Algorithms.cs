using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0) {
                throw new ArgumentException("n must be greater than 0");
            }
            if (n == 0 || n == 1) {
                return 1;
            } else if (n > 12){
                throw new OverflowException("int overflowed");
            } else {
                return n * GetFactorial(n - 1);
            }
        }

        public static string FormatSeparators(params string[] items)
        {
            var nitems = items.Where(i => i.Length > 0).ToArray();
            string s = "";
            if (nitems.Length == 0) {
                return "";
            } else {
                s = nitems[0];
                for (int i=1; i<nitems.Length-1; i++) {
                    s += ", " + items[i];
                }
                if(nitems.Length > 1) {
                    s += " and " + nitems[nitems.Length-1];
                }
            }
            return s;
        }
    }
}