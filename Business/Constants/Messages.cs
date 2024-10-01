using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants;

public static class Messages
{
    public const string ProductListed = "Ürünler listelendi.";
    public const string ProductGetted = "Ürünler geldi.";
    public static string ProductAdded = "Ürün eklendi.";
    public static string ProductNameInvalid = "Ürün ismi geçersiz!";
    public static string ProductNotFound = "Ürün bulunamadı.";
    public static string ProductCounOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir!";
    public static string ProductUpdated = "Ürün güncellendi";
    public static string ProductNameExist = "Bu isimde bir ürün bulunmaktadır, lütfen başka bir isim deneyiniz!";
    public static string CatogryLimitExceded ="Kategori sayısı 15'i geçtiği için ürün ekleyemezsiniz!";
    public static string? AuthorizationDenied = "Yetkiniz yoktur!";
    public static string UserRegistered = "Kayıt oldu.";
    public static string UserNotFound = "Kullanıcı bulunamadı.";
    public static string PasswordError = "Şifre yanlış";
    public static string SuccessfulLogin = "Başarılı giriş";
    public static string UserAlreadyExists = "Bu email kullanılmaktadır!";
    public static string AccessTokenCreated ="Token oluşturuldu";
}