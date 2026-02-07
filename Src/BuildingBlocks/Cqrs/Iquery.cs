using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Cqrs
{
  
    public interface Iquery<out TReponse> : IRequest<TReponse> where TReponse:notnull
    {

    }
}
