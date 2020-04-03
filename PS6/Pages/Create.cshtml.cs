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
    public class CreateModel : MyPageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }
        public void OnGet()
        {

        }
        public CreateModel(IConfiguration configuration) : base(configuration)
        {


        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            CreateProduct(newProduct);
            
            return RedirectToPage("List");
        }
    }
}