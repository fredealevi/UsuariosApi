using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models;

public class Usuario : IdentityUser
{
    public DateTime Datanascimento { get; set; }

    public Usuario() : base()
    {
        
    }
}
