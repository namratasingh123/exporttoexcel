using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exporttoexcel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                bindGrid();

            }
        }
        public void bindGrid()

        {

            DataTable dt = new DataTable();

            dt.Columns.Add("SNO");

            dt.Columns.Add("Department");

            dt.Columns.Add("EmpName");

            dt.Columns.Add("EmpNo");

            dt.Columns.Add("Location");

            dt.Columns.Add("Designation");

            for (int i = 0; i < 10; i++)

            {

                DataRow dr = dt.NewRow();

                dr["SNO"] = i;

                dr["Department"] = "Department-" + i;

                dr["EmpName"] = "EmpName-" + i;

                dr["EmpNo"] = "EmpNo-" + i;

                dr["Location"] = "Location-" + i;

                dr["Designation"] = "Designation-" + i;

                dt.Rows.Add(dr);

                dt.AcceptChanges();

            }

            gv.DataSource = dt;

            gv.DataBind();

        }



        protected void btnExport_Click(object sender, EventArgs e)

        {

            Response.Clear();

            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

            Response.Charset = "";

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            divexport.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());

            Response.End();

        }



        //don’t forget to add this method , other wise we will get Control gv of type 

        //'GridView' must be placed inside a form tag with runat=server.





        public override void VerifyRenderingInServerForm(Control control)

        {

        }

    }


}
