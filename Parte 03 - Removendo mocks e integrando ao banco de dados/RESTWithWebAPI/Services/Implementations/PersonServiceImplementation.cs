using RESTWithWebAPI.Models;
using RESTWithWebAPI.Models.Context;
using RESTWithWebAPI.Services;

namespace RESTWithWebAPI.Implementations
{
  public class PersonServiceImplementation : IPersonService
  {
    private SQLServerContext _context;

    public PersonServiceImplementation(SQLServerContext context)
    {
      _context = context;
    }
    public Person Create(Person person)
    {
      try
      {
        _context.Add(person);
        _context.SaveChanges();
      }
      catch (Exception)
      {

        throw;
      }
      return person;
    }

    public void Delete(long id)
    {
      var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));

      if (result != null)
      {
        try
        {
          _context.People.Remove(result);
          _context.SaveChanges();
        }
        catch (Exception)
        {

          throw;
        }
      }
    }

    public Person Read(long id)
    {
      return _context.People.SingleOrDefault(p => p.Id.Equals(id));
    }
    public List<Person> ReadAll()
    {
      return _context.People.ToList();
    }
    public Person Update(Person person)
    {
      if (!Exists(person.Id)) return new Person();
      var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(person);
          _context.SaveChanges();
        }
        catch (Exception)
        {

          throw;
        }
      }
      return person;
    }

    private bool Exists(long id)
    {
      return _context.People.Any(p => p.Id.Equals(id));
    }
  }
}
