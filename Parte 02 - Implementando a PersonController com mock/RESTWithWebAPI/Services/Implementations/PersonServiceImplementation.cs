using RESTWithWebAPI.Models;
using RESTWithWebAPI.Services;

namespace RESTWithWebAPI.Implementations
{
  public class PersonServiceImplementation : IPersonService
  {
    private volatile int count;

    public Person Create(Person person)
    {
      return person;
    }

    public void Delete(long id)
    {
    }

    public Person Read(long id)
    {
      return new Person
      {
        Id = IncrementAndGet(),
        firstName = "Camila",
        lastName = "Santos",
        Address = "São Paulo - SP",
        Gender = "Feminino"
      };
    }
    public List<Person> ReadAll()
    {
      var people = new List<Person>();
      for (int i = 0; i < 10; i++)
      {
        Person person = MockPerson(i);
        people.Add(person);
      }
      return people;
    }
    public Person Update(Person person)
    {
      return person;
    }
    private Person MockPerson(int i)
    {
      return new Person
      {
        Id = IncrementAndGet(),
        firstName = i % 2 == 0 ? $"Camila {i}" : $"Matheus {i}",
        lastName = i % 2 == 0 ? $"Santos {i}" : $"Rosa {i}",
        Address = i % 2 == 0 ? $"São Paulo {i}" : $"Rio de Janeiro {i}",
        Gender = i % 2 == 0 ? "Feminino" : "Masculino"
      };
    }

    private long IncrementAndGet()
    {
      return Interlocked.Increment(ref count);
    }
  }
}
