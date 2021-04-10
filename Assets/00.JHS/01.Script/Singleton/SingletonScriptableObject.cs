using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 해당 클래스를 상속 받는 객체는 자동으로 싱글톤 스크립터블 오브젝트가 된다. <para></para>
    /// 참고 : 싱글톤 패턴 - https://victorydntmd.tistory.com/293?category=719467 <para></para>
    /// 
    /// ----- 공개 속성 ----- <para></para>
    /// Instance : 인스턴스된 객체가 없을 시 새로 인스턴스하여 반환하고 이미 인스턴스된 객체가 있을 시 해당 객체를 반환한다. <para></para>
    ///
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 상속 받을 때 SingletonScriptableObject<T>의 T에 자기자신을 넣어야 한다. <para></para>
    /// 2. Odin 미설치 시 작동 안한다. <para></para>
    ///
    /// </summary>
     #endregion
    public class SingletonScriptableObject<T> : SerializedScriptableObject where T : SingletonScriptableObject<T>
    {
        #region 변수

        static string s_settingFileDirectory = "Assets/Resources";
        static string s_settingFilePath = $"Assets/Resources/{typeof(T).Name}.asset";

        static T s_instance;

        #endregion

        #region 공개 속성

        public static T Instance
        {
            get
            {
                if (s_instance != null) return s_instance;

                s_instance = Resources.Load<T>(typeof(T).Name);

#if UNITY_EDITOR
                if (s_instance == null)
                {
                    if (!AssetDatabase.IsValidFolder(s_settingFileDirectory))
                    {
                        AssetDatabase.CreateFolder("Assets", "Resources");
                    }

                    s_instance = AssetDatabase.LoadAssetAtPath<T>(typeof(T).Name);

                    if (s_instance == null)
                    {
                        s_instance = CreateInstance<T>();
                        AssetDatabase.CreateAsset(s_instance, s_settingFilePath);
                    }
                }
#endif

                return s_instance;
            }
        } 

        #endregion
    }
}
