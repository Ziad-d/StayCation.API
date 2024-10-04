namespace StayCation.API.VerticalSlicing.Common.Enums
{
    public enum ErrorCode
    {
        None = 0,
        UnKnown = 1,
        NullName = 2,
        Exists = 3,
        InvalidData = 4,

        UserNotFound = 1000,
        InvalidUserID = 1001,
        InvalidRoleID = 1002,
    }
}
