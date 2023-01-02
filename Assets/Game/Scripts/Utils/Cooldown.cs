// TimerDown  15 sec -> 0 sec
// after creat - isEnd = true 
namespace Game.Scripts.Utils
{
    public class Cooldown
    {
        public bool IsEnd { get { return PastTime >= _s; } }
        public bool IsRun { get { return PastTime <= _s; } }
        public float PastTime { set; get; }
        private float _s;
        public float S
        {
            get => _s;
            set
            {
                _s = value;
                PastTime = value;
            }
        }
        // return value in range(0, 101+)
        public float ProgressPercent { get { return (PastTime / _s) * 100; } }
        // return value in range(100, -0)
        public float ProgressPercentInvert { get { return 100 - ProgressPercent; } }


        public void Update(float deltaTime)
        {
            if (PastTime <= _s) PastTime += deltaTime;
        }

        public void Run() => PastTime = 0;
    }
}
