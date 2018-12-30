using System;

namespace TheBowlingGameKata
{
    public class Frame
    {
        public int FirstRoll { get; private set; } = -1;
        public int SecondRoll { get; private set; } = -1;
        public int Score;

        public bool IsSpare()
        {
            return FirstRoll + GetSecondScore() == 10;
        }

        private int GetSecondScore()
        {
            return SecondRoll == -1 ? 0 : SecondRoll;
        }

        public bool IsStrike()
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

        public void SetFirstRoll(int pins)
        {
            FirstRoll = pins;
            Score += pins;
        }

        public void SetSecondRoll(int pins)
        {
            SecondRoll = pins;
            Score += pins;
        }

        public static bool IsSpare(Frame frame)
        {
            return frame != null && frame.IsSpare();
        }

        public static bool IsStrike(Frame frame)
        {
            return frame != null && frame.IsStrike();
        }
    }
}