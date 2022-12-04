namespace RPG.Domain.Dtos.StaffMember
{
#pragma warning disable CS8618
    public class StaffResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<RoleResponseDto> Roles { get; set; }
        public string JwtToken { get; set; }
    }
#pragma warning restore CS8618
}
