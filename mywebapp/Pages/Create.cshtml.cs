using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace mywebapp.Pages
{
  public class CreateModel : PageModel
  {
    private readonly AppDbContext _db;

    private ILogger<CreateModel> Log;

    [BindProperty]
    public Customer Customer { get; set; }

    [TempData]
    public string Message { get; set;  }

    public CreateModel(AppDbContext db, ILogger<CreateModel> log){
      _db = db;
      Log = log;
    }
   
    public async Task<IActionResult> onPostAsync()
    {
      if(!ModelState.IsValid){
        return Page();
      }

      _db.Customers.Add(Customer);
      await _db.SaveChangesAsync();
      var msg = $"Customer {Customer.Name} added!";
      Message = msg;
      Log.LogCritical(msg);

      return RedirectToPage("/Index");
    }
  }
}