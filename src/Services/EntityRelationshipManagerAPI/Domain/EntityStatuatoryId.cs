using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arnoldi.Services.EntityRelationshipManagerAPI.Domain
{
    public class EntityStatuatoryId
    {
        public int Id { get; set; }

        public string StatuatoryIdNumber { get; set; }

        public int EntityStatuatoryIdTypeId { get; set; }

        public EntityStatuatoryIdType EntityStatuatoryIdType { get; set; }

        public int EntityItemId { get; set; }
        public EntityItem EntityItem { get; set; }


    }
}
