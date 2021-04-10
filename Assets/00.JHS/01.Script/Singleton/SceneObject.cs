using Sirenix.OdinInspector;
using UnityEngine;

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 해당 클래스를 상속 받는 객체는 자동으로 씬 오브젝트가 된다. 씬 오브젝트는 전역에서 접근이 가능하다. <para></para>
    /// 참고 : 싱글톤 패턴 - https://victorydntmd.tistory.com/293?category=719467 <para></para>
    ///
    /// ----- 공개 정적 속성 ----- <para></para>
    /// Instance : 인스턴스된 객체가 없을 시 새로 인스턴스하여 반환하고 이미 인스턴스된 객체가 있을 시 해당 객체를 반환한다. <para></para>
    ///
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 상속 받을 때 SceneObject<T>의 T에 자기자신을 넣어야 한다. <para></para>
    /// 2. 해당 클래스를 상속받은 객체는 Awake()문에서 base.Awake()를 필히 호출해야한다. <para></para>
    ///
    /// </summary>
     #endregion
    public class SceneObject<T> : SerializedMonoBehaviour where T : SceneObject<T>
    {
        #region 변수

        private static T s_instance;

        #endregion

        #region 공개 속성

        public static T Instance
        {
            get
            {
                if (s_instance == null)
                {
                    var obj = FindObjectOfType<T>();
                    if (obj != null)
                    {                        
                        s_instance = obj;
                    }
                    else
                    {
                        var newSceneObject = new GameObject(typeof(T).Name).AddComponent<T>();
                        s_instance = newSceneObject;
                    }
                }
                return s_instance;
            }
            private set
            {
                s_instance = value;
            }
        }

        #endregion
    }
}
