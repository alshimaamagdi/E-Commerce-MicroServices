using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Cqrs
{
    public interface IQueryHandler<in Tquery, TResponse> : IRequestHandler<Tquery, TResponse>
       where Tquery : Iquery<TResponse>
       where TResponse : notnull

    {
    }
}
