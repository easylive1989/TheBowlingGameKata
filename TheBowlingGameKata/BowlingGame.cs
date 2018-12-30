using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBowlingGameKata
{
    public class BowlingGame
    {
        private int _score;
        private List<Frame> _frames = new List<Frame>();

        public void Roll(int pins)
        {
            var last2Frame = _frames.Where(x => x.IsFinish()).Reverse().Skip(1).FirstOrDefault();
            var lastFrame = _frames.LastOrDefault(x => x.IsFinish());
            var currentFrame = _frames.Find(x => !x.IsFinish());
            if (currentFrame != null)
            {
                currentFrame.SetSecondRoll(pins);
                if (Frame.IsStrike(lastFrame))
                {
                    lastFrame.Score += currentFrame.SecondRoll;
                }
            }
            else
            {
                currentFrame = new Frame();
                currentFrame.SetFirstRoll(pins);
                _frames.Add(currentFrame);

                if (Frame.IsSpare(lastFrame))
                {
                    lastFrame.Score += currentFrame.FirstRoll;
                }
                if (Frame.IsStrike(last2Frame) && Frame.IsStrike(lastFrame))
                {
                    last2Frame.Score += currentFrame.FirstRoll;
                }
            }
        }
        
        public int GetScore()
        {
            return _frames.Take(10).Sum(x=>x.Score);
        }
    }
}