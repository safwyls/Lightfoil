using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lightfoil
{
    public class Styles
    {
        public class AudioFlicker
        {
            public Color Color1 { get; set; }
            public Color Color2 { get; set; }

            public string String
            {
                get
                {
                    return $"AudioFlicker<{Utilities.ConvertArgb(Color1)}, {Utilities.ConvertArgb(Color2)}>";
                }
            }

            public AudioFlicker()
            {
            }

            public AudioFlicker(Color color1, Color color2)
            {
                Color1 = color1;
                Color2 = color2;
            }
        }

        public class Blast
        {
            public Color BaseColor { get; set; }
            public Color BlastColor { get; set; }
            public int FadeoutTime { get; set; }
            public int WaveSize { get; set; }
            public int WaveSpeed { get; set; }

            public string String
            {
                get
                {
                    return $"Blast<{Utilities.ConvertArgb(BaseColor)}, {Utilities.ConvertArgb(BlastColor)}, {FadeoutTime}, {WaveSize}, {WaveSpeed}, EFFECT_BLAST>";
                }
            }

            public Blast()
            {
            }

            public Blast(Color baseColor, Color blastColor, int fadeoutTime, int waveSize, int waveSpeed)
            {
                BaseColor = baseColor;
                BlastColor = blastColor;
                FadeoutTime = fadeoutTime;
                WaveSize = waveSize;
                WaveSpeed = waveSpeed;
            }
        }

        public class BlastFadeout
        {
            public Color BaseColor { get; set; }
            public Color BlastColor { get; set; }
            public int FadeoutTime { get; set; }

            public string String
            {
                get
                {
                    return $"Blast<{Utilities.ConvertArgb(BaseColor)}, {Utilities.ConvertArgb(BlastColor)}, {FadeoutTime}, EFFECT_BLAST>";
                }
            }

            public BlastFadeout()
            {
            }

            public BlastFadeout(Color baseColor, Color blastColor, int fadeoutTime)
            {
                BaseColor = baseColor;
                BlastColor = blastColor;
                FadeoutTime = fadeoutTime;
            }
        }

        public class Blinking
        {
            public Color Color1 { get; set; }
            public Color Color2 { get; set; }
            public int Interval { get; set; } = 1000;
            private int _duration = 500;
            public int Duration 
            {
                get
                {
                    return _duration;
                }
                set
                {
                    if (value < 0 || value > 1000)
                        throw new ArgumentException("Invalid Duration, must fall between 0 (off) and 1000(on)");
                    _duration = value;
                } 
            }

            public string String
            {
                get
                {
                    return $"Blinking<{Utilities.ConvertArgb(Color1)}, {Utilities.ConvertArgb(Color2)}, {Interval}, {Duration}>";
                }
            }

            public Blinking()
            {
            }

            public Blinking(Color color1, Color color2, int interval, int duration)
            {
                Color1 = color1;
                Color2 = color2;
                Interval = interval;
                Duration = duration;
            }
        }

        public class BrownNoiseFlicker
        {
            public Color Color1 { get; set; }
            public Color Color2 { get; set; }
            public int Grade { get; set; }

            public string String
            {
                get
                {
                    return $"BrownNoiseFlicker<{Utilities.ConvertArgb(Color1)}, {Utilities.ConvertArgb(Color2)}, {Grade}>";
                }
            }

            public BrownNoiseFlicker() 
            {
            }

            public BrownNoiseFlicker(Color color1, Color color2, int grade)
            {
                Color1 = color1;
                Color2 = color2;
                Grade = grade;
            }
        }
        
        public class ColorChange
        {
            public string Transition { get; set; } = Transitions.Instant.String;
            public List<Color> Colors { get; set; } = new List<Color>();

            public string String
            {
                get
                {
                    return BuildString();
                }
            }

            private string BuildString()
            {
                string internalStr = $"{Transition}, ";
                foreach (Color color in Colors)
                {
                    internalStr += Utilities.ConvertArgb(color) + ", ";
                }

                return $"ColorChange<{internalStr}>";
            }

            public ColorChange()
            {
            }

            public ColorChange(Color color1, Color color2)
            {
                Colors.Add(color1);
                Colors.Add(color2);
            }
        }

        public class ColorCycle
        {
            public Color InitialColor { get; set; }
            public int InitialLitPercent { get; set; } = 0;
            public int InitialRotationSpeed { get; set; } = 1;
            public Color FinalColor { get; set; }
            public int FinalLitPercent { get; set; } = 100;
            public int FinalRotationSpeed { get; set; } = 3000;
            public int TransitionTime { get; set; } = 5000;

            public string String
            {
                get
                {
                    return $"ColorCycle<{Utilities.ConvertArgb(InitialColor)}, " +
                        $"{InitialLitPercent}, " +
                        $"{InitialRotationSpeed}, " +
                        $"{Utilities.ConvertArgb(FinalColor)}, " +
                        $"{FinalLitPercent}, " +
                        $"{FinalRotationSpeed}, " +
                        $"{TransitionTime} >";
                }
            }

            public ColorCycle()
            {
            }

            public ColorCycle(Color initialColor, 
                int initialLitPercent, 
                int initialRotationSpeed, 
                Color finalColor, 
                int finalLitPercent, 
                int finalRotationSpeed, 
                int transitionTime)
            {
                InitialColor = initialColor;
                InitialLitPercent = initialLitPercent;
                InitialRotationSpeed = initialRotationSpeed;
                FinalColor = finalColor;
                FinalLitPercent = finalLitPercent;
                FinalRotationSpeed = finalRotationSpeed;
                TransitionTime = transitionTime;
            }
        }
    }
}
