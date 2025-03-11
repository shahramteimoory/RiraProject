using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.Common.Utilities
{
    public class PersianDate
    {

        public static PersianCalendar myPersianCalender = new PersianCalendar();
        public static int IntDate()
        {
            return myPersianCalender.GetDayOfMonth(DateTime.Now) + myPersianCalender.GetMonth(DateTime.Now) * 100 + myPersianCalender.GetYear(DateTime.Now) * 10000;
        }

        public static int IntDate(DateTime newDate)
        {
            return myPersianCalender.GetDayOfMonth(newDate) + myPersianCalender.GetMonth(newDate) * 100 + myPersianCalender.GetYear(newDate) * 10000;
        }

        public static DateTime GetToday()
        {
            DateTime dtNow = DateTime.Now;
            DateTime myDT = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

            return myDT;
        }

        public static DateTime Default = DateTime.Parse("1000-01-01 00:00:00.0000000");

        public static string StringDate()
        {
            return myPersianCalender.GetYear(DateTime.Now).ToString() + "/" + myPersianCalender.GetMonth(DateTime.Now).ToString() + "/" + myPersianCalender.GetDayOfMonth(DateTime.Now).ToString();
        }

        public static string StringDate(DateTime newDate)
        {
            return myPersianCalender.GetYear(newDate).ToString() + "/" + myPersianCalender.GetMonth(newDate).ToString("00") + "/" + myPersianCalender.GetDayOfMonth(newDate).ToString("00");
        }



        public static string LongStringDate()
        {
            return myPersianCalender.GetDayOfMonth(DateTime.Now).ToString() + PersianDate.GetStringMonth() + " ماه سال " + myPersianCalender.GetYear(DateTime.Now).ToString();
        }

        public static string LongStringDate(DateTime newDate)
        {
            return myPersianCalender.GetDayOfMonth(newDate).ToString() + " " + PersianDate.GetStringMonth(newDate) + " ماه سال " + myPersianCalender.GetYear(newDate).ToString();
        }

        public static DateTime ConvertIntPersianDateToMildaiDate(int intDate)
        {
            DateTime myDate = new DateTime(intDate / 10000, (intDate / 100) % 100, intDate % 100, myPersianCalender);
            return myDate;
        }

        public static DateTime ConvertIntPersianDateToMiladiBirthDate(int intDate)
        {
            DateTime myDate = new DateTime(myPersianCalender.GetYear(DateTime.Now), (intDate / 100) % 100, intDate % 100, myPersianCalender);
            return myDate;
        }

        public static string GetTimeToBirthDate(int intDate)
        {
            DateTime myBirthDate = PersianDate.ConvertIntPersianDateToMiladiBirthDate(intDate);
            DateTime NowDateTime = DateTime.Now;

            double NumberDay = 0;

            if (NowDateTime.Date == myBirthDate.Date)
            {
                return "زادروزتان مبارک باد";
            }
            else
            {
                if (NowDateTime > myBirthDate)
                {
                    NumberDay = Math.Round((myBirthDate.AddYears(1) - NowDateTime).TotalDays) + 1;
                }
                else
                {
                    NumberDay = Math.Round((myBirthDate - NowDateTime).TotalDays) + 1;
                }


                if (NumberDay > 30)
                {
                    return Math.Round(NumberDay / 30).ToString() + " ماه تا تولدتان";
                }
                else
                {
                    return NumberDay + " روز تا تولدتان";
                }

            }

        }


        public static string GetTimeAgo(DateTime myDate)
        {
            double M = Math.Round((DateTime.Now - myDate).TotalMinutes);

            if (M < 1)
            {
                return "1 دقیقه قبل";
            }
            if (M >= 1 && M < 60)
            {
                return M + " دقیقه قبل";
            }
            else if (M >= 60 && M < 1440)
            {
                return Math.Round((DateTime.Now - myDate).TotalHours) + " ساعت قبل";
            }
            else if (M >= 1440 && M < 43200)
            {
                return Math.Round((DateTime.Now - myDate).TotalDays) + " روز قبل";
            }
            else if (M >= 43200 && M < 518400)
            {

                return Math.Round((DateTime.Now - myDate).TotalDays / 30) + " ماه قبل";
            }
            else
            {
                return Math.Round((DateTime.Now - myDate).TotalDays / 365) + " سال قبل";
            }
        }



        public static string GetStringMonth()
        {
            int intMonth = myPersianCalender.GetMonth(DateTime.Now);

            string strMonth = "";

            switch (intMonth)
            {
                case 1:
                    strMonth = "فروردین";
                    break;

                case 2:
                    strMonth = "اردیبهشت";
                    break;
                case 3:
                    strMonth = "خرداد";
                    break;
                case 4:
                    strMonth = "تیر";
                    break;
                case 5:
                    strMonth = "مرداد";
                    break;
                case 6:
                    strMonth = "شهریور";
                    break;
                case 7:
                    strMonth = "مهر";
                    break;
                case 8:
                    strMonth = "آبان";
                    break;
                case 9:
                    strMonth = "آذر";
                    break;
                case 10:
                    strMonth = "دی";
                    break;
                case 11:
                    strMonth = "بهمن";
                    break;
                case 12:
                    strMonth = "اسفند";
                    break;

                default:
                    break;

            }

            return strMonth;

        }

        public static string GetStringMonth(DateTime myDate)
        {
            int intMonth = myPersianCalender.GetMonth(myDate);

            string strMonth = "";

            switch (intMonth)
            {
                case 1:
                    strMonth = "فروردین";
                    break;

                case 2:
                    strMonth = "اردیبهشت";
                    break;
                case 3:
                    strMonth = "خرداد";
                    break;
                case 4:
                    strMonth = "تیر";
                    break;
                case 5:
                    strMonth = "مرداد";
                    break;
                case 6:
                    strMonth = "شهریور";
                    break;
                case 7:
                    strMonth = "مهر";
                    break;
                case 8:
                    strMonth = "آبان";
                    break;
                case 9:
                    strMonth = "آذر";
                    break;
                case 10:
                    strMonth = "دی";
                    break;
                case 11:
                    strMonth = "بهمن";
                    break;
                case 12:
                    strMonth = "اسفند";
                    break;

                default:
                    break;

            }

            return strMonth;

        }


        public static int IntTime()
        {
            return DateTime.Now.Hour * 10000 + DateTime.Now.Minute * 100 + DateTime.Now.Second;
        }

        public static int IntTime(DateTime myDate)
        {
            return myDate.Hour * 10000 + myDate.Minute * 100 + myDate.Second;
        }


        public static string StringTime()
        {
            return DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second;
        }

        public static string StringTime(DateTime myDate)
        {
            return myDate.Hour.ToString("00") + ":" + myDate.Minute.ToString("00") + ":" + myDate.Second.ToString("00");
        }


        public static string LongStringTime()
        {
            return "ساعت " + DateTime.Now.Hour.ToString() + " و " + DateTime.Now.Minute.ToString() + " دقیقه و " + DateTime.Now.Second + " ثانیه";
        }

        public static string LongStringTime(DateTime myDate)
        {
            return "ساعت " + myDate.Hour.ToString() + " و " + myDate.Minute.ToString() + " دقیقه و " + myDate.Second + " ثانیه";
        }

        public static string LongStringDateTime()
        {
            return PersianDate.LongStringDate() + " " + PersianDate.LongStringTime();
        }

        public static string LongStringDateTime(DateTime myDate)
        {
            return PersianDate.LongStringDate(myDate) + " " + PersianDate.LongStringTime(myDate);
        }

        public static string DateTimeForSP(string strDate, string Arg)
        {
            if (strDate is null)
            {
                return ", @" + Arg + "= null ";
            }
            else
            {

                if (Arg == "FromDate")
                {
                    return " , @" + Arg + " = '" + GetMiladiDate(strDate) + " 00:00:00'";
                }
                else
                {
                    return " , @" + Arg + " = '" + GetMiladiDate(strDate) + " 23:59:59'";
                }

            }
        }

        public static string GetMiladiDate(string strDate)
        {
            string[] strings = strDate.Split("/");

            DateTime dateTime = new DateTime(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), myPersianCalender);

            return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year;
        }

        public static DateTime GetMiladiDateTime(string strDate)
        {
            string[] strings = strDate.Split("/");

            DateTime dateTime = new DateTime(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), myPersianCalender);

            return dateTime;
        }

        public static bool PersianDateIsValid(string strDate)
        {
            try
            {
                string[] strings = strDate.Split("/");
                DateTime dateTime = new DateTime(int.Parse(strings[0]), int.Parse(strings[1]), int.Parse(strings[2]), myPersianCalender);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
