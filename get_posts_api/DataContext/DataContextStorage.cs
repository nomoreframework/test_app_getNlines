using test_app_getNlines.Models;
public class DataContextStorage : IDataContextStorage
{
    public const uint USERS_COUNT = 12;
    public const uint POSTS_COUNT = 17;
    public List<User> users => usersInit(USERS_COUNT);
    public List<Post> posts => postsInit(users,POSTS_COUNT);
    List<Post> postsInit(IEnumerable<User> users, uint linesCount)
    {
        if(linesCount > int.MaxValue) 
            throw new ArgumentException($"argument {nameof(linesCount)} must be greater -1 and  less than UINT32.MAX_VALUE ({int.MaxValue})");
        var posts = new List<Post>();
        foreach (var u in users) 
            for(int i = 1;i < linesCount;i++) posts.Add(new Post(u,$"HashCode for userName - {u.Name} = {String.GetHashCode(u.Name)}",i));
        return posts;
    }
    List<User> usersInit(uint linesCount)
    {
        var names = new []{"Vasya@","Petya@","Fedya@","Nastya@","Andrei@","John@"};
        if(linesCount > int.MaxValue) 
            throw new ArgumentException($"argument {nameof(linesCount)} must be greater -1 and  less than INT32.MAX_VALUE ({int.MaxValue})");
        var users = new List<User>((int)linesCount);
        for(int i = 1; i < linesCount; i++){
            Task.Delay(new Random().Next(1,4));
            users.Add(new User(names[new Random().Next(0,names.Length - 1)] + $"{i}",i));
        }
        return users;
    }
}