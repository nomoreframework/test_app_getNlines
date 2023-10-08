using System.ComponentModel.DataAnnotations;

namespace test_app_getNlines.Models
{
    public class Post : BaseEntity
    {
        public Guid UserUIId {get;set;}
        [StringLength(10000, MinimumLength=2)]
        public string Text { get; set; }
        public Post(User user,string text){
            Text = text;
            UserUIId = user.UIId;
            UIId = Guid.NewGuid();
        }
    }
}