using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DTO.Responses
{
    public class ApiResponse<T> : ServerResponse
    {
        public T Data { get; set; }
    }
}
