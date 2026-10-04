using My_ERP.DTO;
using My_ERP.Services;

namespace My_ERP.Agent
{
    public class UsersAgent
    {
        public async Task<ResultDto> GetUsersAsync(UserDTORequest request)
        {
            UsersService userservice = new UsersService();
            var users = await userservice.GetUsersAsync(request);
            return users;
        }
    }
}
