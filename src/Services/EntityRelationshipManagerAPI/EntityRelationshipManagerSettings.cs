using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnoldi.Services.EntityRelationshipManagerAPI
{
    public class EntityRelationshipManagerSettings
    {
        

        public string ExternalEntityRelationShipManagerBaseUrl { get; set; }

        // public bool UseCustomizationData { get; set; }
        public EntityRelationShipManager EntityRelationShipManager { get; set; }

    }
    public class EntityRelationShipManager
    {
        public string ConnectionString { get; set; }
    }

}

