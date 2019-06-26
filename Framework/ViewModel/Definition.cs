using System;
using System.Collections.Generic;
using System.Net;

namespace Framework.ViewModel
{
    public static partial class Definition
    {
        public static class Url
        {
            public static readonly string Login = "/Yonetim/Authentication/Login";
            public static readonly string Main = "/Main/Index";
            public static readonly string ReturnUrl = "/Yonetim/Main";

            public static class Yonetim
            {
                public static readonly string Main = "/Yonetim/Main/Index";
            }
            public static class Authentication
            {
                public static readonly string Settings = "/Yonetim/Authentication/Settings";
            }

            public static class Announcement
            {
                public static readonly string List = "/Yonetim/Announcement/List";
            }

            public static class Dues
            {
                public static readonly string List = "/Yonetim/Dues/List";
            }

            public static class Layout
            {
                public static readonly string Empty = "";
                public static readonly string Item = "~/Areas/Yonetim/Views/Shared/_ItemBaseLayout.cshtml";
                public static readonly string Dashboard = "~/Areas/Yonetim/Views/Shared/_Layout.cshtml";
                public static readonly string Main = "~/Views/Shared/_Layout.cshtml";
                public static readonly string Base = "~/Views/Shared/_BaseLayout.cshtml";
                public static readonly string Grid = "~/Areas/Yonetim/Views/Shared/_GridLayout.cshtml";
                public static readonly string Dropzone = "~/Areas/Yonetim/Views/Shared/_Dropzone.cshtml";
            }

            public static class UserInRole
            {
                public static readonly string Item = "/Yonetim/UserInRole/Item";
            }

            public static class User
            {
                public static readonly string Item = "/Yonetim/User/Item";
            }
        }

        public static class Category
        {
            public static readonly Guid HomePageLightBox = new Guid("2401D775-5A53-42D3-B3AE-3E6A4D989C24");
            public static readonly Guid GelirGiderBilanco = new Guid("676F86BA-8372-48A0-8B5C-793ECDA0C6FF");
            public static readonly Guid Mevzuat = new Guid("18A7AF8D-F355-4264-85A1-7C9055B06983");
            public static readonly Guid YonetimKuruluCalismalari = new Guid("28C5FB47-3EA4-4507-8139-BCC5FCE0BB8E");
            public static readonly Guid GenelKurulKararlari = new Guid("BF17F686-455F-4F53-9108-959046AD7A4B");
            public static readonly Guid DenetimKuruluRaporlari = new Guid("3d86546a-df9d-4b51-88db-9f98f93224c4");
        }

        public static class Role
        {
            public static readonly Guid System = new Guid("6cfdd7fb-cbb1-4823-b945-4302136a3bc0");
            public static readonly Guid Administrator = new Guid("1ce57293-677f-4862-b106-751497f76b22");
            public static readonly Guid Contributor = new Guid("3503f093-2b17-4ef9-8662-4a9998ef0756");
            public static readonly Guid Member = new Guid("d0ddc03a-e34d-4677-b5ec-7894a313a670");
        }

        public class Message
        {
            public static readonly string Deleted = "Başarılı bir şekilde silindi";
            public static readonly string Created = "Başarılı bir şekilde oluşturuldu";
            public static readonly string Updated = "Başarılı bir şekilde güncellendi";
            public static readonly string Error = "Bir hata ile karşılaşıldı, en kısa zamanda destek verilecektir.";
            public static readonly string NotFound = "İstekte bulunulan sayfaya erişim sağlanamadı.";

            public static string Get(int httpStatusCode)
            {
                var httpStatusCodeEnum = (HttpStatusCode)httpStatusCode;

                switch (httpStatusCodeEnum)
                {
                    case HttpStatusCode.NotFound:
                        return NotFound;
                    default:
                        return Error;
                }
            }

            public class Item
            {
                public static readonly string NotFound = "Item bulunamadı";
            }

            public class Dropzone
            {
                public static readonly string Error = "Yükleme sırasında bir hata oluştu";
            }

            public class Authentication
            {
                public static readonly string Successful = "Başarılı bir şekilde giriş yapıldı";
                public static readonly string Unauthorized = "Yetkisiz erişim sağlandı ve kayıt altına alındı";
                public static readonly string NotFound = "Kullanıcı bulunamadı";
                public static readonly string RedirectionToSettings = "Lütfen şifrenizi değiştiriniz.";
            }

            public class Logout
            {
                public static readonly string Successful = "Başarılı bir şekilde çıkış yapıldı";
            }
        }
    }
}
