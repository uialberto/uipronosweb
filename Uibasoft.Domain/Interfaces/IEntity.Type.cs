using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Domain.Interfaces
{
    public interface IEntity<Type>
    {
        public Type Id { get; set; }
    }
}
