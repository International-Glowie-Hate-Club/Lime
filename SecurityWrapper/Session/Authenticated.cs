using Lime.SecurityWrapper.Identifiers;

namespace Lime.SecurityWrapper.Session;

public record Authenticated(User user, Guid sessionId)
{
    public static Authenticated AuthenticateUser(ref List<Authenticated> authenticated, ref User user)
    {
        Guid gd = Guid.NewGuid();

        //just a quite uneccessary precaution
        foreach(Authenticated authd in authenticated)
        {
            if(authd.sessionId == gd)
            {
                gd = Guid.NewGuid();
            }
        }

        Authenticated ret = new Authenticated(user, gd);

        authenticated.Add(ret);
        return ret;
    }
}