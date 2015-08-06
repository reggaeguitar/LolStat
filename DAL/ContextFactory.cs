﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL
{
    public class ContextFactory : IContextFactory
    {
        public ILolStatModel Create()
        {
            return new LolStatModel("LolStatDb");
        }
    }
}
