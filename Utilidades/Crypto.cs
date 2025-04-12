namespace Utilidades;

public class Crypto
{
    public static string HashPasswordConBcrypt(string password, int workFactor)
    {
        // Generar el hash de la contraseña usando BCrypt
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
    }

    public static bool VerifyPasswordConBcrypt(string password, string hashedPassword)
    {
        // Verificar si la contraseña coincide con el hash
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    } 
}