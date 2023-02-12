using System.Threading.Tasks;

namespace ECommerce.Web.Services.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
