using System;
using System.Threading.Tasks;
using Dapper.Build.Commands;
using Dapper.Build.Commands.Base;
using Dapper.Build.Data.Repository.Base;
using Dapper.Build.Handlers.Base;
using Dapper.Build.Models;
using Flunt.Notifications;

namespace Dapper.Build.Handlers {
    public class SubscriptionHandler : Notifiable, IHandler<UserSubscriptionCommand> {
        private readonly IRepository<User> _user;
        private readonly IRepository<Address> _address;

        public SubscriptionHandler (
            IRepository<User> user,
            IRepository<Address> address) {
            _user = user;
            _address = address;
        }

        public async Task<ICommandResult> Handle (UserSubscriptionCommand command) {
            command.Validate ();

            if (command.Invalid) {
                AddNotifications (command);
                return new CommandResult (
                    command.Valid,
                    "Sua assinatura não foi realizada",
                    command.Notifications
                );
            }

            var found = await _user.By (x => x.Email.Equals (command.Email, StringComparison.InvariantCultureIgnoreCase));

            if (found != null)
                AddNotification ("User", "Usuário já cadastrado com o e-mail informado");

            var address = new Address (command.Address);
            var user = new User (command.Name, command.Email, address.Id);

            await _address.Insert (address);
            await _user.Insert (user);

            // TODO e-mail sender

            return new CommandResult (
                command.Valid,
                "Sua assinatura foi realizada com sucesso",
                user
            );
        }
    }
}