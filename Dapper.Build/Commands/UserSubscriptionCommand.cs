using Dapper.Build.Commands.Base;
using Flunt.Notifications;
using Flunt.Validations;

namespace Dapper.Build.Commands {
    public class UserSubscriptionCommand : Notifiable, ICommand {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public void Validate () {
            AddNotifications (new Contract ()
                .Requires ()
                .IsNotNullOrEmpty (Name, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty (Address, "Endereço", "Endereço é obrigatório")
                .IsEmailOrEmpty (Email, "Email", "E-mail inválido")
            );
        }
    }
}