namespace CORE_Usage_Repository.Models.Repository
{
    public interface IProductRepository
    {
        //Urun Listemizi tutacagiz.
        IQueryable<Product> Products { get;}// sadece get metodu calissin, veriler set edilmesin istiyoruz.

        //Insert isleminde kullanilacak metotu yaziyoruz.
        bool InsertProduct(Product product);

        Product GetById(int id);
        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);

    }
}
