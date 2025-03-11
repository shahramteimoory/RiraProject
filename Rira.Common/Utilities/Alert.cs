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
    }
}
