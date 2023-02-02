using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTest.DesignPattern
{
    public class Singleton
    {

        public static void Test()
        {
            //测试方法体
            Console.WriteLine("---------- SingletonTest ----------");
            string? cmd;
            while ((cmd = Console.ReadLine()) != "q")
            {
                if(cmd == "get")
                {
                    Console.WriteLine(Singleton.getInstance().GetHashCode());
                }
            }
        }

        private static Singleton singleton = new Singleton();

        private Singleton() { }

        public static Singleton getInstance()
        {
            return singleton;
        }
    }
}
