using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SakovetsMidterm
{
    public partial class Form1 : Form
    {
        Double dblResult; //global variable
        Char charPreviousOperation; //global variable
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dblResult = 0; //set default value
            lblError.Text = ""; //clear out error
            txtDisplay.Focus(); //start program with focus on the textbox, ready for user input
        }

        private void clearError() //clears error that doesn't go away after user sees it
        {
            if (lblError.Text != String.Empty) //check if there is an error message in the error label
            {
                lblError.Text = String.Empty; //if there is, erase it so user isn't stuck with error message
            }
            else
            {
                //this will only run if user keeps clicking something that will give him an error message, and it won't go away
            }
        }

        private void NumberClick(Button button)
        {
            if(txtDisplay.TextLength <= 14) //check to see if there is enough room left in the textbox before adding something into it
            {
                txtDisplay.Text += button.Text; //takes the text property from a button and adds it into the txtDisplay textbox
            }
            clearError();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            NumberClick(btnOne);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            NumberClick(btnTwo);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            NumberClick(btnThree);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            NumberClick(btnFour);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            NumberClick(btnFive);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            NumberClick(btnSix);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            NumberClick(btnSeven);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            NumberClick(btnEight);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            NumberClick(btnNine);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            NumberClick(btnZero);
        }

        private void OperatorClickEvent(object sender, EventArgs e)
        {
            Double dblInputValue; //create variable to store what's in the textbox to then add/sun/mul/div by the dblResult value
            if (Double.TryParse(txtDisplay.Text, out dblInputValue)) //try to convert whats in the textbox to a double, if successful run following code:
            {
                Char charOperation = (sender as Button).Text[0]; //take the first character from button pressed and assign it to charOperation

                //convert user input into 
                lblError.Text = ""; //if user has gotten this far, clear out error text because entered data is valid
                if (charOperation == 'C') //check if user clicked on clear button
                {
                    //perform following actions if user clicked on clear button
                    txtDisplay.Clear(); //clear out textbox
                    dblResult = 0; //reset value of dblResult
                    txtDisplay.Focus(); //set focus to textbox
                }
                else if (charPreviousOperation == '+') //check if previous operation user clicked on was addition
                {
                    dblResult += dblInputValue; //add current value in to dblResult
                }
                else if (charPreviousOperation == '-') //if previous operation clicked was subtraction
                {
                    dblResult -= dblInputValue; //subtract whats in the textbox from dblResult
                }
                else if (charPreviousOperation == '*') //check if previous operation clicked was multiplication
                {
                    dblResult *= dblInputValue; //mulitply dblResult by the value in the textbox
                }
                else if (charPreviousOperation == '/') //check if previous operation clicked was division
                {
                    if (dblInputValue == 0) //check if user is trying to divide my zero
                    {
                        lblError.Text = "Cannot divide by zero"; //show error message
                        txtDisplay.Clear(); //clear out textbox
                        txtDisplay.Focus();
                    }
                    dblResult /= dblInputValue; //divide dblResult by the value in the textbox
                }
                else //if the equals button was clicked (it's the only other option this function can apply to)
                {
                    dblResult = dblInputValue; //after performing one of the previous operations, get the answer
                }
                charPreviousOperation = charOperation; //set previous operation to what was just clicked
                txtDisplay.Text = charOperation == '=' ? dblResult.ToString() : "0"; //if equals button clicked show total, otherwise show 0 in the textbox
            }
            else //if user input is not valid, show error message and delete user input
            {
                lblError.Text = "Entry must be numeric"; //shows error message
                txtDisplay.Clear(); //clear textbox
                txtDisplay.Focus(); //focus on textbox
            }
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Contains(".")) //if there is a decimal point in the operation you won't be able to add a second one
            {
                lblError.Text = "Decimal point already in operation"; //show error message
            }
            else
            {
                NumberClick(btnDecimal); //if there is no decimal point in the operation yet, place one into the textbox
            }
            
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            //unnecessary code commented out
            //if(txtDisplay.Text[0].Equals("0"))
            //{
            //    txtDisplay.Clear();
            //}
        }
    }
}
