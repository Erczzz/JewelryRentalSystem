namespace JewelryRentalSystem.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}