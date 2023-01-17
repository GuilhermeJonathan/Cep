using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cep.Domain.Validations
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string value) where T : struct
        {
            T result;
            return Enum.TryParse(value, true, out result) ? result : default(T);
        }

        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string GetEnumName(this Enum value)
        {
            return value.ToString();
        }

        public static int GetEnumValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static T GetEnumValue<T>(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return default(T);

            return (T)Enum.Parse(typeof(T), value.RemoveDiacritics(), true);
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return s == null || s == string.Empty;
        }

        public static string ToStringOrEmpty(this string s)
        {
            return s == null ? string.Empty : s;
        }

        public static string RemoverCaracteresEspeciais(this string s)
        {
            return !s.IsNullOrEmpty() ? Regex.Replace(s, "[^0-9a-zA-Z]+", "") : String.Empty;
        }

        public static string SubstituirCaracteresEspeciais(this string str)
        {
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcento[i]);
            }
            /** Troca os caracteres especiais da string por "" **/
            string[] caracteresEspeciais = { "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\\\", "°", "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?", "[", "]", "{", "}", "=", "+", "§", "´", "`", "^", "~" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                str = str.Replace(caracteresEspeciais[i], "");
            }

            /** Troca os caracteres especiais da string por " " **/
            str = Regex.Replace(str, @"[^\w\.@-]", " ",
                                RegexOptions.None, TimeSpan.FromSeconds(1.5));

            return str.Trim();
        }

        public static string RemoverZeros(this string s)
        {
            return !s.IsNullOrEmpty() ? Regex.Replace(s, "0", "") : String.Empty;
        }

        public static string FormatCPF(this string s)
        {
            return Convert.ToUInt64(s).ToString(@"000\.000\.000\-00");
        }

        public static string FormatTelefone(this string s)
        {
            return Convert.ToUInt64(s).ToString(@"(00) 00000-0000");
        }

        public static string FormatCNPJ(this string s)
        {
            return Convert.ToUInt64(s).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatIE(this string s)
        {
            return Convert.ToUInt64(s).ToString(@"000\.000\.000\-00");
        }

        public static string Maisculo(this string parametro)
        {
            var retorno = parametro;
            if (!String.IsNullOrEmpty(parametro))
                retorno = parametro.ToUpper();

            return retorno;
        }

        public static void RemoveAll<T>(this ICollection<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source", "source is null.");

            source.ToList().ForEach(e => source.Remove(e));
        }

        public static bool IsFutureDate(this DateTime date)
        {
            return date > DateTime.Now;
        }

        public static bool IsNowDate(this DateTime date)
        {
            return date.Hour == DateTime.Now.Hour;
        }

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
