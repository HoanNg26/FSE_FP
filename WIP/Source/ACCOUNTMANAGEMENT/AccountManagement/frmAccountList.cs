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
    public partial class frmAccountList : Form
    {
        private AccountBUS accbus;
        public frmAccountList()
        {
            InitializeComponent();
        }

        private void frmAccountList_Load(object sender, EventArgs e)
        {
            this.accbus = new AccountBUS();

            this.loadAccountListAndBindingToCombo();
        }
        private void loadAccountListAndBindingToCombo()
        {
            // load account list from db
            List<AccountDTO> accountList = new List<AccountDTO>();
            if (this.accbus.selectAll(accountList) == false)
            {
                MessageBox.Show("Accounts on DB are not fetched.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnDelete.Enabled = false;
                this.btnUpdate.Enabled = false;
                return;
            }
            //bind to combobox
            this.cbAccountList.DataSource = new BindingSource(accountList, string.Empty);
            this.cbAccountList.DisplayMember = "Fullname";
            this.cbAccountList.ValueMember = "Username";
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.cbAccountList.DataSource];
            myCurrencyManager.Refresh();
            if (accountList.Count > 0)
                this.cbAccountList.SelectedIndex = 0;
        }
        private void cbAccountList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AccountDTO acc = (AccountDTO)this.cbAccountList.SelectedItem;
                this.txtFullname.Text = acc.Fullname;
                this.txtUsername.Text = acc.Username;
                this.txtPassword.Text = acc.Password;
                this.dtpCreatedDate.Value = acc.CreatedDate;

            }catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

            //3. update to db
            if (this.accbus.update(acc) == true)
            {
                this.loadAccountListAndBindingToCombo();
                MessageBox.Show("Account is updated to DB sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Error when updated a Account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AccountDTO acc = new AccountDTO();

            //1. map data from GUI
            acc.Fullname = txtFullname.Text;
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;
            acc.CreatedDate = dtpCreatedDate.Value;

            //2. delete from db
            if (this.accbus.delete(acc) == true)
            {
                this.loadAccountListAndBindingToCombo();
                MessageBox.Show("Account is deleted from DB sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Error when deleting Account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
