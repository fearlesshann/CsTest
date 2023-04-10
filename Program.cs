using CsTest.AsyncAwait;
using CsTest.DesignPattern;
using CsTest.DI;
using CsTest.Linq;
using MyConsole;
using System.Drawing;
using System.Reflection;

string? cmd = "";
Console.WriteLine("Welcome to MyTestConsole!");
while (cmd != "q")
{
    Console.WriteLine("Please enter cmd:(q to quit，h for help)");
    cmd = Console.ReadLine();
    if (cmd == "q")
    {
        return;
    }
    if (cmd == "h")
    {
        MyTestConsole.Help();
        continue;
    }
    //进行测试
    MyTestConsole.ExcuteCmd(cmd);
}

namespace MyConsole
{
    public class MyTestConsole
    {
        //存放cmd和测试类的映射
        static Dictionary<string, Type> cmdMap = new Dictionary<string, Type>()
        {
            {"asy", typeof(AsyncAwaitTest)},
            {"lin", typeof(LinqTest)},
            {"sin", typeof(Singleton)},
            {"di", typeof(DITest)},
        };

        //输出测试项列表
        public static void Help()
        {
            Console.WriteLine("---------- cmd list ----------");
            Console.WriteLine();
            var enumerator = cmdMap.GetEnumerator();
            var i = 1;
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"{i++}.Enter \"{enumerator.Current.Key}\" to excute {enumerator.Current.Value.Name}");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------");
        }

        //执行测试
        public static void ExcuteCmd(string? cmd)
        {
            if (string.IsNullOrEmpty(cmd))
            {
                Console.WriteLine("cmd is empty...");
                return;
            }
            //测试方法
            Type? type = cmdMap.GetValueOrDefault(cmd);
            if (type != null)
            {
                MethodInfo? method = type.GetMethod("Test");
                if (method != null)
                {
                    try
                    {
                        method.Invoke(type, null);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
                else
                {
                    Console.WriteLine("get method faild!");
                }
            }
            else
            {
                Console.WriteLine($"can't find cmd \"{cmd}\" !");
            }
        }
    }
}
