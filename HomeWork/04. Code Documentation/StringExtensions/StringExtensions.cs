namespace StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class for string utilities
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Encrypts the provided string to MD5 hash.
        /// </summary>
        /// <param name="input"> The string for encrypting.</param>
        /// <returns>encrypted string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            foreach (byte google in data)
            {
                builder.Append(google.ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Compares the string to the stringTrueValues array (which contains only "true").
        /// </summary>
        /// <param name="input">The string for comparing.</param>
        /// <returns>Returns true if the string contains any of the "stringTrueValues".</returns>
        public static bool ContainsTrueValue(this string input)////Name was changed, because /stringTrueValues contains only strings used for "true". 
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Parse the string to short.
        /// </summary>
        /// <param name="input">The string for parsing.</param>
        /// <returns>Returns the string as short Integer</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Parse the string to Integer.
        /// </summary>
        /// <param name="input">The string for parsing.</param>
        /// <returns>Returns the string as Integer.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Parse the string to long.
        /// </summary>
        /// <param name="input">The string for parsing.</param>
        /// <returns>Returns the string as long.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Parse the string to DateTime.
        /// </summary>
        /// <param name="input">The string for parsing.</param>
        /// <returns>Returns the string as DateTime.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Changes the first letter from the string to capital.
        /// </summary>
        /// <param name="input">The string, which first letter will be changed to Upper.</param>
        /// <returns>Returns the first letter as a capital letter.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Perform a substring operation on the provided string.
        /// </summary>
        /// <param name="input">The string containing startString and endString.</param>
        /// <param name="startString">Starting point for the substring.</param>
        /// <param name="endString">End point for the substring.</param>
        /// <param name="startFrom">Default is 0.</param>
        /// <returns>Returns a substring from startString to endString.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;

            ////if the specified start String does not exist, return empty
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            ////get the index position for the startString, if it exists
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            ////get the index position for the endString, if it exists
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);

            return endPosition == -1 ? string.Empty : input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts characters from Cyrillic to Latin.
        /// </summary>
        /// <param name="input">String with Cyrillic characters.</param>
        /// <returns>Returns a latin string.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(
                    bulgarianLetters[i],
                    latinRepresentationsOfBulgarianLetters[i]);

                input = input.Replace(
                    bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts characters from Latin to Cyrillic.
        /// </summary>
        /// <param name="input">String with Latin characters.</param>
        /// <returns>Returns a cyrillic string.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(
                    latinLetters[i],
                    bulgarianRepresentationOfLatinKeyboard[i]);

                input = input.Replace(
                    latinLetters[i].ToUpper(),
                    bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Replaces all Latin characters with Cyrillic for a username.
        /// </summary>
        /// <param name="input">String username with Latin characters.</param>
        /// <returns>Returns an username in Cyrillic characters.</returns>
        public static string ToValidCyrillicUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Replaces all Cyrillic characters with Latin for a filename.
        /// </summary>
        /// <param name="input">String filename in Cyrillic characters.</param>
        /// <returns>Returns a valid file name in Latin characters.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Perform a substring operation, starting from 0 to charsCount.
        /// </summary>
        /// <param name="input">The string, on which the substring operation will be performed.</param>
        /// <param name="charsCount">The number of characters to be returned from the string.</param>
        /// <returns>Returns the specified characters from the string</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the extension from the filename.
        /// </summary>
        /// <param name="fileName">The filename which holds the extension.</param>
        /// <returns>Returns the file name extension.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Changes the file extension to a content type file extension.
        /// </summary>
        /// <param name="fileExtension">The fileExtension which will be renamed.</param>
        /// <returns>Returns a file extension with a content type extension.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Parses the string to a byte array.
        /// </summary>
        /// <param name="input">The string used for parsing to byte array.</param>
        /// <returns>Returns the string as a byte array.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}