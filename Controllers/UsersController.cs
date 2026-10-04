using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_ERP.Agent;
using My_ERP.DTO;

namespace My_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<ResultDto> GetUsers(UserDTORequest request)
        {
            UsersAgent usersagent = new UsersAgent();

            return await usersagent.GetUsersAsync(request);
        }
    }
}
