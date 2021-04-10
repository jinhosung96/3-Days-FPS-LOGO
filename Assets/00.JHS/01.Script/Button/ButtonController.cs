using Doozy.Engine.UI;
using UnityEngine;

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 본 객체에서 IButtonClick을 상속 받고 있는 컴포넌트를 참조하여 해당 컴포넌트의 OnClick() 메소드를 버튼 클릭 시 트리거에 자동으로 추가한다 <para></para>
    ///
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 스크립트 이름이 ButtonController가 아닐 시 타 스크립트에서 참조 오류가 발생할 수 있다. <para></para>
    /// 2. DoozyUI가 설치되어 있지 않을 시 참조 오류가 발생한다. <para></para>
    /// 3. IButtonClick이 정의되어 있지 않을 시 참조 오류가 발생한다. <para></para>
    ///
    /// </summary>
     #endregion
    public class ButtonController : MonoBehaviour
    {
        #region 변수
        
        UIButton m_button;
        IButtonClick[] m_buttonClicks;
        IButtonPointerDown[] m_buttonPointerDowns;
        IButtonPointerUp[] m_buttonPointerUps;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            SetButtonClickTrigger();
            SetButtonPointerDownTrigger();
            SetButtonPointerUpTrigger();
        }

        #endregion

        #region 구현부

        private void SetButtonClickTrigger()
        {
            m_button = GetComponent<UIButton>();
            m_buttonClicks = GetComponents<IButtonClick>();
            m_button.OnClick.OnTrigger.SetAction((GameObject) =>
            {
                for (int i = 0; i < m_buttonClicks.Length; i++)
                {
                    m_buttonClicks[i]?.OnClick();
                }
            });
        }

        private void SetButtonPointerDownTrigger()
        {
            m_button = GetComponent<UIButton>();
            m_buttonPointerDowns = GetComponents<IButtonPointerDown>();
            m_button.OnPointerDown.OnTrigger.SetAction((GameObject) =>
            {
                for (int i = 0; i < m_buttonPointerDowns.Length; i++)
                {
                    m_buttonPointerDowns[i]?.OnPointerDown();
                }
            });
        }

        private void SetButtonPointerUpTrigger()
        {
            m_button = GetComponent<UIButton>();
            m_buttonPointerUps = GetComponents<IButtonPointerUp>();
            m_button.OnPointerUp.OnTrigger.SetAction((GameObject) =>
            {
                for (int i = 0; i < m_buttonPointerUps.Length; i++)
                {
                    m_buttonPointerUps[i]?.OnPointerUp();
                }
            });
        }

        #endregion
    }
}
