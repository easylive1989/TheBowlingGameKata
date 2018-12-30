using System;

namespace TheBowlingGameKata
{
    public class Frame
    {
        public int FirstPins = -1;
        public int SecondPins = -1;

        public bool IsSpare()
        {
            return FirstPins + GetSecondScore() == 10;
        }

        private int GetSecondScore()
        {
            return SecondPins == -1 ? 0 : SecondPins;
        }

        internal bool IsStrike()
        {
            return FirstPins == 10;
        }

        public bool HasSecondPin()
        {
            return !IsStrike() && FirstPins != -1 && SecondPins == -1;
        }

        public bool IsFinish()
        {
            return IsStrike() || (FirstPins != -1 && SecondPins != -1);
        }
    }
}