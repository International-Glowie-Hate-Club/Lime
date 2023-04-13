using Lime.Backend.Globals;
using Lime.SecurityWrapper.CSLWrapper;
using Lime.SecurityWrapper.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Lime.Backend.Controllers;

[ApiController]
[Route("/api/auth/")]
public class AuthenticationController : ControllerBase
{
    [HttpPost]
    [Route("upfront")]
    public async Task<Guid?> UpfrontKeyAuth(string key)
    {
        byte[] pkey = await System.IO.File.ReadAllBytesAsync("./kotd.key");
        string decrypted;

        using(Protector p = new Protector(pkey))
        {
            decrypted = await p.Decrypt<string>(key);
        }

        if(KeyHandler.AuthenticateKey(decrypted))
        {
            Guid gd = Guid.NewGuid();

            foreach(Guid g in Authed.authedtokens)
            {
                if(g == gd)
                {
                    gd = Guid.NewGuid();
                }
            }

            return gd;
        }

        return null;
    }
}