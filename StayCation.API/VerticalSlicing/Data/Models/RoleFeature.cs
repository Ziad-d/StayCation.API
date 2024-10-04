
using StayCation.API.VerticalSlicing.Common.Enums;

namespace StayCation.API.VerticalSlicing.Data.Models
{
    public class RoleFeature : BaseModel
    {
        public int RoleID { get; set; }
        public Role Role { get; set; }

        public Feature Feature { get; set; }
    }
}
