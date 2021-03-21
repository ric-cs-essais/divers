using System;
using System.Collections.Generic;
using System.Text;

namespace zzzzzTestsRapides._MyClasses
{
    class MyClasse
    {
        public int a, b;

        public MyClasse(int pa, int pb)
        {
            this.a = pa;
            this.b = pb;
        }

        private int _getSum()
        {
            return (this.a+this.b);
        }

        public string toString()
        {
            string s = "a=" + this.a +"  ;  b="+this.b+"   ; SUM="+this._getSum();
            return (s);
        }

        public void show()
        {
            Console.WriteLine(this.toString());
        }


    }
}
