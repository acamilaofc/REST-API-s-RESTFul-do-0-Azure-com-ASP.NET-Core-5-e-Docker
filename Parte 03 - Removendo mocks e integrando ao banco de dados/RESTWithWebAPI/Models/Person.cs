using System.ComponentModel.DataAnnotations.Schema;

namespace RESTWithWebAPI.Models
{
  [Table("PEOPLE")]
  public class Person
  {
    [Column("ID")] public long Id { get; set; }
    [Column("FIRSTNAME")] public string firstName { get; set; }
    [Column("LASTNAME")] public string lastName { get; set; }
    [Column("ADDRESS")] public string Address { get; set; }
    [Column("GENDER")] public string Gender { get; set; }
  }
}