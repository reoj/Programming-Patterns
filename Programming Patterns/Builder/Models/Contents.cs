using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming_Patterns.Builder.Models
{
    public class Contents
    {
        public float Weigh { get; set; }
        public float XDimension { get; set; }
        public float YDimension { get; set; }
        public float ZDimension { get; set; }

        public float Volume
        {
            get => XDimension * YDimension * ZDimension;
            private set { value = XDimension * YDimension * ZDimension; }
        }
        public Contents(float weigh)
        {
            this.Weigh = weigh;            
        }
    }
}
