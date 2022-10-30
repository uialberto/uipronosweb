using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Domain.Interfaces;

namespace Uibasoft.Domain.Entities
{
    public abstract class Entity<Type> : IEntity<Type>
    {
        public Type Id { get; set; }
    }
}
