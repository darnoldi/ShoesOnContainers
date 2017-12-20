using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Domain
{
    public class EntityTelephoneNumber
    {
        public int Id { get; set; }

        public string TelephoneNumber { get; set; }

        public int EntityTelephoneNumberTypeId { get; set; }

        public EntityTelephoneNumberType EntityTelephoneNumberType { get; set; }


        public int EntityItemId { get; set; }
        public EntityItem EntityItem { get; set; }
    }
}
