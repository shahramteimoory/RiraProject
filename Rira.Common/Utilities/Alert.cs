using System.ComponentModel;

namespace Rira.Common.Utilities
{
    public static class Alert
    {

        public enum EnumEntity
        {
            [Description("شخص")]
            Person,
        }

        public static string GetInsertAlert(EnumEntity entity)
        {
            return $"{entity.GetDescription()} با موفقیت ثبت گردید";
        }
        public static string GetDeleteAlert(EnumEntity entity)
        {
            return $"{entity.GetDescription()} با موفقیت حذف گردید";
        }
        public static string GetUpdateAlert(EnumEntity entity)
        {
            return $"{entity.GetDescription()} با موفقیت ویرایش گردید";
        }
        public enum Public
        {
            [Description("خطایی سمت سرور رخ داده است")]
            InternalServerError,
            [Description("موفق")]
            Success,
            [Description("ناموفق")]
            UnSuccess,
            [Description("موردی یافت نشد")]
            NotFound,
            [Description("خطای احراز هویت")]
            AuthError,
            [Description("بازیابی انجام شد")]
            Recovery,
            [Description("امکان ثبت رکورد تکراری وجود ندارد")]
            Duplicate,
        }

        public enum Field
        {
            [Description("نام")]
            FirstName,
            [Description("نام  خانوادگی")]
            LastName,
            [Description("کدملی")]
            NationalCode,
            [Description("تاریخ تولد")]
            BithOfDay,
        }
        public static string GetValidateAlert(Field field)
        {
            return $"{field.GetDescription()} را بدرستی وارد کنید";

        }
        public static string EmptyValidateAlert(Field field)
        {
            return $"{field.GetDescription()} را وارد کنید";

        }
    }

    public static class AlertConstats
    {
        public const string TaskSuccess = "عملیات موفقیت‌آمیز بود.";
        public const string TaskCreated = "ایجاد با موفقیت انجام شد.";
        public const string BadRequestMessage = "داده‌های ارسالی نامعتبر هستند.";
        public const string ConflictMessage = "رکورد موردنظر قبلاً ثبت شده است.";
        public const string InternalServerErrorMessage = "خطای داخلی سرور رخ داده است.";
        public const string NotFound = "موردی یافت نشد";
    }
}
