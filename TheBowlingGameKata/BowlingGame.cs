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
                currentFrame.SecondRoll = pins;
                if (lastFrame != null && !IsExtraFrame(last2Frame) && lastFrame.IsStrike())
                {
                    _score += pins;
                }
            }
            else
            {
                currentFrame = new Frame
                {
                    FirstRoll = pins
                };
                _frames.Add(currentFrame);

                if (lastFrame != null && !IsExtraFrame(lastFrame) && lastFrame.IsSpare())
                {
                    _score += currentFrame.FirstRoll;
                }
                if (last2Frame != null && !IsExtraFrame(last2Frame) && lastFrame.IsStrike() && last2Frame.IsStrike())
                {
                    _score += pins;
                }
            }

            if (_frames.Count <= 10)
            {
                _score += pins;
            }
        }

        private bool IsExtraFrame(Frame frame)
        {
            return _frames.IndexOf(frame) > 9;
        }

        public int GetScore()
        {
            return _score;
        }
    }
}