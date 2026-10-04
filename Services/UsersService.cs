using Microsoft.EntityFrameworkCore;
using My_ERP.Data;
using My_ERP.DTO;
using My_ERP.Models;

namespace My_ERP.Services
{
    public class UsersService
    {
        

        public async Task<ResultDto> GetUsersAsync(UserDTORequest filter)
        {
            ResultDto result = new ResultDto();
            List<UserDTOResult> userResults = new List<UserDTOResult>();
            ERPContext erpcontext = new ERPContext();

            IQueryable<User> query = erpcontext.Users.AsNoTracking();

            if (filter.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == filter.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.Gender))
            {
                query = query.Where(x => x.Gender == filter.Gender);
            }

            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(x =>
                    x.FirstName.Contains(filter.Search) ||
                    x.LastName.Contains(filter.Search) ||
                    x.Email.Contains(filter.Search) ||
                    x.PhoneNumber.Contains(filter.Search));
            }

            var totalItems = await query.CountAsync();

            var data = await query
                .OrderBy(x => x.UserId)
                .Skip((filter.PageNo - 1) * filter.ItemsPerPage)
                .Take(filter.ItemsPerPage)
                .ToListAsync();

            foreach (var item in data)
            {
                userResults.Add(new UserDTOResult
                {
                    UserId = item.UserId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Age = item.Age,
                    Gender = item.Gender,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }
            result.MetaData.Currentpage = filter.PageNo;
            result.MetaData.ItemsPerPage = filter.ItemsPerPage;
            result.MetaData.TotalItems = totalItems;
            result.MetaData.TotalPages = (int)Math.Ceiling((double)totalItems / filter.ItemsPerPage);   

            result.content = userResults.ToList();
            return result;
        }
    }
}
