using Default.Application.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Default.Application.Commands.UsuarioModule.Command
{
    public class AutenticarUsuarioCommand : ICommand
    {
        public string User { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
