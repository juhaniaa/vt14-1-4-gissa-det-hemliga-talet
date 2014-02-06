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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {
            if (IsValid) { 
                
                // då användaren klickar på knappen
                // och formuläret valideras 
                // innehåller userGuessBox ett tal mellan 1 och 100
                int userGuessed;
                userGuessed = int.Parse(userGuessBox.Text);
                var secretNumber = new Model.SecretNumber();
                var resultOfGuess = secretNumber.MakeGuess(userGuessed);

            }
        }
    }
}