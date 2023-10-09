
using Microsoft.AspNetCore.Mvc;
using Moq;
using test_app_getNlines.Controllers;
using test_app_getNlines.Models;

namespace get_posts_api.tests;
public class GetPostsControllerTest
{
[   Fact]
    public async Task Test1Async()
    {
            var mockRepository = new Mock<IPostRepository>();
            var userUIId = Guid.NewGuid();
            var posts = new List<Post>
            {
                new(new User("User1", 1), "Post1",1),
                new(new User("User1", 1), "Post2",2)
            };
            _ = mockRepository.Setup(repo => repo.GetLastNPostsByUserUIId(userUIId, 2,1))
                .Returns(posts);

            var controller = new GetPostsController(mockRepository.Object);

            var result = await Task.Run(() => controller.GetNPostsByUserUIId(userUIId, 2,1));

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Post>>(okResult.Value);
            Assert.Equal(posts, model);
    }
    [Fact]
    public async Task GetNLastPostsForUsers_ReturnsPosts_WhenUsersExist()
    {
        var mockRepository = new Mock<IPostRepository>();
        var users = new List<User>
        {
            new("User1", 1),
            new("User2", 2)
        };
        var posts = new List<Post>
        {
            new(users[0], "Post1",1),
            new(users[1], "Post2",2)
        };
        _ = mockRepository.Setup(repo => repo.GetNLastPostsForUsers(2, 2,1))
        .Returns(posts);
        var controller = new GetPostsController(mockRepository.Object);
        // Act
        var result = await controller.GetNLastPostsForUsers(2, 2);
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Post>>(okResult.Value);
        Assert.Equal(posts, model);
    }   
}