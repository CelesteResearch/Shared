using System;

namespace Celeste.Core.Mathematics.Curves
{
    [Serializable]
    public class SourceCurve
    {
        public bool IsConstant => Keys.Count <= 1;

        public SourceCurveKeyCollection Keys { get; private set; }

        public SourceCurveLoopType PostLoop { get; set; }

        public SourceCurveLoopType PreLoop { get; set; }

        public SourceCurve()
        {
            Keys = new SourceCurveKeyCollection();
        }

        private SourceCurve(SourceCurveKeyCollection keys)
        {
            Keys = keys;
        }

        public SourceCurve Clone()
        {
            return new SourceCurve(Keys.Clone())
            {
                PreLoop = PreLoop,
                PostLoop = PostLoop
            };
        }

        public float Evaluate(float position)
        {
            if (Keys.Count == 0)
            {
                return 0f;
            }

            if (Keys.Count == 1)
            {
                return Keys[0].Value;
            }

            SourceCurveKey curveKey = Keys[0];
            SourceCurveKey curveKey2 = Keys[Keys.Count - 1];
            if (position < curveKey.Position)
            {
                switch (PreLoop)
                {
                    case SourceCurveLoopType.Constant:
                        return curveKey.Value;
                    case SourceCurveLoopType.Linear:
                        return curveKey.Value - curveKey.TangentIn * (curveKey.Position - position);
                    case SourceCurveLoopType.Cycle:
                    {
                        int numberOfCycle = GetNumberOfCycle(position);
                        float position2 = position - (float)numberOfCycle * (curveKey2.Position - curveKey.Position);
                        return GetCurvePosition(position2);
                    }
                    case SourceCurveLoopType.CycleOffset:
                    {
                        int numberOfCycle = GetNumberOfCycle(position);
                        float position2 = position - (float)numberOfCycle * (curveKey2.Position - curveKey.Position);
                        return GetCurvePosition(position2) + (float)numberOfCycle * (curveKey2.Value - curveKey.Value);
                    }
                    case SourceCurveLoopType.Oscillate:
                    {
                        int numberOfCycle = GetNumberOfCycle(position);
                        float position2 = ((0f != (float)numberOfCycle % 2f)
                            ? (curveKey2.Position - position + curveKey.Position +
                               (float)numberOfCycle * (curveKey2.Position - curveKey.Position))
                            : (position - (float)numberOfCycle * (curveKey2.Position - curveKey.Position)));
                        return GetCurvePosition(position2);
                    }
                }
            }
            else if (position > curveKey2.Position)
            {
                switch (PostLoop)
                {
                    case SourceCurveLoopType.Constant:
                        return curveKey2.Value;
                    case SourceCurveLoopType.Linear:
                        return curveKey2.Value + curveKey.TangentOut * (position - curveKey2.Position);
                    case SourceCurveLoopType.Cycle:
                    {
                        int numberOfCycle2 = GetNumberOfCycle(position);
                        float num = position - (float)numberOfCycle2 * (curveKey2.Position - curveKey.Position);
                        return GetCurvePosition(num);
                    }
                    case SourceCurveLoopType.CycleOffset:
                    {
                        int numberOfCycle2 = GetNumberOfCycle(position);
                        float num = position - (float)numberOfCycle2 * (curveKey2.Position - curveKey.Position);
                        return GetCurvePosition(num) + (float)numberOfCycle2 * (curveKey2.Value - curveKey.Value);
                    }
                    case SourceCurveLoopType.Oscillate:
                    {
                        int numberOfCycle2 = GetNumberOfCycle(position);
                        float num = position - (float)numberOfCycle2 * (curveKey2.Position - curveKey.Position);
                        num = ((0f != (float)numberOfCycle2 % 2f)
                            ? (curveKey2.Position - position + curveKey.Position +
                               (float)numberOfCycle2 * (curveKey2.Position - curveKey.Position))
                            : (position - (float)numberOfCycle2 * (curveKey2.Position - curveKey.Position)));
                        return GetCurvePosition(num);
                    }
                }
            }

            return GetCurvePosition(position);
        }

