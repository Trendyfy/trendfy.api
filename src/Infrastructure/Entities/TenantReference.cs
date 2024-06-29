using System;
using System.Collections.Generic;
using System.Text;
using Music.IO.Data.Entities.Interfaces;

namespace Music.IO.Data.Entities
{
    public class TenantReference : BaseEntityReference<ITenant, string>
    {
        public string Name { get; set; } = string.Empty;
    }
}
