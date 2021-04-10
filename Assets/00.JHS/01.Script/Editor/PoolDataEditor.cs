
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using Sirenix.OdinInspector.Editor;
#endif

namespace JHS
{    
    #if UNITY_EDITOR
    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-11-24 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : PoolData을 생성하기 위한 에디터 클래스이다. <para></para>
    ///
    /// ----- 주의 사항 ----- <para></para>
    /// 1. Odin 미설치 시 작동 안한다. <para></para>
    ///
    /// </summary>
     #endregion
    [CustomEditor(typeof(PoolData))]
    public class PoolDataEditor : OdinEditor
    {
        [MenuItem("Assets/Open PoolData")]
        public static void OpenInspector()
        {
            Selection.activeObject = PoolData.Instance;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
                AssetDatabase.SaveAssets();
            }
        }
    }
    #endif
}
