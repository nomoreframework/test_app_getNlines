using Microsoft.AspNetCore.Mvc;
using Moq;
using test_app_getNlines.Controllers;
using test_app_getNlines.Models;

namespace get_posts_api.tests;

public class PostRepositoryUnitTest
{
    DataContextStorage contextStorage = new DataContextStorage();

    [Fact]
    public void BaseCollectionsTest(){
        var user = contextStorage.users.First();
        var lastPosts = contextStorage.posts.Where(p => p.UserId == user.Id).TakeLast(3).ToList();
        var res = new PostRepository(contextStorage).GetLastNPostsByUserUIId(user.UIId,3).ToList();
        Assert.Equal(3,res.Count);
        // Assert.Collection(lastPosts,
            // p => Assert.Equal(res[0],p),
            // p => Assert.Equal(res[^1],p));
    }
    [Fact]
    public void ContextNotNullTest() => Assert.False(contextStorage is null);
    [Fact]
    public void ContextCollectionsNotNullTest() =>  Assert.True(contextStorage.posts.Count > 0 && contextStorage.posts.Count > 0);
}