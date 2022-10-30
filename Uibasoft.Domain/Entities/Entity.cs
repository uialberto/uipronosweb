using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Domain.Interfaces;

namespace Uibasoft.Domain.Entities
{
    public abstract class Entity : Entity<long>, IEntity
    {

    }
}
