using System;
using System.IO;
using System.Collection.Generic;
using System.Linq;
using System.Microsoft.AspNetCore.Mvc.RazorPages;
using System.Microsoft.Extensions.Logging;

namespace dhController
{
    private const string FeaturePlaceHolder = "$FEATURE";

    public FeatureLayoutViewEngine()
    {
        var viewEnginePaths = new[]{
            "~/Feature/" + FeaturePlaceHolder + "/{0}.cshtml",
            "~/Feature/" + FeaturePlaceHolder + "/{0}.vbhtml",
            "~/Feature/Shared/{0}.cshtml"
        };
        base.PartialViewLoactionFormat. = viewEnginePaths;
        base.ViewLocationFormat = viewEnginePaths;
        base.MasterLocationFormat = viewEnginePaths;
    }

    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        public UserController(DataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> users = await dataStore.User.Include(users => users.Article).ToListAsync();
            return Ok(users);
        }
    }
    
    [HttpPost]
    public ActionResult Index(FormCollection collection)
    {
        string name = Request.Form["Name"].ToString();
        string designation = Request.Form["Designation"].ToString();
        string city = Request.Form["City"].ToString();
        string user_name = Request.Form["User_name"].ToString();

        name  = collection["Name"].ToString();
    }
}