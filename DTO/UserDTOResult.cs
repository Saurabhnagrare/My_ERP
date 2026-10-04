namespace My_ERP.DTO
{
    public class UserDTOResult
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;


        public string? PhoneNumber { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
