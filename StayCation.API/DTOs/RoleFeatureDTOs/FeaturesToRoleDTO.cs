using StayCation.API.Enums;

namespace StayCation.API.DTOs.RoleFeatureDTOs
{
    public class FeaturesToRoleDTO
    {
        public List<Feature> Features { get; set; }
        public int RoleId { get; set; }
    }
}
