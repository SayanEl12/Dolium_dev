using lib_entities;
using lib_presentations.Interfaces;
using lib_utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentations.Pages.Windows.Client;
public class HomePageModel : PageModel
{
    private ISmokersPresentation iSmokersPresentation = null;
    private IImagesPresentation iImagesPresentation = null;
    
    public HomePageModel(ISmokersPresentation iSmokersPresentation, IImagesPresentation iImagesPresentation)
    {
        try
        {
            this.iSmokersPresentation = iSmokersPresentation;
            this.iImagesPresentation = iImagesPresentation;
            FilterSmokers = new Smokers();
            FilterIMages = new Images();
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    public IFormFile? FormFile { get; set; }
    [BindProperty] public Enumerables.Client Action { get; set; }
    [BindProperty] public Smokers? ActualSmokers { get; set; }
    [BindProperty] public Images? ActualImages { get; set; }
    [BindProperty] public Smokers? FilterSmokers { get; set; }
    [BindProperty] public Images? FilterIMages { get; set; }
    [BindProperty] public List<Smokers>? ListSmokers { get; set; }
    [BindProperty] public List<Images>? ListImages { get; set; }
    
    public void OnGet()
    {
        OnPostBtRefresh();
    }

    public void OnPostBtRefresh()
    {
        try
        {
            var session_variable = HttpContext.Session.GetString("key");
            if (String.IsNullOrEmpty(session_variable))
                HttpContext.Session.SetString("key", "Tests");
            
            FilterSmokers!.Detail = FilterSmokers!.Detail ?? "";
            
            Action = Enumerables.Client.HomePage;
            
            var taskSmokers = this.iSmokersPresentation!.Search(FilterSmokers!, "Detail");
            taskSmokers.Wait();
            ListSmokers = taskSmokers.Result;
            
            ActualSmokers = null;
        }
        catch (Exception e)
        {
            LogConverter.Log(e, ViewData);
        }
    }

    public void OnPostBtProduct(string data)
    {
        OnPostBtRefresh();
    }
}