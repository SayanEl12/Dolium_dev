using lib_utilities;
using lib_comunications;
using lib_presentations.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace asp_presentations.Pages.Windows;
public class LogInModel : PageModel
{
    private IAuthenticatePresentation iPresentation = null;

    public LogInModel(IAuthenticatePresentation iPresentation)
    {
        this.iPresentation = iPresentation;
    }
    
    [BindProperty] public string? Email { get; set; }
    [BindProperty] public string? Password { get; set; }
    private Dictionary<string, object> data;
    private bool IsLoged = false;
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            string answer = "";
            
            answer = await iPresentation.Authenticate(Email, Password);
            Console.WriteLine(answer);
            
            return RedirectToPage("./Client/HomePageModel");
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
        return RedirectToPage("./");
    }
}