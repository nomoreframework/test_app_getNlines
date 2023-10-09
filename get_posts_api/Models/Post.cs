using System.ComponentModel.DataAnnotations;

namespace test_app_getNlines.Models
{
    public class Post : BaseEntity
    {
        public Guid UserUIId {get;}
        public int UserId {get;}

        [StringLength(10000, MinimumLength=2)]
        public string Text { get; set;}
        public DateTime DateCreated => DateTime.Now;
        public Post(User user,string text,int id){
            Id = id;
            Text = text;
            UserUIId = user.UIId;
            UserId = user.Id;
            UIId = Guid.NewGuid();
        }
    }
}