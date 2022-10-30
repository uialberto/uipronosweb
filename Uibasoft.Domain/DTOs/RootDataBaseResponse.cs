using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Domain.DTOs
{
    public class RootDataBaseResponse<TData> where TData : class
    {
        public int Status { get; set; }
        public TData Data { get; set; }
        public string[] Errors { get; set; }
        public bool HasErrors { get; set; }
    }
}
