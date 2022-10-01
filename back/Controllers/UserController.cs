using Microsoft.AspNetCore.Mvc;
using dto;
namespace Back.Controllers;


using Model;
[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login() 
    { 
        throw new NotImplementedException();
    } 
    [HttpPost("register")]
    public IActionResult Register([FromBody] UsuarioDTO user) 
    {
        
        using TDSabadoContext context = new TDSabadoContext(); 
        Usuario usuario = new Usuario(); 
        usuario.Name = user.Name; 
        usuario.BirthDate = user.BirthDate;
        usuario.UserId = user.UserId; 
        usuario.Userpass = user.Password; 

        List<string> errors = new List<string>();
        if(usuario.Name.Length < 5)
        {
            errors.Add("O nome do usuário precisa conter ao menos 5 letras.");
        } 

        if (context.Usuarios
            .Any(u => u.UserId == user.UserId));
            {
                errors.Add("Seu Nome de Usuário já está em uso!");
            } 

            if(errors.Count > 0) 
            { 
                return this.BadRequest(errors);
            }

        // var query2 = 
        // from u in context.Usuarios 
        // where u.Name == user.UserId 
        // select u;


        context.Add(usuario); 
        context.SaveChanges(); 

        return Ok();
    } 
   
    [HttpPost("update")]
    public IActionResult UpdateName() 
    { 
        throw new NotImplementedException();
    }
}
