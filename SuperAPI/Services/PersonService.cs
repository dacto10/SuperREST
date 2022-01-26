using SuperAPI.Clases;
using SuperAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SuperAPI.Services
{
    public class PersonService
    {
        public async static Task<ResponseValuesSchema<Person>> getFromType(string type)
        {
            var people = await PersonRepository.getPeople(type.ToUpper());
            return new ResponseValuesSchema<Person>("Mostrando lista de " + type, people.Select((name) => new Person(name, isVillian(name))).ToList());
        }

        public static ResponseMessageSchema deleteFromType(string type)
        {
            PersonRepository.deletePeople(type.ToUpper());
            return new ResponseMessageSchema("Personas eliminadas satisfactoriamente");
        }

        public async static Task<ResponseMessageSchema> updatePeopleFiles()
        {
            var people = await PersonRepository.getPeople("REGISTRADOS");
            List<string> heros = new List<string>();
            List<string> villians = new List<string>();

            foreach(var person in people)
            {
                if (isVillian(person)) villians.Add(person);
                else heros.Add(person);
            }

            var villiansPromise = PersonRepository.setPeople(villians, "VILLIANS");
            var herosPromise = PersonRepository.setPeople(heros, "HEROS");
            await Task.WhenAll(new Task[] { villiansPromise, herosPromise });
            return new ResponseMessageSchema("Personas actualizadas satisfactoriamente");
        }

        public async static Task<ResponseValuesSchema<Person>> updatePerson(Person person)
        {
            var people = await PersonRepository.getPeople("REGISTRADOS");
            Console.WriteLine(people);
            var list = new List<Person>();
            list.Add(person);
            return new ResponseValuesSchema<Person>("Persona actualizada con exito", list);
        }

        public static bool isVillian(string name)
        {
            return name.Contains("D") || name.Contains("d");
        }
    }
}