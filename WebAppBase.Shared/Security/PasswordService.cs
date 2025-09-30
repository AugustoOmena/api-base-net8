using System.Security.Cryptography;
using System.Text;

namespace WebAppBase.Shared.Security;

public class PasswordService : IPasswordService
{
    /// <summary>
    /// Generates a password hash using SHA256 with salt
    /// </summary>
    /// <param name="password">Plain text password</param>
    /// <returns>Password hash in format: salt:hash</returns>
    public string HashPassword(string password)
    {
        // Generate a random 32-byte salt
        var salt = GenerateSalt();
        
        // Combine password with salt and generate hash
        var hash = HashPasswordWithSalt(password, salt);
        
        // Return in "salt:hash" format for easy verification
        return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }
    
    /// <summary>
    /// Verifies if the plain text password matches the stored hash
    /// </summary>
    /// <param name="password">Plain text password</param>
    /// <param name="hashedPassword">Stored hash from database in "salt:hash" format</param>
    /// <returns>True if password is correct, False otherwise</returns>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        try
        {
            // Separate salt from hash
            var parts = hashedPassword.Split(':');
            if (parts.Length != 2)
                return false;
            
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = Convert.FromBase64String(parts[1]);
            
            // Generate hash of provided password with same salt
            var computedHash = HashPasswordWithSalt(password, salt);
            
            // Compare hashes in timing-safe manner
            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }
        catch
        {
            // If verification error occurs (invalid format), return false
            return false;
        }
    }
    
    /// <summary>
    /// Generates a random salt
    /// </summary>
    /// <returns>Salt byte array</returns>
    private static byte[] GenerateSalt()
    {
        var salt = new byte[32]; // 256 bits
        RandomNumberGenerator.Fill(salt);
        return salt;
    }
    
    /// <summary>
    /// Generates hash of password combined with salt using SHA256
    /// </summary>
    /// <param name="password">Plain text password</param>
    /// <param name="salt">Salt bytes</param>
    /// <returns>Password hash</returns>
    private static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var combined = new byte[passwordBytes.Length + salt.Length];
        
        // Combine password + salt
        Array.Copy(passwordBytes, 0, combined, 0, passwordBytes.Length);
        Array.Copy(salt, 0, combined, passwordBytes.Length, salt.Length);
        
        // Generate SHA256 hash
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(combined);
    }
}