namespace ECommerce.Web.Models
{
    public class ClientSettings
    {
        public Client MvcClient { get; set; }
        public Client MvcClientForUser { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
