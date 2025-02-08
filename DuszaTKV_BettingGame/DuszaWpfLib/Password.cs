using System.Security.Cryptography;
using System.Text.RegularExpressions;
using DuszaTKVGameLib.Exceptions;

namespace DuszaTKVGameLib;

public class Password
{
    public string password { get; set; }
    public bool isHashed { get; set; }
    public string HashedPassword => isHashed ? password : System.Text.Encoding.UTF8.GetString(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(password)));

    public void CheckSecurity()
    {
        if (GetSecurityLevel(password) != 31)
            throw new NotSecurePasswordException();
    }
    public Password(string password, bool isHashed = false)
    {
        this.password = password;
        if (this.password == "")
            throw new EmptyFieldException();
        this.isHashed = isHashed;
    }
    public static int GetSecurityLevel(string password)
    {
        var securityLevel = 0;
        if (Regex.IsMatch(password, "(?=.*[a-z])"))
            securityLevel += 1;
        if (Regex.IsMatch(password, "(?=.*[A-Z])"))
            securityLevel += 2;
        if (Regex.IsMatch(password, "(?=.*[0-9])"))
            securityLevel += 4;
        if (Regex.IsMatch(password, "(?=.*[!,@,#,$,%,^,&,*,?,_,~,-,(,)])"))
            securityLevel += 8;
        if (password.Length>=8)
            securityLevel += 16;
        return securityLevel;
    }
}