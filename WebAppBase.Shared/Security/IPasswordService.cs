namespace WebAppBase.Shared.Security;

public interface IPasswordService
{
    /// <summary>
    /// Generates a password hash using SHA256 with salt
    /// </summary>
    /// <param name="password">Plain text password</param>
    /// <returns>Hashed password</returns>
    string HashPassword(string password);
    
    /// <summary>
    /// Verifies if the plain text password matches the stored hash
    /// </summary>
    /// <param name="password">Plain text password</param>
    /// <param name="hashedPassword">Stored hash from database</param>
    /// <returns>True if password is correct, False otherwise</returns>
    bool VerifyPassword(string password, string hashedPassword);
}