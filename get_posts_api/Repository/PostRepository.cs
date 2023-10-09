using test_app_getNlines.Models;

public class PostRepository : IPostRepository
{
    private readonly IDataContextStorage context;
    public PostRepository(IDataContextStorage context){
        this.context = context;
    }
    public IEnumerable<Post> GetLastNPostsByUserUIId(Guid userUIId, int n,int pageNumber = 1)
    {
        return context.posts
        .SkipLast((pageNumber - 1) * n)
            .Where(post => post.UserUIId == userUIId)
            .OrderByDescending(post => post.DateCreated)
            .Take(n)
            .ToList();
    }
    public IEnumerable<Post> GetNLastPostsForUsers(int countOfLastUsers, int n, int pageNumber = 1)
    {
         var lastNUserUIIds = context.users
        .SkipLast((pageNumber - 1) * n)
            .OrderByDescending(u => u.Id)
            .Select(u => u.UIId)
            .Take(n)
            .ToList();

        var lastNPosts = context.posts
            .Where(p => lastNUserUIIds.Contains(p.UserUIId))
            .OrderByDescending(p => p.DateCreated)
            .Take(n)
            .ToList();

        return lastNPosts;
    }
    public IEnumerable<User> GetNLastUsersNoDeterminate(int count = 0){
        return context.users
            .TakeLast(count)
            .ToList();
    }
}