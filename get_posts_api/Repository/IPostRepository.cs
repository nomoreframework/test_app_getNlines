using test_app_getNlines.Models;

public interface IPostRepository
{
    IEnumerable<Post> GetLastNPostsByUserUIId(Guid userUIId, int n);
    IEnumerable<User> GetNLastUsersNoDeterminate(int count);
}
