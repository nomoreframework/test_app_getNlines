using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_app_getNlines.Models
{
    public class User : BaseEntity
    {
        [StringLength(25, MinimumLength=2)]
        public string Name { get; set; }
        public User(string name,int id) {Name = name;UIId = Guid.NewGuid();}
    }
}