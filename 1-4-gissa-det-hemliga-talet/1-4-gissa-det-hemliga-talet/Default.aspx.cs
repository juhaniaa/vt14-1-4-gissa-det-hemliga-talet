using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_4_gissa_det_hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {
        public Model.SecretNumber mySecretProperty
        {
            get { return Session["secretSession"] as Model.SecretNumber; }
            set { Session["secretSession"] = value; }
    
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // då användaren klickar på knappen
        protected void GuessButton_Click(object sender, EventArgs e)
        {
            // och formuläret validerats
            if (IsValid) {                                
                 
                // innehåller userGuessBox.Text ett tal mellan 1 och 100
                int userGuessed;
                userGuessed = int.Parse(userGuessBox.Text);
                 
                // om sessionen är lagrad
                if (Session["secretSession"] == null)
                     {

                    // skap nytt secretNumber
                    var secretNumber = new Model.SecretNumber();   

                    Session["secretSession"] = secretNumber;
                    secretNumber = Session["secretSession"] as Model.SecretNumber;                                                        
                }

                                                           
                    // resultatet av gissningen, för högt eller lågt osv
                    var resultOfGuess = mySecretProperty.MakeGuess(userGuessed);
                    LastGuessLabel.Text = resultOfGuess.ToString();

                    LabelPlaceHolder.Visible = true;

                    // lägg till alla tidigare gissningar från PreviousGuesses egenskapen
                    foreach (int guessTemp in mySecretProperty.PreviousGuesses)
                    {
                        MadeGuessesLabel.Text = MadeGuessesLabel.Text + guessTemp.ToString() + ", ";
                    }

                
                

            }
        }
    }
}