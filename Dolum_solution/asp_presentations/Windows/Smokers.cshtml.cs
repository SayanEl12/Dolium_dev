using lib_entities;
using lib_presentations.Interfaces;
using lib_utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentations.Windows;
public class SmokersModel : PageModel
{
    private ISmokersPresentation? iPresentation = null;

    public SmokersModel(ISmokersPresentation iPresentation)
    {
        try
        {
            this.iPresentation = iPresentation;
            Filter = new Smokers();
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    public IFormFile? FormFile { get; set; }
    [BindProperty] public Enumerables.Windows Action { get; set; }
    [BindProperty] public Smokers? Actual { get; set; }
    [BindProperty] public Smokers? Filter { get; set; }
    [BindProperty] public List<Smokers>? List { get; set; }

    // Handle the default GET request of the page
    public virtual void OnGet()
    {
        OnPostBtRefresh();
    }

    public void OnPostBtRefresh()
    {
        try
        {
            // Look for a session variable called "key" if this
            // Doesn't exists, it'll be intialized with "Tests"
            var session_variable = HttpContext.Session.GetString("key");
            if (String.IsNullOrEmpty(session_variable))
                HttpContext.Session.SetString("key", "Tests");
            
            // Check for the Detail property of Filter, if this
            // Is null, it'll be ""
            Filter!.Detail = Filter!.Detail ?? "";
            
            // Set the action to do as [GetList]
            Action = Enumerables.Windows.GetList;
            
            // Look and return a basic search
            var task = this.iPresentation!.Search(Filter!, "Detail");
            task.Wait();
            List = task.Result;
            
            //LoadComboBox();
            Actual = null;
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }

    public virtual void OnPostBtNew()
    {
        try
        {
            Action = Enumerables.Windows.Modify;
            //LoadComboBox();
            Actual = new Smokers();
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    
    public virtual void OnPostBtModify(string data)
    {
        try
        {
            OnPostBtRefresh();
            Action = Enumerables.Windows.Modify;
            Actual = List!.FirstOrDefault(x => x.Id.ToString() == data);
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    
    public virtual void OnPostBtSave()
    {
        try
        {
            Action = Enumerables.Windows.Modify;
            if (FormFile != null)
            {
                var memoryStream = new MemoryStream();
                FormFile.CopyToAsync(memoryStream).Wait();
                //Actual!.Imagen = EncodingHelper.ToString(memoryStream.ToArray());
                memoryStream.Dispose();
            }

            Task<Smokers>? task = null;
            if (Actual!.Id == 0)
                task = this.iPresentation!.Save(Actual);
            else
                task = this.iPresentation!.Modify(Actual);
            task.Wait();
            Actual = task.Result;
            Action = Enumerables.Windows.GetList;
            OnPostBtRefresh();
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }

    public virtual void OnPostBtDeleteVal(string data)
    {
        try
        {
            OnPostBtRefresh();
            Action = Enumerables.Windows.Delete;
            Actual = List!.FirstOrDefault(x => x.Id.ToString() == data);
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    
    public virtual void OnPostBtDelete()
    {
        try
        {
            var task = this.iPresentation!.Delete(Actual!);
            Actual = task.Result;
            OnPostBtRefresh();
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    
    public virtual void OnPostBtCancel()
    {
        try
        {
            Action = Enumerables.Windows.GetList;
            OnPostBtRefresh();
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    
    public virtual void OnPostBtClose()
    {
        try
        {
            if(Action == Enumerables.Windows.GetList)
                OnPostBtRefresh();
        }
        catch (Exception ex)
        {
            LogConverter.Log(ex, ViewData);
        }
    }
    
}