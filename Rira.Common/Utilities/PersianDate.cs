using System.Globalization;
using System.Text.RegularExpressions;

namespace Rira.Common.Utilities
{
    public class PersianDate
    {
        private static readonly PersianCalendar _persianCalendar = new();
        private static readonly Regex _shamsiDateRegex = new(@"^(13|14|15)\d{2}/(0[1-9]|1[0-2])/(0[1-9]|[12]\d|3[01])$", RegexOptions.Compiled);

        public static string ToShamsiDate(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue || dateTime == DateTime.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(dateTime), "Invalid DateTime value.");

            var persianCalendar = new PersianCalendar();

            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);

            return $"{year:0000}/{month:00}/{day:00}";
        }

        public static DateTime ToGregorianDate(string shamsiDate)
        {
            var parts = shamsiDate.Split('/');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            return _persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public static string LongStringDate(DateTime newDate)
        {
            return _persianCalendar.GetDayOfMonth(newDate).ToString() + " " + PersianDate.GetStringMonth(newDate) + " ماه سال " + _persianCalendar.GetYear(newDate).ToString();
        }

        public static string GetStringMonth(DateTime myDate)
        {
            int intMonth = _persianCalendar.GetMonth(myDate);

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

        public static string LongStringTime(DateTime myDate)
        {
            return "ساعت " + myDate.Hour.ToString() + " و " + myDate.Minute.ToString() + " دقیقه و " + myDate.Second + " ثانیه";
        }

        public static string LongStringDateTime(DateTime myDate)
        {
            return PersianDate.LongStringDate(myDate) + " " + PersianDate.LongStringTime(myDate);
        }

        public static bool IsValidBirthDate(string shamsiDate)
        {
            if (string.IsNullOrWhiteSpace(shamsiDate) || !_shamsiDateRegex.IsMatch(shamsiDate))
                return false;

            var parts = shamsiDate.Split('/');
            if (parts.Length != 3) return false;

            if (!int.TryParse(parts[0], out int year) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int day))
                return false;

            if (year < 1300 || year > 1500 || month < 1 || month > 12 || day < 1 || day > 31)
                return false;

            var persianCalendar = new PersianCalendar();
            var today = DateTime.Today;
            int todayYear = persianCalendar.GetYear(today);
            int todayMonth = persianCalendar.GetMonth(today);
            int todayDay = persianCalendar.GetDayOfMonth(today);

            if (year > todayYear ||
                (year == todayYear && month > todayMonth) ||
                (year == todayYear && month == todayMonth && day > todayDay))
            {
                return false;
            }

            return true;
        }

    }
}
