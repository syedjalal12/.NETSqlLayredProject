using DataAccessLayer.ViewModels.ResponseVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ResponseModels
{
    public class ActionResponseVM<T>
    {
        public T Data { get; set; }
        public bool Successful { get; set; }
        public int CodeStatus { get; set; }
        public string? Message { get; set; }
    }
}
