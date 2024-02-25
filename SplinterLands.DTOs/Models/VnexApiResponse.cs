using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLands.DTOs.Models
{
    public class VnexApiResponse<T>
    {
        public string status { get; set; } = string.Empty;
        public T? data { get; set; } = default(T?);
    }
}
