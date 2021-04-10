using Doozy.Engine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class PlayerHPController : HPController
    {
        #region 변수

        [SerializeField, LabelName("피격음")] AudioClip m_painSound;

        #endregion

        #region 공개 속성



        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            
        }

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        #endregion

        #region 외부 API



        #endregion

        #region 구현부

        protected override void OnTakeDamage()
        {
            SoundManager.Instance.PlaySoundEffect(m_painSound);
        }

        protected override void RefreshUIElement()
        {
            EventManager.Instance.PostNofication("플레이어 체력 갱신");
        }

        protected override void OnDeath()
        {
            InGameUISystem.Instance.GameOverView.Show();
            InGameUISystem.Instance.GameOverMoalWindowManager.ModalWindowIn();

            PlayerSystem.Instance.Animator.SetTrigger("DoDeath");

            EventManager.Instance.PostNofication("게임 오버");
        }

        #endregion
    }
}
