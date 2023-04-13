using MongoDB.Driver;
using MongoDB.Bson;

namespace Lime.SecurityWrapper.Identifiers;

public record User(Guid uuid, string username)
{
    public static User GetUserById(Guid uuid)
    {
        //do some magic
        return new User(Guid.NewGuid(), "PLACEHOLDER_USER");
    }

    public static User GetUserByUsername(string username)
    {
        //do some magic
        return new User(Guid.NewGuid(), "PLACEHOLDER_USER");
    }
}