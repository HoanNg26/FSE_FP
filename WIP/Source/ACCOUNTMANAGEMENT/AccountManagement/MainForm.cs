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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewAccount frm = new frmAddNewAccount();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountList frm = new frmAccountList();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accountTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountTable frm = new frmAccountTable();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
