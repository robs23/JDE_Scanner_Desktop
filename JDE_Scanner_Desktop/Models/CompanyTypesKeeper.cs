﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class CompanyTypesKeeper : Keeper<CompanyType>
    {
        protected override string ObjectName => "CompanyType";

        protected override string PluralizedObjectName => "CompanyTypes";
    }
}
