using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razzle.Sandbox
{
    public class Car
    {
        virtual public string Horn()
        {
            return "Honk";
        }

        virtual public void MakeNoise()
        {
            Horn();
        }
    }
}