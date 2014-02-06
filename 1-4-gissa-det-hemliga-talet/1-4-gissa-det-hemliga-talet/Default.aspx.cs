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
        
        string[] messages = new string[6] { "Odefinierat", "för låg", "för hög", "helt rätt, grattis!", "slut på gissningar", "redan gissat på det talet" };


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
                 
                // om sessionen inte är lagrad
                if (Session["secretSession"] == null)
                     {

                    // skap nytt secretNumber
                    var secretNumber = new Model.SecretNumber();   

                    Session["secretSession"] = secretNumber;
                    secretNumber = Session["secretSession"] as Model.SecretNumber;                                                        
                }

                                                           
                // resultatet av gissningen, för högt eller lågt osv
                var resultOfGuess = mySecretProperty.MakeGuess(userGuessed);

                // om resultatet == Correct eller 7 gissningar är gjorda
                if(mySecretProperty.Count >= 7 || resultOfGuess.ToString() == "Correct")
                {
                    //mySecretProperty.CanMakeGuess = false;

                    if (mySecretProperty.Count >= 7 && resultOfGuess.ToString() != "Correct")
                    {
                        // presentera det hemliga talet
                        SecretNumberLabel.Text = "Tyvärr har du slut på gissningar, det hemliga talet var: "+ mySecretProperty.Number.ToString();
                    }

                    // Får ej fler gissningar göras
                    newNumberButton.Visible = true;
                    userGuessBox.Enabled = false;
                    GuessButton.Enabled = false;
                }

                if (resultOfGuess.ToString() == "PreviousGuess")
                {
                    LastGuessLabel.Text = String.Format("Du har {0}",messages[5]);                                        
                }
                else {
                    string answer = "";
                    if(resultOfGuess.ToString() == "Low"){
                        answer = messages[1];
                    }
                    if (resultOfGuess.ToString() == "High") {
                        answer = messages[2];
                    }
                    if (resultOfGuess.ToString() == "Correct") {                        
                        answer = messages[3];
                    }
                                         
                    LastGuessLabel.Text = String.Format("Din gissning var {0}", answer);                    
                }


                LabelPlaceHolder.Visible = true;

                // lägg till alla tidigare gissningar från PreviousGuesses egenskapen i label-elementet
                foreach (int guessTemp in mySecretProperty.PreviousGuesses)
                {
                    MadeGuessesLabel.Text = MadeGuessesLabel.Text + guessTemp.ToString() + ", ";
                }                                
            }
        }

        protected void newNumberButton_Click(object sender, EventArgs e)
        {
            // initiera ett nytt hemligt nummer
            mySecretProperty.Initialize();
        }
    }
}