using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uibasoft.Domain.Exceptions;

namespace Uibasoft.Domain.CustomEntities
{
    public class ApiResponse<TData>
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public IEnumerable<BaseErrorMessage> Errors { get; set; } = new List<BaseErrorMessage>();
        public string Type { get; set; }
        public ApiResponse(TData data)
        {
            Data = data;
        }
        public ApiResponse()
        {

        }
        public TData Data { get; set; }
        public ApiResponse(TData data, int status, string title, List<BaseErrorMessage> errors)
        {
            Data = data;
            Status = status;
            Title = title;
            Errors = errors;
        }
    }

    public class ApiResponse
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public IEnumerable<BaseErrorMessage> Errors { get; set; } = new List<BaseErrorMessage>();
        public string Type { get; set; }
        public ApiResponse()
        {
        }
        public object Data { get; set; }
    }
}
