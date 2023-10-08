using Microsoft.AspNetCore.Mvc;
using test_app_getNlines.Models;

namespace test_app_getNlines.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GetPostsController : ControllerBase
{
    private readonly ILogger<GetPostsController> _logger;
    private readonly IPostRepository _rep;
    public GetPostsController(IPostRepository rep,ILogger<GetPostsController> logger)
    {
        _logger = logger;
        _rep = rep;
    }

    [HttpGet]
    public  async Task<ActionResult<IEnumerable<Post>>> GetNPostsByUserUIIId(Guid guid,int n){
        var res = await Task.Run( () => _rep.GetLastNPostsByUserUIId(guid,n));
        return res != null ? Ok(res) : NotFound(guid);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetNLastUsersNoDeterminate(int count = 0){
        var res = await Task.Run(() =>_rep.GetNLastUsersNoDeterminate(count));
        return res != null ? Ok(res) : NotFound();
    }
}
