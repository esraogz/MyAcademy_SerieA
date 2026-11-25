namespace SerieA.WebUI.DTOs.UserDtos
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }    

        public IList<string> Roles { get; set; }
    }
}
