using System.Threading.Tasks;
using Dapper.Build.Commands.Base;

namespace Dapper.Build.Handlers.Base
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}