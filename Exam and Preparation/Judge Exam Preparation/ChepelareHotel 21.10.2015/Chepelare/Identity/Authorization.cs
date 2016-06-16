namespace HotelBookingSystem.Identity
{
    using Models;

    public static class Authorization
    {
        public static bool IsInRole(this User user, Roles role)
        {
            return user.Role == role;
        }
    }
}