using Microsoft.AspNetCore.Mvc;
using test_app_getNlines.Models;

namespace test_app_getNlines.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GetPostsController : ControllerBase
{
    private readonly ILogger<GetPostsController>? _logger;
    private readonly IPostRepository _rep;
    public GetPostsController(IPostRepository rep,ILogger<GetPostsController>? logger = null)
    {
        _logger = logger;
        _rep = rep;
    }

    [HttpGet]
    public  async Task<ActionResult<IEnumerable<Post>>> GetNPostsByUserUIId(Guid guid,int n, int pageNumber = 1){
        var res = await Task.Run(() => _rep.GetLastNPostsByUserUIId(guid,n,pageNumber));
        return res != null ? Ok(res) : NotFound(guid);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetNLastPostsForUsers(int countOfLastUsers, int n, int pageNumber = 1){
        var res = await Task.Run(()=> _rep.GetNLastPostsForUsers(countOfLastUsers,n,pageNumber));
        return res != null ? Ok(res) : NotFound(res);
    }
    //дернуть для теста 
    [HttpGet("hook")]
    public async Task<ActionResult<IEnumerable<User>>> GetNLastUsersNoDeterminate(int count = 1){
        var res = await Task.Run(() =>_rep.GetNLastUsersNoDeterminate(count));
        return res != null ? Ok(res) : NotFound();
    }
}
