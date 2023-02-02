using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTest.AsyncAwait
{
    public class AsyncAwaitTest
    {
        public static async void Test()
        {

            //测试方法体
            Console.WriteLine("---------- AsyncAwaitTest ----------");
            string? cmd;
            while ((cmd = Console.ReadLine()) != "q")
            {
                Console.WriteLine("开始下载...");
                using(HttpClient client = new HttpClient())
                {
                    string ss = await client.GetStringAsync("https://www.baidu.com");
                    for(int i = 0; i < ss.Length - 60; i += 60)
                    {
                        Console.WriteLine(ss.Substring(i,60));
                        await Task.Delay(500);
                    }
                }
            }
        }

        public static async void ThreePeopleWork(string a, string b, string c)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => { Work(a); }));
            tasks.Add(Task.Run(() => { Work(b); }));
            tasks.Add(Task.Run(() => { Work(c); }));
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.WhenAll(tasks);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Finish!");
        }

        //此方法代表某些比较费时的方法
        public static void Work(string a)
        {
            int i = int.Parse(a);
            while(i-- != 0)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine($"I've worked {a} hours");
        }
    }
}
