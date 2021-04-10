using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace JHS
{
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-02 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 매개변수로 받은 문자열을 변수명으로 변경하고 인스펙터 상에서 수정이 불가능하도록 변경 <para></para>
    ///
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
        public string m_newName { get; private set; }
        public readonly bool m_runtimeOnly;

        public ReadOnlyAttribute(string _labelName, bool _runtimeOnly = false)
        {
            m_newName = _labelName;
            m_runtimeOnly = _runtimeOnly;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute), true)]
    public class ReadOnlyAttributeDrawer : PropertyDrawer
    {
        // Necessary since some properties tend to collapse smaller than their content
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        // Draw a disabled property field
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = !Application.isPlaying && ((ReadOnlyAttribute)attribute).m_runtimeOnly;
            label.text = ((ReadOnlyAttribute)attribute).m_newName;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
#endif
}
