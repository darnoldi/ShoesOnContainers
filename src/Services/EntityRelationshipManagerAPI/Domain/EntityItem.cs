using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Domain
{
    public class EntityItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int EntityTypeId { get; set; }

        public EntityType EntityType { get; set; }

        public List<EntityStatuatoryId> StatuatoryIdList { get; set; }

        public List<EntityAddress> EntityAddressList { get; set; }

        public List<EntityTelephoneNumber> EntityTelephoneNumberList { get; set; }

        public List<EntityEmailAddress> EntityEmailAddressList { get; set; }


    }
}
