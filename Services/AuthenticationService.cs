public interface IAuthenticationService
{
    bool AuthenticateUser(string username, string password);
}
public class AuthenticationService : IAuthenticationService
{
    private readonly AppDbContext _dbContext;

    public AuthenticationService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool AuthenticateUser(string? username, string? password)
    {
        var user = _dbContext.Logins.FirstOrDefault(u => u.username == username);
        if (user == null)
        {
            return false;
        }
        bool isPasswordValid= BCrypt.Net.BCrypt.Verify(password,user.password);
        // Add your password verification logic here
        // For example, using BCrypt.Net
        return isPasswordValid;
    }
}
