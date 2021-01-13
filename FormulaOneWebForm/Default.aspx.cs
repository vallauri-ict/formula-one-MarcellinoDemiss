using FormulaOneDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaOneWebForm
{
    public partial class Default : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Inizializzazioni che vengono eseguite solo la prima volta che la pagina viene caricata
                DBTools myTools = new DBTools();
                lstTables.DataSource = myTools.getTableName();
                lstTables.DataBind();
                lstTables.SelectedIndex = 0;
                dgvItems.DataSource = myTools.getTableData(lstTables.SelectedItem.ToString());
                dgvItems.DataBind();
            }
        }

        protected void changeSelection(object sender, EventArgs e)
        {
            DBTools myTools = new DBTools();
            dgvItems.DataSource = myTools.getTableData(lstTables.SelectedItem.ToString());
            dgvItems.DataBind();
        }
    }
}