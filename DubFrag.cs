using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm5 {
    public class DubFrag<T> {
        public DubFrag(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DubFrag<T> Prev { get; set; }
        public DubFrag<T> Next { get; set; }
    }
}
