using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS6.Models;

namespace PS6.Pages
{
    public class ListModel : MyPageModel
    {
        public List<Product> productList;
        [BindProperty]
        public int id { get; set; }
        public void OnGet()
        {
            LoadDB();
            productList = productDB.List();
        }
        public ListModel(IConfiguration configuration) : base (configuration)
        {
            

        }
        public IActionResult OnPost()
        {


            return RedirectToPage("Edit", new { id = id });
        }
        public IActionResult OnPostDelete()
        {
            LoadDB();
            DeleteProduct(id);
            
            return RedirectToPage("List");
        }
    }
}