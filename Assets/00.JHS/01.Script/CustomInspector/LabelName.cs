using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

namespace JHS
{
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-02 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 매개변수로 받은 문자열을 변수명으로 변경 <para></para>
    ///
    /// </summary>
    public class LabelNameAttribute : PropertyAttribute
    {
        public string m_newName { get; private set; }

        public LabelNameAttribute(string _labelName)
        {
            m_newName = _labelName;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(LabelNameAttribute))]
    public class NamePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            LabelNameAttribute labelNameAttribute = (LabelNameAttribute)this.attribute;
            _label.text = labelNameAttribute.m_newName;
            EditorGUI.PropertyField(_position, _property, _label);
        }
    }  
#endif
}
