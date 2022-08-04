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
    }
}
