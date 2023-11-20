using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class ProductsScreen : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Andre\Documents\Pro-Natur Biomarkt GmbH.mdf;Integrated Security = True; Connect Timeout = 30");
        public ProductsScreen()
        {
            InitializeComponent();
            //Start
            ShowProducts();


        }



        private void btnProductSave_Click(object sender, EventArgs e)
        {
            if (tbProductName.Text == ""
               || tbProductBrand.Text == ""
               || tbProductPrice.Text == ""
               || cbProductCategory.Text == "")
            {
                MessageBox.Show("Fülle alle Felder aus!");
                return;
            }
            else
            {


                //save product name in database
                string productName = tbProductName.Text;
                string productBrand = tbProductBrand.Text;
                string productCategory = cbProductCategory.Text;
                string productPrice = tbProductPrice.Text;

                databaseConnection.Open();
                string query = string.Format("insert into Products values('{0}','{1}','{2}','{3}')", productName, productBrand, productCategory, productPrice);
                SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
                sqlCommand.ExecuteNonQuery();
                databaseConnection.Close();
                ClearAllFields();
                ShowProducts();
            }
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {

            ShowProducts();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {

            ShowProducts();
        }

        private void ShowProducts()
        {

            databaseConnection.Open();
            string query = "select * from Products";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            productsDGV.DataSource = dataSet.Tables[0];
            productsDGV.Columns[0].Visible = false;




            databaseConnection.Close();
        }

        private void ClearAllFields()
        {
            tbProductBrand.Clear();
            tbProductName.Clear();
            tbProductPrice.Clear();
            cbProductCategory.SelectedItem = null;
            cbProductCategory.Text = "";
        }
    }
}
