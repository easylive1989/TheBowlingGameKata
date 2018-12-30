using System;

namespace TheBowlingGameKata
{
    public class Frame
    {
        public int FirstRoll = -1;
        public int SecondRoll = -1;

        public bool IsSpare()
        {
            return FirstRoll + GetSecondScore() == 10;
        }

        private int GetSecondScore()
        {
            return SecondRoll == -1 ? 0 : SecondRoll;
        }

        internal bool IsStrike()
        {
            return FirstRoll == 10;
        }

        public bool HasSecondPin()
        {
            return !IsStrike() && FirstRoll != -1 && SecondRoll == -1;
        }

        public bool IsFinish()
        {
            return IsStrike() || (FirstRoll != -1 && SecondRoll != -1);
        }
    }
}