using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms_proto
{
    public partial class CustomerForm: Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        string setDefaultCustInfo(TextBox tb) => tb.Text == "" ? "not available." : tb.Text;
        private void create_cust_button_Click(object sender, EventArgs e)
        {
            var dummyId = 1;
            var customer = Customer.Create(dummyId, setDefaultCustInfo(firstname_tb), setDefaultCustInfo(lastname_tb));

            var customer_info = "Id: " + customer._id + "| Firstname:" + customer._firstname + " | LastName:" + customer._lastname;
            MessageBox.Show(customer_info);
        }
    }
}
