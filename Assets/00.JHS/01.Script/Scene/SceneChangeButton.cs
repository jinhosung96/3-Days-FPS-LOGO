using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-03 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 버튼 클릭 시 씬 전환 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. ButtonController 컴포넌트와 같이 사용해야 자동으로 버튼 클릭 트리거에 추가된다. <para></para>
    ///
    /// </summary>
    #endregion
    [RequireComponent(typeof(ButtonController))]
    public class SceneChangeButton : MonoBehaviour, IButtonClick
    {
        #region 변수

        [SerializeField, LabelName("변경할 씬 이름")] string m_nextSceneName;
        [SerializeField, LabelName("씬 전환 방법")] SCENE_CHANGE_TYPE m_changeType;

        #endregion

        #region 콜백 함수

        public void OnClick()
        {
            Debug.Log("눌림");
            SceneManager.Instance.LoadScene(m_nextSceneName, m_changeType);
        }

        #endregion
    } 
}
