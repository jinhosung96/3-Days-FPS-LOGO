#if UNITY_EDITOR
using UnityEditor; 
#endif
using UnityEngine;

namespace JHS
{
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-02 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 매개변수로 받은 문자열을 변수명으로 한 변수에 할당된 내용으로 배열 요소의 이름을 변경 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 리스트 등의 경우 검증이 안됨 (검증 필요) <para></para>
    ///
    /// </summary>
    public class ArrayElementLabelNameAttribute : PropertyAttribute
    {
        public string m_varName;
        public ArrayElementLabelNameAttribute(string _elementTitleVar)
        {
            m_varName = _elementTitleVar;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ArrayElementLabelNameAttribute))]
    public class ArrayElementLabelNameDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label)
        {
            return EditorGUI.GetPropertyHeight(_property, _label, true);
        }

        protected virtual ArrayElementLabelNameAttribute Attribute => attribute as ArrayElementLabelNameAttribute;
        SerializedProperty m_titleNameProp;

        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            string fullPathName = _property.propertyPath + "." + Attribute.m_varName;
            m_titleNameProp = _property.serializedObject.FindProperty(fullPathName);
            string newLabel = GetTitle();
            if (string.IsNullOrEmpty(newLabel))
                newLabel = _label.text;
            EditorGUI.PropertyField(_position, _property, new GUIContent(newLabel, _label.tooltip), true);
        }

        string GetTitle()
        {
            switch (m_titleNameProp.propertyType)
            {
                case SerializedPropertyType.Generic:
                    break;
                case SerializedPropertyType.Integer:
                    return m_titleNameProp.intValue.ToString();
                case SerializedPropertyType.Boolean:
                    return m_titleNameProp.boolValue.ToString();
                case SerializedPropertyType.Float:
                    return m_titleNameProp.floatValue.ToString();
                case SerializedPropertyType.String:
                    return m_titleNameProp.stringValue;
                case SerializedPropertyType.Color:
                    return m_titleNameProp.colorValue.ToString();
                case SerializedPropertyType.ObjectReference:
                    return m_titleNameProp?.objectReferenceValue?.ToString() ?? "Null";
                case SerializedPropertyType.LayerMask:
                    break;
                case SerializedPropertyType.Enum:
                    return m_titleNameProp.enumNames[m_titleNameProp.enumValueIndex];
                case SerializedPropertyType.Vector2:
                    return m_titleNameProp.vector2Value.ToString();
                case SerializedPropertyType.Vector3:
                    return m_titleNameProp.vector3Value.ToString();
                case SerializedPropertyType.Vector4:
                    return m_titleNameProp.vector4Value.ToString();
                case SerializedPropertyType.Rect:
                    break;
                case SerializedPropertyType.ArraySize:
                    break;
                case SerializedPropertyType.Character:
                    break;
                case SerializedPropertyType.AnimationCurve:
                    break;
                case SerializedPropertyType.Bounds:
                    break;
                case SerializedPropertyType.Gradient:
                    break;
                case SerializedPropertyType.Quaternion:
                    break;
                case SerializedPropertyType.ExposedReference:
                    break;
                case SerializedPropertyType.FixedBufferSize:
                    break;
                case SerializedPropertyType.Vector2Int:
                    break;
                case SerializedPropertyType.Vector3Int:
                    break;
                case SerializedPropertyType.RectInt:
                    break;
                case SerializedPropertyType.BoundsInt:
                    break;
                default:
                    break;
            }
            return "";
        }
    } 
#endif
}