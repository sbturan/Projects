using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web;

public class DataReader
{
    public static string GetString(object input)
	{
		try
		{
            if (input.GetType().ToString() == "System.DateTime")
                //return ((DateTime)input).ToString("yyyy-MM-dd HH:mm:ss");
                return ((DateTime)input).ToString("dd.MM.yyyy HH:mm:ss");
            else
			    return input.ToString();
		}
		catch { return ""; }
	}

    public static string GetString(object input, bool dbCheck)
	{
		try
		{
			string str = GetString(input);
            //return str.Replace("'", "''").Replace("\\", string.Empty).Replace("/*", string.Empty).Replace("*/", string.Empty);
            return str.Replace("\\", string.Empty).Replace("/*", string.Empty).Replace("*/", string.Empty);
		}
		catch { return ""; }
	}

    public static string ToEnglish(string str)
    {
        char[] array = str.ToCharArray();
        str = "";
        for (int i = 0; i < array.Length; i++)
        {
            switch (array[i])
            {
                case 'ç':
                    array[i] = 'c'; break;
                case 'ð':
                    array[i] = 'g'; break;
                case 'ý':
                    array[i] = 'i'; break;
                case 'ö':
                    array[i] = 'o'; break;
                case 'þ':
                    array[i] = 's'; break;
                case 'ü':
                    array[i] = 'u'; break;
                case 'Ç':
                    array[i] = 'C'; break;
                case 'Ð':
                    array[i] = 'G'; break;
                case 'Ý':
                    array[i] = 'I'; break;
                case 'Ö':
                    array[i] = 'O'; break;
                case 'Þ':
                    array[i] = 'S'; break;
                case 'Ü':
                    array[i] = 'U'; break;
                default:
                    break;
            }
            str += array[i];
        }
        return str.Trim().Replace(".", "");
    }

   
    public static string GetColor(object input)
    {
        string temp = GetString(input);
        if (temp.Equals(string.Empty))
            return "#ffffff";
        if (!temp.Substring(0, 1).Equals("#"))
            return "#ffffff";
        if (temp.Length != 7)
            return "#ffffff";
        return temp;
    }

	public static bool GetBoolean(object input)
	{
		try { return (Convert.ToBoolean(input)); }
		catch { return false; }
	}

	public static Int32 GetInt32(object input)
	{
		try { return Int32.Parse(input.ToString()); }
		catch { return 0; }
	}

    public static Int64 GetInt64(object input)
    {
        try { return Int64.Parse(input.ToString()); }
        catch { return 0; }
    }

    public static Double GetDouble(object input)
    {
        try { return Convert.ToDouble(input.ToString()); }
        catch { return 0; }
    }

    public static float GetFloat(object input)
    {
        try { return float.Parse(input.ToString()); }
        catch { return 0; }
    }

	public static DateTime GetDateTime(object input)
	{
		try { return ( DateTime.Parse(input.ToString()) ); }
		catch { return System.DateTime.Parse("2005-01-01 01:00:00"); }
	}

	public static Decimal GetDecimal(object input)
	{
		try { return Decimal.Parse(input.ToString()); }
		catch { return 0; }
	}

	public static bool IsEmail(string inputEmail)
	{
		string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
			 @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
			 @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
		Regex re = new Regex(strRegex);
		if(re.IsMatch(inputEmail))
			return ( true );
		else
			return ( false );
	}

    public static String UTF8ByteArrayToString(Byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        String constructedString = encoding.GetString(characters);
        return (constructedString);
    }

    public static Byte[] StringToUTF8ByteArray(String pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        Byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
}