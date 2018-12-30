using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBowlingGameKata
{
    public class BowlingGame
    {
        private readonly int _score;
        private List<Frame> _frames = new List<Frame>();

        public void Roll(int pins)
        {
            var last2Frame = GetLast2Frame();
            var lastFrame = GetLastFrame();
            if (Frame.IsFinish(lastFrame))
            {
                var frame = CreateFrame(pins);

                if (Frame.IsSpare(lastFrame))
                {
                    lastFrame.Score += frame.FirstRoll;
                }
                if (Frame.IsStrike(last2Frame) && Frame.IsStrike(lastFrame))
                {
                    last2Frame.Score += frame.FirstRoll;
                }
            }
            else
            {
                lastFrame.SetSecondRoll(pins);
                if (Frame.IsStrike(last2Frame))
                {
                    last2Frame.Score += lastFrame.SecondRoll;
                }
            }
        }

        private Frame CreateFrame(int pins)
        {
            var frame = new Frame();
            frame.SetFirstRoll(pins);
            _frames.Add(frame);
            return frame;
        }

        private Frame GetLast2Frame()
        {
            return _frames.Count > 1 ? _frames.Skip(_frames.Count - 2).FirstOrDefault() : null;
        }

        private Frame GetLastFrame()
        {
            return _frames.LastOrDefault();
        }

        public int GetScore()
        {
            return _frames.Take(10).Sum(x=>x.Score);
        }
    }
}