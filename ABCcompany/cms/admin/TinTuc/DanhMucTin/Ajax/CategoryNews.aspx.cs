﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_admin_TinTuc_DanhMucTin_Ajax_CategoryNews : System.Web.UI.Page
{

    string thaotac = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Code kiểm tra đăng nhập tại đây sau đó mới thực hiện các thao tác dưới
        //Kiểm tra nếu đã đăng nhập thì mới cho vào trang này
        if (Session["DangNhap"] != null && Session["DangNhap"].ToString() == "1")
        {
            //Đã đăng nhập
        }
        else
        {
            //Nếu chưa đăng nhập --> return để dừng không cho thực hiện các câu lệnh bên dưới
            return;
        }
        if (Request.Params["ThaoTac"] != null)
        {
            thaotac = Request.Params["ThaoTac"];
        }

        switch (thaotac)
        {
            case "DeleteCategoryNews":
                DeleteCategoryNews();
                break;

        }
    }

    private void DeleteCategoryNews()
    {
        string newscode = "";
        if (Request.Params["newscode"] != null)
        {
            newscode = Request.Params["newscode"];

            //Thực hiện code xóa
            //B1: Xóa ảnh đại diện đã lưu trên server - tạm b
            //B2: Xóa dữ liệu trên sqlserver
            abcompany.CategoryNews.CategoryNews_Delete(newscode);

            // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
            Response.Write("1");
        }
    }
}