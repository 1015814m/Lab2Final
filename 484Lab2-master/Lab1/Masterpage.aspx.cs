using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnEmployee_Click(object sender, EventArgs e)
    {

        for (int i = 0; i < GridView1.Columns.Count; i++)
        {
            GridView1.Columns[i].Visible = true;
            
        }
    }

    protected void btnProject_Click(object sender, EventArgs e)
    {
        
        for (int i = 3; i < GridView1.Columns.Count; i++)
        {
            GridView1.Columns[i].Visible = false;
        }
    }

    protected void btnSkill_Click(object sender, EventArgs e)
    {

    }
}