        public void ComputeTangents(SourceCurveTangent tangentType)
        {
            ComputeTangents(tangentType, tangentType);
        }

        public void ComputeTangents(SourceCurveTangent tangentInType, SourceCurveTangent tangentOutType)
        {
            for (int i = 0; i < Keys.Count; i++)
            {
                ComputeTangent(i, tangentInType, tangentOutType);
            }
        }

        public void ComputeTangent(int keyIndex, SourceCurveTangent tangentType)
        {
            ComputeTangent(keyIndex, tangentType, tangentType);
        }

        public void ComputeTangent(int keyIndex, SourceCurveTangent tangentInType, SourceCurveTangent tangentOutType)
        {
            SourceCurveKey curveKey = Keys[keyIndex];
            float num2;
            float position;
            float num = (num2 = (position = curveKey.Position));
            float num4;
            float value;
            float num3 = (num4 = (value = curveKey.Value));
            if (keyIndex > 0)
            {
                num = Keys[keyIndex - 1].Position;
                num3 = Keys[keyIndex - 1].Value;
            }

            if (keyIndex < Keys.Count - 1)
            {
                position = Keys[keyIndex + 1].Position;
                value = Keys[keyIndex + 1].Value;
            }

            switch (tangentInType)
            {
                case SourceCurveTangent.Flat:
                    curveKey.TangentIn = 0f;
                    break;
                case SourceCurveTangent.Linear:
                    curveKey.TangentIn = num4 - num3;
                    break;
                case SourceCurveTangent.Smooth:
                {
                    float num5 = position - num;
                    if (Celeste.Core.Mathematics.SourceFloatEqualityArithmetic.WithinEpsilon(num5, 0f))
                    {
                        curveKey.TangentIn = 0f;
                    }
                    else
                    {
                        curveKey.TangentIn = (value - num3) * ((num2 - num) / num5);
                    }

                    break;
                }
            }

            switch (tangentOutType)
            {
                case SourceCurveTangent.Flat:
                    curveKey.TangentOut = 0f;
                    break;
                case SourceCurveTangent.Linear:
                    curveKey.TangentOut = value - num4;
                    break;
                case SourceCurveTangent.Smooth:
                {
                    float num6 = position - num;
                    if (Math.Abs(num6) < float.Epsilon)
                    {
                        curveKey.TangentOut = 0f;
                    }
                    else
                    {
                        curveKey.TangentOut = (value - num3) * ((position - num2) / num6);
                    }

                    break;
                }
            }
        }

        private int GetNumberOfCycle(float position)
        {
            float num = (position - Keys[0].Position) / (Keys[Keys.Count - 1].Position - Keys[0].Position);
            if (num < 0f)
            {
                num -= 1f;
            }

            return (int)num;
        }

        private float GetCurvePosition(float position)
        {
            SourceCurveKey curveKey = Keys[0];
            for (int i = 1; i < Keys.Count; i++)
            {
                SourceCurveKey curveKey2 = Keys[i];
                if (curveKey2.Position >= position)
                {
                    if (curveKey.Continuity == SourceCurveContinuity.Step)
                    {
                        if (position >= 1f)
                        {
                            return curveKey2.Value;
                        }

                        return curveKey.Value;
                    }

                    float num = (position - curveKey.Position) / (curveKey2.Position - curveKey.Position);
                    float num2 = num * num;
                    float num3 = num2 * num;
                    return (2f * num3 - 3f * num2 + 1f) * curveKey.Value +
                           (num3 - 2f * num2 + num) * curveKey.TangentOut +
                           (3f * num2 - 2f * num3) * curveKey2.Value + (num3 - num2) * curveKey2.TangentIn;
                }

                curveKey = curveKey2;
            }

            return 0f;
        }
    }
}
