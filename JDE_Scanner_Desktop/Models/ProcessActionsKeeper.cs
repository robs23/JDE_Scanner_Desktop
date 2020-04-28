﻿using JDE_Scanner_Desktop.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class ProcessActionsKeeper : Keeper<ProcessAction>
    {
        protected override string ObjectName => "ProcessAction";

        protected override string PluralizedObjectName => "ProcessActions";

    }
}
