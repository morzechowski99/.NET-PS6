using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS6.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS6.Models
{
    public class MyPageModel : PageModel
    {
        public ProductDB productDB;
        public IConfiguration _configuration { get; set; }
        public MyPageModel(IConfiguration configuration)
        {
            _configuration = configuration;
            productDB = new ProductDB();
        }
        public void LoadDB()
        {
            productDB.Load(_configuration);
        }
        public void DeleteProduct(int id)
        {
            productDB.Delete(id, _configuration);
        }
        public void CreateProduct(Product p)
        {
            productDB.Create(p,_configuration);
        }
        public Product GetProductById(int id)
        {
            return productDB.GetProduct(id, _configuration);
        }
        public void ChangeProduct(Product p)
        {
            productDB.Change(p, _configuration);
        }
    }
}
