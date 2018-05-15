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
    public partial class frmAccountTable : Form
    {
        private AccountBUS accbus;
        public frmAccountTable()
        {
            InitializeComponent();
        }

        private void frmAccountTable_Load(object sender, EventArgs e)
        {
            this.accbus = new AccountBUS();

            this.loadAccountsAndBindToTable();
        }

        private void loadAccountsAndBindToTable()
        {
            //1. Load Accounts from DB
            List<AccountDTO> accountList = new List<AccountDTO>();
            if (this.accbus.selectAll(accountList) == false)
            {
                MessageBox.Show("Accounts on DB are not fetched.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //2. Binding data to Grid view
            this.dgvAccountTbl.Columns.Clear();
            this.dgvAccountTbl.DataSource = null;

            this.dgvAccountTbl.AutoGenerateColumns = false;
            this.dgvAccountTbl.AllowUserToAddRows = false;
            this.dgvAccountTbl.DataSource = accountList;

            DataGridViewTextBoxColumn fullnameCol = new DataGridViewTextBoxColumn();
            fullnameCol.Name = "Fullname";
            fullnameCol.HeaderText = "Full Name";
            fullnameCol.DataPropertyName = "Fullname";
            this.dgvAccountTbl.Columns.Add(fullnameCol);

            DataGridViewTextBoxColumn usernameCol = new DataGridViewTextBoxColumn();
            usernameCol.Name = "Username";
            usernameCol.HeaderText = "User Name";
            usernameCol.DataPropertyName = "Username";
            this.dgvAccountTbl.Columns.Add(usernameCol);

            DataGridViewTextBoxColumn passwordCol = new DataGridViewTextBoxColumn();
            passwordCol.Name = "password";
            passwordCol.HeaderText = "Password";
            passwordCol.DataPropertyName = "password";
            this.dgvAccountTbl.Columns.Add(passwordCol);

            DataGridViewTextBoxColumn createddateCol = new DataGridViewTextBoxColumn();
            createddateCol.Name = "CreatedDate";
            createddateCol.HeaderText = "Created Date";
            createddateCol.DataPropertyName = "CreatedDate";
            this.dgvAccountTbl.Columns.Add(createddateCol);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[this.dgvAccountTbl.DataSource];
            myCurrencyManager.Refresh();
        }
    }
}
