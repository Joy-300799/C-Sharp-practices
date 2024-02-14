// Injecting dependencies in controller classes
[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    private LoginManager _lManager;
    public HelloController(LoginManager loginManager)
    {
        _lManager = loginManager;
    }

    [HttpGet("")]
    public bool Get()
    {
        return _lManager.Login("john", "johnpwd");
    }
}