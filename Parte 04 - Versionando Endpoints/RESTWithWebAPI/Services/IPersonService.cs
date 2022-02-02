using RESTWithWebAPI.Models;

namespace RESTWithWebAPI.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Read(long id);
        List<Person> ReadAll();
        Person Update(Person person);
        void Delete(long id);
    }
}