using UnityEngine;

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 해당 클래스를 상속 받는 객체는 자동으로 싱글톤 오브젝트가 된다. <para></para>
    /// 참고 : 싱글톤 패턴 - https://victorydntmd.tistory.com/293?category=719467 <para></para>
    /// 
    /// ----- 공개 속성 ----- <para></para>
    /// Instance : 인스턴스된 객체가 없을 시 새로 인스턴스하여 반환하고 이미 인스턴스된 객체가 있을 시 해당 객체를 반환한다. <para></para>
    ///
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 상속 받을 때 SingletonObject<T>의 T에 자기자신을 넣어야 한다. <para></para>
    /// 2. 해당 클래스를 상속받은 객체는 Awake()를 오버라이드 시 base.Awake()를 필히 호출해야한다. <para></para>
    ///
    /// </summary>
     #endregion
    public class SingletonObject<T> : MonoBehaviour where T : SingletonObject<T>
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
                        var newSingleton = new GameObject(typeof(T).Name).AddComponent<T>();
                        s_instance = newSingleton;
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

        #region 유니티 생명주기

        protected void Awake()
        {
            var objs = FindObjectsOfType<T>();
            if (objs.Length != 1)
            {
                Destroy(gameObject);
                Debug.Log("중복 생성된 싱글톤 객체가 있어 파괴됩니다.");
                return;
            }
            DontDestroyOnLoad(gameObject);
        } 

        #endregion
    }
}
