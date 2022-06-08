using System.Text.Json.Serialization;

namespace Default.Application.Commands
{
    public class BaseModelCommand
    {
        [JsonIgnore]
        public int UsuarioIdLogado { get; set; }
    }
}
