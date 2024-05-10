using System;
using System.IO;
using System.Collection.Generic;
using System.Linq;
using System.Microsoft.AspNetCore.Mvc.RazorPages;
using System.Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace demo
{
    LopKetNoi ketnoi  =new LopKetNoi();
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
    public void load(string tendangnhap)
    {
        string sql = "select A,....";
        DataTable dt = ketnoi.docdulieu(sql);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    public void Page_load(object sender, EventArgs e)
    {
        if(isPostBack) return;
        string tendangnhap = Session["username"]+ "";
        if(tendangnhap != ""){
            load(tendangnhap);
        }
    }
    public class X(){
        try
        {
            String connectionstring  ="Data Source:///ff";
            using(SqlConnection connect = new SqlConnection(connectionstring))
            {
                connect.Open();
                String sql = "UPDATE client SET name = @name WHERE";
                using(SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameter.AddWithValue("@name", clientInfo.name);
                    command.Parameter.AddWithValue("@email", clientInfo.email);
                    command.Parameter.AddWithValue("@phone", clientInfo.phone);
                    command.Parameter.AddWithValue("@address", clientInfo.address);
                    command.Parameter.AddWithValue("@id", clientInfo.id);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch(Exception e)
        {
            error = e.Message;
            return;
        }
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