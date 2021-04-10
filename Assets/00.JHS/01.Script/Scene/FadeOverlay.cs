using Doozy.Engine.UI;
using System;
using System.Collections;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 페이드 인아웃을 통한 씬 전환 기능 정의 <para></para>
    /// 
    /// </summary>
    #endregion
    public class FadeOverlay : MonoBehaviour
    {
        #region 변수

        string m_nextSceneName;

        #endregion

        #region 외부 API

        public void Show(string _nextSceneName)
        {
            m_nextSceneName = _nextSceneName;
            GetComponent<UIPopup>().Show();
        }

        #endregion

        #region 콜백 함수

        public void OnShowFinishedTrigger()
        {
            StartCoroutine(ChangeScene());
        }

        #endregion

        #region 구현부

        void Hide()
        {
            GetComponent<UIPopup>().Hide();
            m_nextSceneName = String.Empty;
        }

        IEnumerator ChangeScene()
        {
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(m_nextSceneName);
            while (!async.isDone)
            {
                yield return null;
            }
            Hide();
        } 

        #endregion
    } 
}
