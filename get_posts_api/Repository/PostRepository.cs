using test_app_getNlines.Models;

public class PostRepository : IPostRepository
{
    private readonly List<Post> posts;
    private readonly List<User> users;

    public PostRepository()
    {
        users = usersInit(7);
        posts = postsInit(users,18);
    }
    public IEnumerable<Post> GetLastNPostsByUserUIId(Guid userUIId, int n)
    {
        return posts
            .Where(post => post.UserUIId == userUIId)
            .OrderByDescending(post => post.Id)
            .Take(n)
            .ToList();
    }
    public IEnumerable<User> GetNLastUsersNoDeterminate(int count = 0){
        return users
            .TakeLast(count)
            .ToList();
    }
    List<Post> postsInit(IEnumerable<User> users, uint linesCount)
    {
        if(linesCount > int.MaxValue) 
            throw new ArgumentException($"argument {nameof(linesCount)} must be greater -1 and  less than UINT32.MAX_VALUE ({int.MaxValue})");
        var posts = new List<Post>();
        foreach (var u in users) 
            for(int i = 0;i < linesCount;i++) posts.Add(new Post(u,$"HashCode for userName - {u.Name} = {String.GetHashCode(u.Name)}"){Id = i});
        return posts;
    }
    List<User> usersInit(uint linesCount)
    {
        var names = new []{"Vasya@","Petya@","Fedya@","Nastya@","Andrei@","John@"};
        if(linesCount > int.MaxValue) 
            throw new ArgumentException($"argument {nameof(linesCount)} must be greater -1 and  less than UINT32.MAX_VALUE ({int.MaxValue})");
        var users = new List<User>((int)linesCount);
        for(int i = 0; i < linesCount; i++){
            Task.Delay(new Random().Next(1,4));
            users.Add(new User(names[new Random().Next(0,names.Length - 1)] + $"{i}",i));
        }
        return users;
    }
}