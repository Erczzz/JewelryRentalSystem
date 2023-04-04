namespace JewelryRentalSystem.Data.DbInitialization
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbInitializer(this IServiceCollection services)
        {
            return services.AddScoped<IDbInitializer, DbInitializer>();
        }
    }
}
