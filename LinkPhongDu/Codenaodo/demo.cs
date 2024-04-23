using System;
using System.IO;
using System.Collection.Generic;


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