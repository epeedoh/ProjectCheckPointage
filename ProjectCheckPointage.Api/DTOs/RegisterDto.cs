namespace ProjectCheckPointage.Api.DTOs
{
    public class RegisterDto
    {
        public string? Nom { get; set; }
        public string? Prenoms { get; set; }
        // public string? NomComplet { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? Username { get; set; }

        //  public byte[]? Image { get; set; }
        //public byte[] PasswordHash { get; set; }
        public string Password { get; set; }
        public int RoleTypeId { get; set; }


    }
}
