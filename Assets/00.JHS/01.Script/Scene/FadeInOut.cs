using Doozy.Engine.UI;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 페이드 인아웃 씬 전환 기능 정의 <para></para>
    ///
    /// ----- 공개 메소드 ----- <para></para>
    /// ChangeScene(string _nextSceneName) : 페이드 인아웃 효과와 함께 씬 전환 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. Fade라는 이름의 팝업이 정의되있지 않을 시 참조 에러 발생 <para></para>
    /// 2. DoozyUI 에셋 미설치 시 작동 안함 <para></para>
    ///
    /// </summary>
    #endregion
    public class FadeInOut : MonoBehaviour, ISceneChangeType
    {
        #region 외부 API

        public void ChangeScene(string _nextSceneName)
        {
            if (UICanvas.GetUICanvas("FadeCanvas") == null)
            {
                var fadeCanvas = UICanvas.CreateUICanvas("FadeCanvas");
                DontDestroyOnLoad(fadeCanvas);
                fadeCanvas.GetComponent<Canvas>().sortingOrder = 20000;
            }
            UIPopup fade = UIPopup.GetPopup("Fade");
            fade.GetComponent<FadeOverlay>().Show(_nextSceneName);
        }

        #endregion
    }
}