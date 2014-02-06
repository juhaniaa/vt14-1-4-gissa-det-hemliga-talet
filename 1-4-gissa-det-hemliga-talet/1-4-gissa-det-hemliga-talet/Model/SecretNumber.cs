using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_4_gissa_det_hemliga_talet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;
        const int MaxNumberOfGuesses = 7;
        Random rndNumber = new Random();

        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }
        public int? Number { 
            get
            {            
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            } 
            
            private set{} 
        }

        public Outcome Outcome { get; private set; }

        public IEnumerable<int> PreviousGuesses { 
            get{
                return _previousGuesses.AsReadOnly();
            } set{} 
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(7);
            Initialize();
        }

        public void Initialize() 
        {
            CanMakeGuess = true;
            _number = rndNumber.Next(1, 101);
            Count = 0;
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess) {

            bool insertGuess = true;

            // slut på gissningar
            if(Count == 7){
                throw new ArgumentOutOfRangeException();
            }

            if(1 <= guess || guess <= 100){
                
                // högt
                if(guess > _number){
                    Outcome = Outcome.High;
                }


                // lågt
                if (guess < _number) {
                    Outcome = Outcome.Low;
                }


                // rätt
                if (guess == _number)
                {
                    Outcome = Outcome.Correct;
                    CanMakeGuess = false;
                }

                if (Count == 6) {
                    CanMakeGuess = false;
                }

                // samma gissning som tidigare
                foreach (int tried in _previousGuesses) {
                    if (guess == tried)
                    {
                        Outcome = Outcome.PreviousGuess;
                        insertGuess = false;
                    }
                }                               
            }

            // om gissningen inte är mellan 1 och 100
            else{
                throw new ArgumentOutOfRangeException();
            }

            // om användaren inte gissade på ett tidigare värde
            if (insertGuess)
            {
                _previousGuesses.Add(guess);
                Count = Count + 1; 
            }

            return Outcome;
        }
    }
}