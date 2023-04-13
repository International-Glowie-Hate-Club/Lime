using Microsoft.AspNetCore.Mvc;

namespace Lime.Backend.Controllers;

[ApiController]
[Route("/api/users/")]
public class UserController : ControllerBase
{
    //Every method inside of this class must be passed a Guid that is inside of Authenticated.authedtokens
}
