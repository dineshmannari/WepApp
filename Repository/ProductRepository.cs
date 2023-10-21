using MannariEnterprises.Models;

public interface IProductRepository{
    Product GetById(int id);
    IEnumerable<Product> GetAll();

    void Add(Product product);
    void Update(Product product);
    void Delete(int id);

}

public class ProductRepository: IProductRepository{

    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context){
        _context=context;
    }
    public Product GetById(int id){
        return _context.Products.FirstOrDefault(a=>a.Id==id);
    }

    public IEnumerable<Product> GetAll(){
        return _context.Products.ToList();
    }

    public void Add(Product product){
        _context.Products.Add(product);
        _context.SaveChanges();
    }
    public void Update(Product product){
        _context.Products.Update(product);
        _context.SaveChanges();
    }
    public void Delete(int id){
       var product =_context.Products.FirstOrDefault(p=>p.Id== id);
       if(product!=null){
        _context.Products.Remove(product);
        _context.SaveChanges();
       }
    }
}