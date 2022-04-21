using System.ComponentModel.DataAnnotations;
using bank5.Entities;
namespace bank5.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public Role()
    {
        Users = new List<User>();
    }
}