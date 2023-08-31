namespace Mango.Web.Utility
{
    public class StaticDetails
    {
        public static string? CouponAPIBase { get; set; }
        public static string? AuthAPIBase { get; set; }
        public static string? ProductAPIBase { get; set; }
        public static string? ShoppingCartAPIBase { get; set; }

        public const string AdminRole = "ADMIN";
        public const string CustomerRole = "CUSTOMER";
        public const string TokenCookie = "JWToken";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            PATCH,
            DELETE
        }
    }
}
