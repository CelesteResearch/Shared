using System;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Presentation.PostProcessing.ColorGrading
{
    public sealed class OriginalLevelColorGradeState
    {
        public readonly OriginalLevelSceneRoot Level;
        public string LastGrade;
        public float Ease;
        public float EaseSpeed = 1f;
        public ChapterCompletionSession Session => Level.Session;

        public OriginalLevelColorGradeState(OriginalLevelSceneRoot level)
        {
            Level = level ?? throw new ArgumentNullException(nameof(level));
        }

        public void LoadLevel()
        {
            LastGrade = Session.ColorGrade;
            Ease = 0f;
            EaseSpeed = 1f;
        }

        public void SnapColorGrade(string next)
        {
            if (Session.ColorGrade != next)
            {
                LastGrade = next;
                Ease = 0f;
                EaseSpeed = 1f;
                Session.ColorGrade = next;
            }
        }

        public void NextColorGrade(string next, float speed = 1f)
        {
            if (Session.ColorGrade != next)
            {
                Ease = 0f;
                EaseSpeed = speed;
                Session.ColorGrade = next;
            }
        }

        public void Update(float deltaTime)
        {
            if (LastGrade != Session.ColorGrade)
            {
                if (Ease >= 1f)
                {
                    Ease = 0f;
                    LastGrade = Session.ColorGrade;
                }
                else
                {
                    Ease = ScalarMath.Approach(Ease, 1f, deltaTime * EaseSpeed,
                        ((ISourceExtremaEnvironment)Level.EngineContext).ExtremaArithmetic);
                }
            }
        }
    }
}
