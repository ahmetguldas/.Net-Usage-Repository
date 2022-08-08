namespace CORE_Usage_Repository.Models.Repository
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ProjectContext _context;

        public EfProductRepository(ProjectContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products; //Ilgili ProjectContext class ina gider, ilgili DbSet satirindaki PropertyName'i Products olan satir ile ilgili tabloya baglanir ve verileri getirir.

        public Product GetById(int id)
        {
            return _context.Products.Find(id); //Find() metotu PK alaninda kullanilan veriyi ister geriye o satiri dondurur.
        }

        public bool UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteProduct(int id)
        {
            _context.Products.Remove(GetById(id));
            return _context.SaveChanges() > 0;
        }

        public bool InsertProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges() > 0; //savechanges metotu size int bir sonuc dondurur.onuda 0 ile karsilastiriyoruz. burayi arastir.
        }

        
    }
}
