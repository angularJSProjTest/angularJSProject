﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.userinfotb
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (this.txtname.Text.Trim().Length == 0)
            {
                strErr += "name不能为空！\\n";
            }
            if (!PageValidate.IsNumber(txtage.Text))
            {
                strErr += "age格式错误！\\n";
            }
            if (this.txtphone.Text.Trim().Length == 0)
            {
                strErr += "phone不能为空！\\n";
            }
            if (this.txtadress.Text.Trim().Length == 0)
            {
                strErr += "adress不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string name = this.txtname.Text;
            int age = int.Parse(this.txtage.Text);
            string phone = this.txtphone.Text;
            string adress = this.txtadress.Text;

            Maticsoft.Model.userinfotb model = new Maticsoft.Model.userinfotb();
            model.name = name;
            model.age = age;
            model.phone = phone;
            model.adress = adress;

            Maticsoft.BLL.userinfotb bll = new Maticsoft.BLL.userinfotb();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "add.aspx");

        }


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
