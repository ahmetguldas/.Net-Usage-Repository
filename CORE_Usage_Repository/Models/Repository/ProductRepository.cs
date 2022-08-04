namespace CORE_Usage_Repository.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        { 
            new Product (){ID=1, ProductName="Salatalik",Description="Taze dalindan sofraya",Category="Sebzeler", Price=10.99M},
            new Product (){ID=2, ProductName="Kiraz",Description="Afyon kirazi",Category="Meyveler", Price=14.99M},
            new Product (){ID=3, ProductName="Elma",Description="Amasya",Category="Meyveler", Price=9.99M},
            new Product (){ID=4, ProductName="Domates",Description="Diyarbakir",Category="Sebzeler", Price=18.99M},
        }.AsQueryable();//Soldaki IQueryable Sagdaki List oldugundan casting islemi ile hatayi cozuyoruz.


    }
}
