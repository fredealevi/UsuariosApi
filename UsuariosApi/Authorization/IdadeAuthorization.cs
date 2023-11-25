using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var datanascimentoClaim = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.DateOfBirth);

        if(datanascimentoClaim is null)
            return Task.CompletedTask;

        var dataNascimento = Convert.ToDateTime(datanascimentoClaim.Value);

        var idadeUsuario = DateTime.Today.Year - dataNascimento.Year;

        if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario))
            idadeUsuario--;

        if (idadeUsuario >= requirement.Idade)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
