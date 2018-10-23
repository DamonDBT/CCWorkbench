using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace CCWorkbench.Server
{
    public class ReflectFactory
    {
        public void das<T>()
        {
            test t1 = new test();
            t1.Add(add1);

        }
        public int add1(int a, int b)
        {
            return a - b;
        }


    }

    public delegate int del(int a, int b);
    public abstract class Method
    {
        public int a;
        public int b;
        public int Add(del t) { return t(a, b); }

    }
    public class test : Method
    {

    }



}