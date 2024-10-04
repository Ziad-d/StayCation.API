namespace StayCation.API.VerticalSlicing.Common.Helpers
{
    public static class OTPGenerator
    {
        public static string CreateOTP()
        {
            Random random = new Random();
            string randomno = random.Next(100000, 999999).ToString();
            return randomno;
        }
    }
}
