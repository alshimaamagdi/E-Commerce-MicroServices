using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Cqrs
{
    public interface ICommandHandler<in Tcommand> : ICommandHandler< Tcommand, Unit>
        where Tcommand:Icommand<Unit>
    {
    }
    public interface ICommandHandler<in Tcommand,TResponse> : IRequestHandler<Tcommand, TResponse>
        where Tcommand:Icommand<TResponse>
        where TResponse:notnull

    {
    }
}
