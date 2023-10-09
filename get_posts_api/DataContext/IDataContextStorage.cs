using test_app_getNlines.Models;

public interface IDataContextStorage
{
    public List<User> users {get;}
    public List<Post> posts {get;} 
}