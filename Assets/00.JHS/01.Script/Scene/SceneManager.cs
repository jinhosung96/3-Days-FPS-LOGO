using UnityEngine;

namespace JHS
{
    public enum SCENE_CHANGE_TYPE
    {
        Fade = 0
    }

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 씬 전환 관리 제어 <para></para>
    /// 
    /// ----- 공개 메소드 ----- <para></para>
    /// LoadScene(string _nextSceneName, SCENE_CHANGE_TYPE _changeType) : 인자값으로 넘겨진 _changeType에 의거한 방법으로 씬 전환 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. Awake()문 오버라이드시 base.Awake()를 필히 호출해야한다. <para></para>
    ///
    /// </summary>
    #endregion
    public class SceneManager : SceneObject<SceneManager>
    {
        #region 변수

        [SerializeField] GameObject[] m_type;

        #endregion

        #region 외부 API

        public void LoadScene(string _nextSceneName, SCENE_CHANGE_TYPE _changeType)
        {
            m_type[(int)_changeType].GetComponent<ISceneChangeType>().ChangeScene(_nextSceneName);
        }

        #endregion
    }

}