namespace Ecommerce.Gateway.API.Settings
{
    public class OrderApiClientSettings
    {
        #region Properties

        public required string ApiUrl { get; set; }
        public required string Prefix { get; set; }
        public int ServiceTimeout { get; set; } = 1000;

        #endregion
    }
}
