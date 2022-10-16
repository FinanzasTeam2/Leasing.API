namespace Leasing.API.App.Domain.Models;

public class ProfileUser
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //RelationShip
    public User User { get; set; }
    public int UserId { get; set; }

    public List<Solution> Solutions { get; set; } = new List<Solution>();
}