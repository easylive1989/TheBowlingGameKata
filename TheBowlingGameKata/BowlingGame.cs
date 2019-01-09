namespace TheBowlingGameKata
{
    public class BowlingGame
    {
        private int _currentRoll;
        private int[] _rolls = new int[21];

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int GetScore()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private int SumOfBallInFrame(int frameIndex) => _rolls[frameIndex] + _rolls[frameIndex + 1];

        private int SpareBonus(int frameIndex) => _rolls[frameIndex + 2];

        private int StrikeBonus(int frameIndex) => _rolls[frameIndex + 1] + _rolls[frameIndex + 2];

        private bool IsStrike(int frameIndex) => _rolls[frameIndex] == 10;

        private bool IsSpare(int frameIndex) => _rolls[frameIndex] + _rolls[frameIndex+1] == 10;
    }
}