namespace CORE_Usage_Repository.Models.Repository
{
    public interface IProductRepository
    {
        //Urun Listemizi tutacagiz.
        IQueryable<Product> Products { get;}// sadece get metodu calissin, veriler set edilmesin istiyoruz.

    }
}
