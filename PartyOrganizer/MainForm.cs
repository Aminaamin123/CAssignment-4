using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartyOrganizer
{
    public partial class MainForm : Form
    {
        private PartyManager pm;
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            // sets the default values to lbl, txt etc 
            this.Text = " My Party planner";
            lblNr.Text = string.Empty;
            lblFees.Text = string.Empty;
            lblCost.Text = string.Empty;
            lblSurplus.Text = string.Empty;
            lblList.Text = "Guest List";
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false; 
            btnAdd.Enabled = false;
            txtNrGuest.Text = string.Empty;
            txtFee.Text = string.Empty;
            txtCost.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;

        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            bool done = NewPartyInfo();

            if (done)
            {

                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                btnAdd.Enabled = true;
                // enable add guests. 
            }
            //UpdateLog();
            //TODO enble click on other btn
        }

        private bool NewPartyInfo()
        {

            bool success = true;

            int maxGuests = ReadInt(txtNrGuest.Text, out success);
            if (!success)
            {
                MessageBox.Show("The max guest value is invaild!", "Error");
                return false;
            }
            double costPerPerson = ReadDouble(txtCost.Text, out success);
            if (!success)
            {
                MessageBox.Show("The cost per person value is invaild!", "Error");
                return false;
            }

            double feePerPerson = ReadDouble(txtFee.Text, out success);
            if (!success)
            {
                MessageBox.Show("The fee per person value is invaild!", "Error");
                return false;
            }

            pm = new PartyManager(maxGuests);
            pm.Fee = feePerPerson;
            pm.Cost = costPerPerson;
            return true;

        }

        private int ReadInt(string str, out bool success)
        { // check if int correctly input
            int value = -1;
            success = false;
            if (int.TryParse(str, out value))
                success = true;
            return value;
        }


        private double ReadDouble(string str, out bool success)
        { // read value as double
            double value = -1.00;
            success = false;
            if (double.TryParse(str, out value))
                success = true;
            return value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool done = GuestInfo();

            if (done)
            {
                bool ok = pm.AddNewGuest(txtFirstName.Text, txtLastName.Text);
               
                if (ok)
                {
                    // calc totat cost and fee -> display
                    UpdateGUI();
                    // reload the display list}
                }
            }
        }

        private void UpdateGUI()
        {
            listBoxGuest.Items.Clear();
            string[] TheList = pm.GetGuestList();
            if (TheList != null )
            {
                for (int i = 0; i < TheList.Length; i++)
                {
                    if (!String.IsNullOrEmpty(TheList[i]))
                    {
                        listBoxGuest.Items.Add(TheList[i]);
                    }
                }

            }
            lblNr.Text = pm.NumOfGuests().ToString();
            lblCost.Text = pm.CalcTotalCost().ToString();
            lblFees.Text = pm.CalcTotalFee().ToString();
            lblSurplus.Text = pm.CalcSD().ToString();
        }
        private bool GuestInfo()
        {

            if (String.IsNullOrEmpty(txtFirstName.Text)){
                MessageBox.Show("Firstname value is invaild!", "Error");
                return false;
            }
            if (String.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Lastname value is invaild!", "Error");
                return false;
            }

            return true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int index = listBoxGuest.SelectedIndex;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool ok = false; 

            int index = listBoxGuest.SelectedIndex;
            if (index != -1)
            {
                ok = pm.DeleteAt(index);
            }
            else if(pm.NumOfGuests() > 0)
            {
                MessageBox.Show("Select a guest to remove from the list");
                
            }
            else
            {
                MessageBox.Show("No guest in the guest list");
            }


            if (ok)
            {
                UpdateGUI();
            }
        }
    }
}
