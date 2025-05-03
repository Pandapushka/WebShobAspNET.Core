namespace WebShobGleb.Models
{
    public class UserAccount
    {
        public Guid Id { get; }
        public string Login { get; set; }
        public string Pasword { get; set; }
        public string Phone { get; set; }
        public UserAccount()
        {
            Id = Guid.NewGuid();
        }
    }
}
