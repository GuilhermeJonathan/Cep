using System.Text.Json.Serialization;

namespace Cep.Application.Commands
{
    public class BaseModelCommand
    {
        [JsonIgnore]
        public int UsuarioIdLogado { get; set; }
    }
}
