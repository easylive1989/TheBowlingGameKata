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
                if (lastFrame != null && !IsExtraFrame(last2Frame) && lastFrame.IsStrike())
                {
                    lastFrame.Score += currentFrame.SecondRoll;
                }
            }
            else
            {
                currentFrame = new Frame();
                currentFrame.SetFirstRoll(pins);
                _frames.Add(currentFrame);

                if (lastFrame != null && !IsExtraFrame(lastFrame) && lastFrame.IsSpare())
                {
                    lastFrame.Score += currentFrame.FirstRoll;
                }
                if (last2Frame != null && !IsExtraFrame(last2Frame) && lastFrame.IsStrike() && last2Frame.IsStrike())
                {
                    last2Frame.Score += currentFrame.FirstRoll;
                }
            }
        }

        private bool IsExtraFrame(Frame frame)
        {
            return _frames.IndexOf(frame) > 9;
        }

        public int GetScore()
        {
            return _frames.Take(10).Sum(x=>x.Score);
        }
    }
}