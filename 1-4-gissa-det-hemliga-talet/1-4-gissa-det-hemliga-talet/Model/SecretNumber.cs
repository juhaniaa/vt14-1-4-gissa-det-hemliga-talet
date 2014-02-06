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
        private readonly List<int> _previousGuesses;
        const int MaxNumberOfGuesses = 7;
        Random rndNumber = new Random();


        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }
        public int? Number { get{
            if (CanMakeGuess)
                {
                return null;
                }
                return _number;
        } set{} }
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
            _number = rndNumber.Next(1, 101);
            Count = 0;
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess) {

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
                }

                // samma som tidigare
                // om guess == något i _previousGuesses
                

            }
            else{
                throw new ArgumentOutOfRangeException();
            }

            _previousGuesses.Add(guess);
            Count = Count + 1;
            return Outcome;
        }
    }
}