using Microsoft.AspNetCore.Identity;

namespace Net8AuthExample.Api;

public class User : IdentityUser
{
    public long MyPersonalId { get; private set; }

    public void SetMyPersonalId(long id)
    {
        MyPersonalId = id;
    }
}