namespace My_ERP.DTO
{
    public class UserDTORequest
    {
        public bool? IsActive { get; set; } 
        public string Gender { get; set; } = string.Empty;
        public int PageNo { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
        public string Search { get; set; } = string.Empty;
    }
}
