using Default.Application.Commands.UsuarioModule.Command;
using FluentValidation;

namespace Default.Application.Commands.UsuarioModule.Validations
{
    public class AutenticarUsuarioCommandValidator : AbstractValidator<AutenticarUsuarioCommand>
    {
        public AutenticarUsuarioCommandValidator()
        {
            RuleFor(x => x.User).NotEmpty().WithMessage("O Usuário deve ser informado.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("A Senha deve ser informada.");
        }
    }
}
