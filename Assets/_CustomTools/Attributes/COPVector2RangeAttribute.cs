using System;
using UnityEngine;

namespace Cooperative.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class COPVector2RangeAttribute : PropertyAttribute
    {
        public readonly float Min;
        public readonly float Max;
        
        public COPVector2RangeAttribute(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}