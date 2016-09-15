using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlInject
{
    public class InjectionManager
    {
        #region Constants - Variables

        private static List<string> InjectionDic = null;
        private static string strRegex = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|2{1}[0-5]{2})\.([0-1]?[0-9]{1,2}|2{1}[0-5]{2})\."
       + @"([0-1]?[0-9]{1,2}|2{1}[0-5]{2})\.([0-1]?[0-9]{1,2}|2{1}[0-5]{2})){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        private static System.Globalization.CultureInfo culTr = null;
        private static Regex regMail = null;

        #endregion

        static InjectionManager()
        {
            InjectionDic = new List<string>();
            culTr = new System.Globalization.CultureInfo("tr-TR");
            regMail = new Regex(strRegex);
            GenerateDictionary();
        }

        private static void GenerateDictionary()
        {
            InjectionDic.Clear();
            InjectionDic.Add("delete");
            InjectionDic.Add("update");
            InjectionDic.Add("from");
            InjectionDic.Add("where");
            InjectionDic.Add("drop");
            InjectionDic.Add("truncate");
            InjectionDic.Add("insert");
            InjectionDic.Add("create");
            InjectionDic.Add("select");
            InjectionDic.Add("javascript");
            InjectionDic.Add("alert");
            InjectionDic.Add("acustart");
            InjectionDic.Add("acuend");
            InjectionDic.Add("create");
            InjectionDic.Add(";");
            InjectionDic.Add("'");
            InjectionDic.Add("--");
            InjectionDic.Add("*");
            InjectionDic.Add("/");
            InjectionDic.Add("(");
            InjectionDic.Add(")");
            InjectionDic.Add("script");
            InjectionDic.Add("<");
            InjectionDic.Add(">");
            InjectionDic.Add("+");
            InjectionDic.Add("?");
            //InjectionDic.Add("true");
            //InjectionDic.Add("false");
            InjectionDic.Add("into");
            InjectionDic.Add(" in ");
            InjectionDic.Add("table");
            InjectionDic.Add("union");
            InjectionDic.Add("div");
        }

        public static bool HasInjection(string keyWord)
        {
            bool rt = false;
            try
            {
                string[] words = keyWord.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (InjectionDic.Contains(words[i].Trim()))
                    {
                        return true;
                    }
                }

                for (int i = 0; i < InjectionDic.Count; i++)
                {
                    if (keyWord.Contains(InjectionDic[i]))
                    {
                        return true;
                    }
                }
            }
            catch { }
            return rt;
        }

        public static string RejectInjection(string injection)
        {
            string tmp = injection.ToLower(culTr);
            if (HasInjection(tmp))
            {
                return string.Empty;
            }
            return tmp;
        }

        public static int RejectInjection(int injection)
        {
            string tmp = injection.ToString().ToLower(culTr);
            if (HasInjection(tmp))
            {
                return 0;
            }
            return injection;
        }

        public static long RejectInjection(long injection)
        {
            string tmp = injection.ToString().ToLower(culTr);
            if (HasInjection(tmp))
            {
                return 0;
            }
            return injection;
        }

        public static bool RejectInjection(bool injection)
        {
            string tmp = injection.ToString().ToLower(culTr);
            if (HasInjection(tmp))
            {
                return true;
            }
            return injection;
        }

        public static double RejectInjection(double injection)
        {
            string tmp = injection.ToString().ToLower(culTr);
            if (HasInjection(tmp))
            {
                return 0;
            }
            return injection;
        }

        public static bool IsMailValid(string Email)
        {
            bool rt = false;
            try
            {
                if (regMail.IsMatch(Email))
                    rt = (true);
                else
                    rt = (false);
            }
            catch { }
            return rt;
        }
    }
}
