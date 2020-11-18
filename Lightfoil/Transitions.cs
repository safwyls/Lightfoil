using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lightfoil
{
    public static class Transitions
    {
        public class Boing
        {
            public int Time { get; set; } = 300;
            public int BackForthCount { get; set; } = 2;

            public string String
            {
                get
                {
                    return $"TrBoing<{Time}, {BackForthCount}>";
                }
            }

            public Boing()
            {
            }

            public Boing(int time, int backForthCount)
            {
                Time = time;
                BackForthCount = backForthCount;
            }
        }

        public class ColorCycle
        {
            public int WipeInTime { get; set; } = 3000;
            public int RpmStart { get; set; } = 0;
            public int RpmEnd { get; set; } = 6000;

            public ColorCycle()
            {
            }

            public ColorCycle(int wipeInTime, int rpmStart, int rpmEnd)
            {
                WipeInTime = wipeInTime;
                RpmStart = rpmStart;
                RpmEnd = rpmEnd;
            }
        }
        
        public class Concat
        {
            public List<string> Transitions { get; set; } = new List<string>();
            public List<Color> Intermediates { get; set; } = new List<Color>();

            public string String 
            { 
                get 
                {
                   return BuildString();
                }
                
                private set 
                { 
                } 
            }

            private string BuildString()
            {
                string internalStr = "";
                if (Transitions.Count - Intermediates.Count != 1)
                    throw new Exception($"Mismatching number of transitions and intermediate colors; {Transitions.Count} transitions, {Intermediates.Count} colors");
                for (int i = 0; i < Transitions.Count; i++)
                {
                    if (i != Transitions.Count - 1)
                        internalStr += Transitions[i] + ", " + Intermediates[i] + ", ";
                    else
                        internalStr += Transitions[i];
                }

                return $"TrConcat<{internalStr}>";
            }

            public Concat()
            {
            }

            public Concat(string transition1, Color color, string transition2)
            {
                Transitions.Add(transition1);
                Transitions.Add(transition2);
                Intermediates.Add(color);
            }
        }

        public class Delay
        {
            public int Time { get; set; } = 500;
            
            public string String
            {
                get
                {
                    return $"TrDelay<{Time}>";
                }
            }

            public Delay()
            {
            }

            public Delay(int time)
            {
                Time = time;
            }
        }

        public class Fade
        {
            public int Time { get; set; } = 300;

            public string String
            {
                get
                {
                    return $"TrFade<{Time}>";
                }
            }

            public Fade()
            {
            }

            public Fade(int time)
            {
                Time = time;
            }
        }

        public class Instant
        {
            public static string String
            {
                get
                {
                    return "TrInstant<>";
                }
            }

            public Instant()
            {
            }
        }

        public class Join
        {
            public List<string> Transitions { get; set; } = new List<string>();

            public string String
            {
                get
                {
                    return BuildString();
                }
            }

            private string BuildString()
            {
                string internalStr = "";
                foreach (string transition in Transitions)
                {
                    internalStr += transition + ", ";
                }

                return $"TrJoin<{internalStr}>";
            }

            public Join()
            {
            }

            public Join(string transistion1, string transition2)
            {
                Transitions.Add(transistion1);
                Transitions.Add(transition2);
            }
        }

        public class JoinRight
        {
            public List<string> Transitions { get; set; } = new List<string>();

            public string String
            {
                get
                {
                    return BuildString();
                }
            }

            private string BuildString()
            {
                string internalStr = "";
                foreach (string transition in Transitions)
                {
                    internalStr += transition + ", ";
                }

                return $"TrJoinR<{internalStr}>";
            }

            public JoinRight()
            {
            }

            public JoinRight(string transistion1, string transition2)
            {
                Transitions.Add(transistion1);
                Transitions.Add(transition2);
            }
        }

        public class Random
        {
            public List<string> Transitions { get; set; } = new List<string>();

            public string String
            {
                get
                {
                    return BuildString();
                }
            }

            private string BuildString()
            {
                string internalStr = "";
                foreach (string transition in Transitions)
                {
                    internalStr += transition + ", ";
                }

                return $"TrRandom<{internalStr}>";
            }

            public Random()
            {
            }

            public Random(string transistion1, string transition2)
            {
                Transitions.Add(transistion1);
                Transitions.Add(transition2);
            }
        }

        public class SmoothFade
        {
            public int Time { get; set; } = 300;

            public string String
            {
                get
                {
                    return $"TrSmoothFade<{Time}>";
                }
            }

            public SmoothFade()
            {
            }

            public SmoothFade(int time)
            {
                Time = time;
            }
        }

        public class WaveX
        {
            public Color Color { get; set; } = Color.White;
            public int FadeoutTime { get; set; } = 200;
            public int WaveSize { get; set; } = 100;
            public int WaveTime { get; set; } = 400;
            public int WaveCenter { get; set; } = 600;

            public string String
            {
                get
                {
                    return $"TrWaveX<{Utilities.ConvertArgb(Color)}, Int<{FadeoutTime}>, Int<{WaveSize}>, Int<{WaveTime}>, Int<{WaveCenter}>>";
                }
            }

            public WaveX()
            {
            }

            public WaveX(Color color, int fadeoutTime, int waveSize, int waveTime, int waveCenter)
            {
                Color = color;
                FadeoutTime = fadeoutTime;
                WaveSize = waveSize;
                WaveTime = waveTime;
                WaveCenter = waveCenter;
            }
        }

        public class Wipe
        {
            public int Time { get; set; } = 500;

            public string String
            {
                get
                {
                    return $"TrWipe<{Time}>";
                }
            }

            public Wipe()
            {
            }

            public Wipe(int time)
            {
                Time = time;
            }
        }

        public class WipeIn
        {
            public int Time { get; set; } = 500;

            public string String
            {
                get
                {
                    return $"TrWipeIn<{Time}>";
                }
            }

            public WipeIn()
            {
            }

            public WipeIn(int time)
            {
                Time = time;
            }
        }
        
        public class WipeInSparkTip
        {
            public Color SparkColor { get; set; } = Color.White;
            public int Time { get; set; } = 300;
            public int SparkSize { get; set; } = 400;

            public string String
            {
                get
                {
                    return $"TrWipeInSparkTip<{Utilities.ConvertArgb(SparkColor)}, {Time}, {SparkSize}>";
                }
            }

            public WipeInSparkTip()
            {
            }

            public WipeInSparkTip(Color sparkColor, int time, int sparkSize)
            {
                SparkColor = sparkColor;
                Time = time;
                SparkSize = sparkSize;
            }
        }

        public class WipeInSparkTipX
        {
            public Color SparkColor { get; set; } = Color.White;
            public int Time { get; set; } = 300;
            public int SparkSize { get; set; } = 400;

            public string String
            {
                get
                {
                    return $"TrWipeInSparkTipX<{Utilities.ConvertArgb(SparkColor)}, Int<{Time}>, Int<{SparkSize}>>";
                }
            }

            public WipeInSparkTipX()
            {
            }

            public WipeInSparkTipX(Color sparkColor, int time, int sparkSize)
            {
                SparkColor = sparkColor;
                Time = time;
                SparkSize = sparkSize;
            }
        }

        public class WipeSparkTip
        {
            public Color SparkColor { get; set; } = Color.White;
            public int Time { get; set; } = 300;
            public int SparkSize { get; set; } = 400;

            public string String
            {
                get
                {
                    return $"TrWipeInSparkTip<{Utilities.ConvertArgb(SparkColor)}, {Time}, {SparkSize}>";
                }
            }

            public WipeSparkTip()
            {
            }

            public WipeSparkTip(Color sparkColor, int time, int sparkSize)
            {
                SparkColor = sparkColor;
                Time = time;
                SparkSize = sparkSize;
            }
        }

        public class WipeSparkTipX
        {
            public Color SparkColor { get; set; } = Color.White;
            public int Time { get; set; } = 300;
            public int SparkSize { get; set; } = 400;

            public string String
            {
                get
                {
                    return $"TrWipeSparkTipX<{Utilities.ConvertArgb(SparkColor)}, Int<{Time}>, Int<{SparkSize}>>";
                }
            }

            public WipeSparkTipX()
            {
            }

            public WipeSparkTipX(Color sparkColor, int time, int sparkSize)
            {
                SparkColor = sparkColor;
                Time = time;
                SparkSize = sparkSize;
            }
        }
    }
}
