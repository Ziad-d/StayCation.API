using StayCation.API.VerticalSlicing.Common.Enums;

namespace StayCation.API.VerticalSlicing.Features.Admin.AssignFeaturesToRole
{
    public class FeaturesToRoleRequest
    {
        public List<Feature> Features { get; set; }
        public int RoleId { get; set; }
    }
}
