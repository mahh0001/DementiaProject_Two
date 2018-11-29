namespace DementiaProject_Two.Models.Account
{
    public class UserInformationModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public string Gender { get; set; }
        public byte[] Picture { get; set; }
    }
}
