using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        // TODO: declare class variables for array and list here
        
        decimal [] invoiceTotals = new decimal[5];
        int invtotalsIndex = 0;
        List<decimal> invstotalslist = new List<decimal>();

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSubtotal.Text == "")
                {
                    MessageBox.Show(
                        "Subtotal is a required field.", "Entry Error");
                }
                else
                {
                    decimal subtotal = Decimal.Parse(txtSubtotal.Text);
                    if (subtotal > 0 && subtotal < 10000)
                    {
                        decimal discountPercent = 0m;
                        if (subtotal >= 500)
                            discountPercent = .2m;
                        else if (subtotal >= 250 & subtotal < 500)
                            discountPercent = .15m;
                        else if (subtotal >= 100 & subtotal < 250)
                            discountPercent = .1m;
                        decimal discountAmount = subtotal * discountPercent;
                        decimal invoiceTotal = subtotal - discountAmount;

                        discountAmount = Math.Round(discountAmount, 2);
                        invoiceTotal = Math.Round(invoiceTotal, 2);

                        
                        invoiceTotals[invtotalsIndex] = invoiceTotal;
                        invtotalsIndex++;
                        invstotalslist.Add(invoiceTotal);


                        txtDiscountPercent.Text = discountPercent.ToString("p1");
                        txtDiscountAmount.Text = discountAmount.ToString();
                        txtTotal.Text = invoiceTotal.ToString();

                    }
                    else
                    {
                        MessageBox.Show(
                            "Subtotal must be greater than 0 and less than 10,000.",
                            "Entry Error");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter a valid number for the Subtotal field.",
                    "Entry Error");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Invoice Total only take 5 elements.", "Index out of range Error");
            }
            txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // TODO: add code that displays dialog boxes here

            string Ttl = "";
            
            Array.Sort(invoiceTotals);
            invstotalslist.Sort();
            foreach (decimal total in invoiceTotals)
            foreach (decimal totl in invstotalslist)
                {
                
                if (total != 0)
                {
                    Ttl += total.ToString("c") + "\n";
                    
                }
            }
           
            MessageBox.Show(Ttl, "Order Totals-Array");
            MessageBox.Show(Ttl, "Order Totals-List");

            this.Close();
        }

    }
}
