using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountManagement
{
    public partial class frmAddNewAccount : Form
    {
        private AccountBUS accbus;

        public frmAddNewAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AccountDTO acc = new AccountDTO();

            //1. map data from GUI
            acc.Fullname = txtFullname.Text;
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;
            acc.CreatedDate = dtpCreatedDate.Value;

            //2. validate data is ok or not?
            if(this.accbus.isValidFullname(acc) == false)
            {
                MessageBox.Show("Fullname is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFullname.Focus();
                return;
            }

            //3. insert to db
            if(this.accbus.insert(acc) == true)
            {
                MessageBox.Show("Account is inserted to DB sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Error when inserted new Account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            AccountDTO acc = new AccountDTO();

            //1. map data from GUI
            acc.Fullname = txtFullname.Text;
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;
            acc.CreatedDate = dtpCreatedDate.Value;

            //2. validate data is ok or not?
            if (this.accbus.isValidFullname(acc) == false)
            {
                MessageBox.Show("Fullname is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFullname.Focus();
                return;
            }

            //3. insert to db
            if (this.accbus.insert(acc) == true)
            {
                MessageBox.Show("Account is inserted to DB sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Error when inserted new Account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmAddNewAccount_Load(object sender, EventArgs e)
        {
            accbus = new AccountBUS();
        }
    }
}
