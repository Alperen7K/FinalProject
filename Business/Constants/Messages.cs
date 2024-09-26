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
}