using Services_Layer.DTOS.O2Auth;

namespace Services_Layer.Services.MicrosoftGraphHelper
{
    public interface IMicrosoftGraphHelper
    {
        Task<GraphAuthResource> AcquireATokenFromRefreshTokenAsync(ReLoginDTO reLoginDTO);
        Task<GraphAuthResource> AcquireATokenFromUsernamePasswordAsync(string username, string password);
    }
}