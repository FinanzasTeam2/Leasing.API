namespace Leasing.API.App.Domain.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email{ get; set; }
    public string Password { get; set; }
    
    //RelationShip
    public List<Solution> Solutions { get; set; } = new List<Solution>();
}