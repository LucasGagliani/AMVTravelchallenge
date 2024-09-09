namespace AMVchallenge.Services
{
    public class LoginService
    {
        private readonly string _username = "admin";
        private readonly string _password = "password123";

        public bool Authenticate(string username, string password)
        {
            return username == _username && password == _password;
        }
    }
}
