using System.Security.Cryptography;

namespace HabiTech.Services.Crypto;

public class HashSalt 
{
	public string? Hash { get; set; }
	public string? Salt { get; set; }
	
	public HashSalt(int size, string password)
	{
		var saltBytes = new byte[size];
		#pragma warning disable SYSLIB0023
		var provider = new RNGCryptoServiceProvider();
		provider.GetNonZeroBytes(saltBytes);
		var salt = Convert.ToBase64String(saltBytes);

		#pragma warning disable SYSLIB0041
		var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
		var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
		
		Hash = hashPassword;
		Salt = salt;
		
		Console.WriteLine(hashPassword);
		Console.WriteLine(salt);
		
	}
	
	public HashSalt()
	{
	}
	
	public bool VerifyPassword(string password, string hash, string salt)
{
	var saltBytes = Convert.FromBase64String(salt);
	var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
	return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == hash;
}
	// private static readonly Random random = new Random();
	
	// private static string SaltGenerator(int size) 
	// {
	// 	const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
	// 	// return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
	// 	return new string(Enumerable.Range(1, size).Select(_ => chars[random.Next(chars.Length)]).ToArray());
		
	// }
}