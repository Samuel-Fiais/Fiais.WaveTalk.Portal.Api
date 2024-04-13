using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Fiais.WaveTalk.Portal.Application.Extensions;

public static class StringExtensions
{
    public static string Encrypt(this string? str)
    {
        UnicodeEncoding encoding = new();
        byte[] hashBytes;
        using (HashAlgorithm hash = SHA1.Create())
        {
            hashBytes = hash.ComputeHash(encoding.GetBytes(str!));
        }

        var value = new StringBuilder(hashBytes.Length * 2);
        foreach (var b in hashBytes) value.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);

        return value.ToString();
    }
}