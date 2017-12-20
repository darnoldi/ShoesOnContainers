using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Domain
{
    public class EntityAddress
    {

        // Todo: make address lookup lists for areas city country etc

        public int Id { get; set; }

        public int EntityAddressTypeId { get; set; }

        public  EntityAddressType EntityAddressType { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public int AddressCode { get; set; }


        public int EntityItemId { get; set; }
        public EntityItem EntityItem { get; set; }
    }
}

