using test_app_getNlines.Models;

public interface IPostRepository
{
    IEnumerable<Post> GetLastNPostsByUserUIId(Guid userUIId, int n, int pageNumber);
    IEnumerable<Post> GetNLastPostsForUsers(int countOfLastUsers, int n, int pageNumber = 1);
    IEnumerable<User> GetNLastUsersNoDeterminate(int count);
}
