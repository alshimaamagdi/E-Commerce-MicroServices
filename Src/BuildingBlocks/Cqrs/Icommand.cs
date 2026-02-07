using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Cqrs
{
    public interface Icommand:Icommand<Unit>
    {
    }
    public interface Icommand<out TReponse>:IRequest<TReponse>
    {

    }
}
