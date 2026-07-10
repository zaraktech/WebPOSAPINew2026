using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.Common
{
    public class PagedResult<T>
    {
        public List<T> Result { get; set; } = new();
        public int Count { get; set; }
    }
}
