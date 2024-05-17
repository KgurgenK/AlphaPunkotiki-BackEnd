using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AlphaPunkotiki.Infrastructure.Extensions.Interfaces;
using AlphaPunkotiki.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace AlphaPunkotiki.Infrastructure.Extensions;

public class PasswordHashCalculator(IOptions<PasswordsSaltOptions> passwordSalt) : IPasswordHashCalculator
{
    public string Calculate(string password)
    {
        var saltedPasswordBytes = Encoding.UTF8.GetBytes(password + passwordSalt.Value.Value);

        return Convert.ToHexString(SHA256.HashData(saltedPasswordBytes));
    }
}
