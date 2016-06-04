using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razzle.DAL
{
    public class RazzleRepository
    {
        public RazzleContext context { get; set; }

        public RazzleRepository()
        {
            //Needing an instance of Context
            context = new RazzleContext();
        }
    }
}