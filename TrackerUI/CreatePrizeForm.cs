using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;

        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(placeNameValue.Text, placeNumberValue.Text, prizeAmountValue.Text, prizePercentageValue.Text);
                GlobalConfig.Connection.CreatePrize(model);
                callingForm.PrizeComplete(model);

                MessageBox.Show("Successfully created the prize.");
                this.Close();
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            int placeNumber = 0;
            decimal prizeAmount = 0;
            double prizePercentage = 0;

            if (prizeAmountValue.Text.Length == 0) prizeAmountValue.Text = "0";
            if (prizePercentageValue.Text.Length == 0) prizePercentageValue.Text = "0";

            bool isPlaceNumberValid = int.TryParse(placeNumberValue.Text, out placeNumber);
            bool isPrizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool isPrizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);
            bool hasBlankValue = (placeNameValue.Text.Length == 0 || (prizeAmount <= 0 && prizePercentage <= 0));

            isPlaceNumberValid &= (placeNumber >= 1);
            isPrizePercentageValid &= (prizePercentage >= 0 && prizePercentage <= 100);

            if (!isPlaceNumberValid || !isPrizeAmountValid || !isPrizePercentageValid || hasBlankValue)
            {
                output = false;
            }

            return output;
        }
    }
}
