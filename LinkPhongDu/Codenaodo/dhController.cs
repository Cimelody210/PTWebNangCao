using System;
using System.IO;
using System.Collection.Generic;
using System.Linq;
using System.Microsoft.AspNetCore.Mvc.RazorPages;
using System.Microsoft.Extensions.Logging;

namespace dhController
{
    private const string FeaturePlaceHolder = "$FEATURE";

    public static List<Alumo> alu_list  = new List<Alumo>{
        new Alumo{
            id= 1,
            normne = "Abreto",
            nApPaterno = "caseas",
            ApPaterno = "las",
            FecAlta = DateTime.Parse(DateTime.Today.ToString()),
            Edad= 30
        },
        new Alumo{
            normne = "Joe Biden",
            nApPaterno = "Washington DC",
            ApPaterno = "Ilasdd",
            id= 21,
            FecAlta = DateTime.Parse(DateTime.Today.ToString()),
            Edad= 40
        }
    };
    [TypeConverter(typeof(VertexConverter))]
    public class vertex: ExpandableObjectConverter
    {
        public override bool CanConverter(ITypeDescriptionContext context, Type sourcetype)
        {
            return true;
        }
        public override object ConvertFrom(ITypeDescriptionContext context, CultureInfo cult)
        {
            const string PATTERN = "!@#$%^&*()_WERTYUI!@#$%^&*()"
            Match match = Regex.Match(value.ToString(), PATTERN);
            if(match.Sucess)
            {
                Vertex v= new Vertex();
                v.X = int.Parse(match.Groups["X"].Value);
                v.Y = int.Parse(match.Groups["Y"].Value);
                v.Z = int.Parse(match.Groups["Z"].Value);
                return v;
            }
        }
    }

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
        
        // Service lifetimes
        var builder =  WebAppication.CreateBuilder(args);
        builder.Services.AddTransient<ProductService>();
        builder.Services.AddScopes<ProductService>();
        builder.Services.AddSingleton<ProductService>();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> users = await dataStore.User.Include(users => users.Article).ToListAsync();
            return Ok(users);
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(FormCollection collection)
    {
        string name = Request.Form["Name"].ToString();
        string designation = Request.Form["Designation"].ToString();
        string city = Request.Form["City"].ToString();
        string user_name = Request.Form["User_name"].ToString();
        

        name  = collection["Name"].ToString();
    }
}