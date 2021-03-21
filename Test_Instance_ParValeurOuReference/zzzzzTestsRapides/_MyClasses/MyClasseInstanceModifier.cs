using System;
using System.Collections.Generic;
using System.Text;

namespace zzzzzTestsRapides._MyClasses
{
    class MyClasseInstanceModifier
    {
        public MyClasseInstanceModifier()
        {
        }

        public MyClasse changeInstance(MyClasse poMyClasse)
        {
            poMyClasse.a = 90;
            poMyClasse.b = 100;

            return (poMyClasse);
        }

        public MyClasse justReturnInstance(MyClasse poMyClasse)
        {
            return (poMyClasse);
        }

        public MyClasse returnACopyOfTheInstance(MyClasse poMyClasse)
        {
            MyClasse oCopy = new MyClasse(poMyClasse.a, poMyClasse.b);
            return (oCopy);
        }
    }
}
