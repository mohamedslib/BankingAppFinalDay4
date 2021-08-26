using BankingDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form
    {
        private readonly BankAccount _account;
        public Form1()
        {
            InitializeComponent();
            _account = new BankAccount(
                new SuperBonusCalculator(),
                new WindowsNarc()
                );

            Text = _account.GetBalance().ToString("c");
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);
        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }
        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                decimal amount = decimal.Parse(txtAmount.Text);
                op(amount);
                Text = _account.GetBalance().ToString("c");
            }
            catch (FormatException)
            {

                MessageBox.Show("Enter a number, moron!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
            catch (TransactionOutOfRangeException)
            {
                MessageBox.Show("Enter a number above zero, idiot.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }

        
    }

    public class WindowsNarc : INarcOnWithdrawals
    {
        public void TellTheMan(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show($"You are withdrawing {amountToWithdraw:c}.", "Narcing on you!");
        }
    }
}
