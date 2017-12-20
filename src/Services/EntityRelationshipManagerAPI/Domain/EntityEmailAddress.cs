using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Domain
{
    public class EntityEmailAddress
    {
        public int Id { get; set; }

        public int EntityEmailAddressTypeId { get; set; }

        public EntityEmailAddressType EntityEmailAddressType { get; set; }

        public string EmailAddress { get; set; }


        public int EntityItemId { get; set; }
        public EntityItem EntityItem { get; set; }
    }
}
