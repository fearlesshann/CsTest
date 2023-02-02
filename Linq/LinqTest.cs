using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CsTest.Linq
{
    public class LinqTest
    {
        public static void Test()
        {
            //Linq测试数据源
            var json = File.ReadAllText("D:\\Code\\study\\VS\\CsTest\\Linq\\city.json");
            var province = JsonSerializer.Deserialize<List<Province>>(json);
            //测试方法体
            Console.WriteLine("---------- LinqTest ----------");
            string? cmd;
            while ((cmd = Console.ReadLine()) != "q")
            {
                var s = cmd.Split(":");
                if (s[0] == "1")
                {
                    GetAllProvince(province);
                }
                if (s[0] == "2")
                {
                    GetAllCity(province);
                }
                if(s[0] == "fc")
                {
                    FindCity(province, s[1]);
                }
                if (s[0] == "fp")
                {
                    FindProvince(province, s[1]);
                }
            }
        }

        public static void GetAllProvince(List<Province> province)
        {
            var res = province.Select(p => p.Name);
            foreach(var p in res)
            {
                Console.WriteLine(p);
            }
        }

        public static void GetAllCity(List<Province> province)
        {
            var res = province.SelectMany(p => p.Cities);
            foreach (var c in res)
            {
                Console.WriteLine(c.Name);
            }
        }

        public static void FindProvince(List<Province> province, string param)
        {
            var res = province.Where(p => p.Name.Contains(param)).Select(p => p.Name);
            foreach (var p in res)
            {
                Console.WriteLine(p);
            }
        }

        public static void FindCity(List<Province> province, string param)
        {
            var res = province.SelectMany(p => p.Cities).Where(c => c.Name.Contains(param));
            foreach (var c in res)
            {
                Console.WriteLine(c.Name);
            }
        }

    }
}
