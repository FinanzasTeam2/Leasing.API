namespace Leasing.API.App.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public string Contrasenia { get; set; }

    public List<LeasingData> LeasingData { get; set; } = new List<LeasingData>();
}