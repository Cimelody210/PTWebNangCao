using System;
using System.IO;
using System.Collection.Generic;
using System.Linq;
using System.Microsoft.AspNetCore.Mvc.RazorPages;
using System.Microsoft.Extensions.Logging;

namespace demo
{
    public class IndexModel: PageModel1
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {

        }

    }
    public tbNguoiDung GetById(string username)
    {
        return db.tbNguoiDung.SingleOrDefault(x => x.TaiKhoan == username);
        
    }
    public int Login(string username, string password, bool isLoginAdmin =false)
    {
        var result = db.tbNguoiDung.SingleOrDefault(x => x.TaiKhoan == username);
        if(result != null)
        {
            return 0;
        }
        else{
            if(isLoginAdmin== true)
            {
                if(result.MaBP == CommonConstants.ADMIN_GROUP || result.MaBP = ADMIN_GROUP.Ten){
                    if(result.TrangThai == false)
                        return -1;
                }
            }
        }
    }
}