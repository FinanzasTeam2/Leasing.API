namespace Leasing.API.App.Domain.Models;
public class User
{
    public int Id{ get; set; }
    public string Email{ get; set; }
    public string Password { get; set; }

    //RelationShip
    public List<ProfileUser> ProfileUsers { get; set; } = new List<ProfileUser>();
}