using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDescriptionInvalid = "Araba açıklaması 2 karakterden kısa olamaz";
        public static string CarDailyPriceInvalid = "Araba Fiyatı 0tl den düşük olamaz";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string ReturnDateInavlid = "Kiralamak İstediğiniz Araba Henüz Teslim Edilmemiştir";
        public static string CarRented = "Araba Kiralandı";
        public static string CarDeliverd = "Araba teslim edildi";
        public static string ErrorCarDelivery = "Araba Teslim Etme İşlemi Başarısız";
        public static string CarImageLimitExceed = "bir arabanın en fazla beş resmi olabilir";
        public static string AuthorizationDenied = "erişim reddedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı sisteme önceden kayıtlı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserRegistered = "Kullanıcı keydedildi";
        public static string PaymentSuccess = "Ödeme Başarılı";
    }
}
