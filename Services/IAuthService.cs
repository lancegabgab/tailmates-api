using TailMates.Models.Inputs;
using TailMates.Models.Outputs;

namespace TailMates.Services
{
    public interface IAuthService
    {
        Task<UserOutput> RegisterAsync(UserInput input);
    }
}