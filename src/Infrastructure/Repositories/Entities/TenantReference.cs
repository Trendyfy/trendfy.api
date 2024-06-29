using System;
using System.Collections.Generic;
using System.Text;
using Rabbot.Jedi.Data.Entities.Interfaces;

namespace Rabbot.Jedi.Data.Entities
{
    public class TenantReference : BaseEntityReference<ITenant, string>
    {
        public string Name { get; set; } = string.Empty;
    }
}
