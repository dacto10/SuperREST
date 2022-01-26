using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuperAPI.Repositories
{
    public class PersonRepository
    {
        public async static Task<List<string>> getPeople(string fileName)
        {
            var list = new List<string>();
            var file = new System.IO.StreamReader(@"C:\Users\Darius\source\repos\SuperREST\SuperAPI\App_Data\" + fileName + ".DAT");
            string line;

            while ((line = await file.ReadLineAsync()) != null)
            {
                list.Add(line);
            }
            file.Close();
            return list;
        }

        public async static Task<bool> setPeople(List<string> list, string fileName)
        {
            try
            {
                var file = new System.IO.StreamWriter(@"C:\Users\Darius\source\repos\SuperREST\SuperAPI\App_Data\" + fileName + ".DAT");

                foreach (var nombre in list)
                {
                    await file.WriteLineAsync(nombre);
                }
                file.Close();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public static void deletePeople(string fileName)
        {
            System.IO.File.Delete(@"C:\Users\Darius\source\repos\SuperREST\SuperAPI\App_Data\" + fileName + ".DAT");
        }
    }
}