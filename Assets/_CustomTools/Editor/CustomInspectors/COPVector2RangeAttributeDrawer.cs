using Cooperative.Attributes;
using UnityEditor;
using UnityEngine;

namespace Cooperative.Tools
{
    [CustomPropertyDrawer(typeof(COPVector2RangeAttribute))]
    public class COPVector2RangeAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var rangeAttribute = (COPVector2RangeAttribute)attribute;

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
            var xValue = EditorGUILayout.Slider("x", property.vector2Value.x, rangeAttribute.Min, rangeAttribute.Max);
            var yValue = EditorGUILayout.Slider("y", property.vector2Value.y, rangeAttribute.Min, rangeAttribute.Max);
            EditorGUILayout.EndVertical();
            
            property.vector2Value = new Vector2(xValue, yValue);
        }
    }
}