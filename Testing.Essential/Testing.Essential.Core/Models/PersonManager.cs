using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Essential.Core.Models
{
    public class PersonManager
    {
        public Person CreatePerson(string firstName, string lastName, bool isSupervisor)
        {
            Person person = null;

            if (!string.IsNullOrEmpty(firstName))
            {
                if (isSupervisor)
                {
                    person = new Supervisor();
                }
                else
                {
                    person = new Employee();
                }

                person.FirstName = firstName;
                person.LastName = lastName;
            }

            return person;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Franco", LastName = "Morales" });
            people.Add(new Person() { FirstName = "Fernando", LastName = "Morales" });
            people.Add(new Person() { FirstName = "Matias", LastName = "Zimmerman" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Franco", "Morales", true));
            people.Add(CreatePerson("Fernando", "Morales", true));

            return people;
        }
    }
}
