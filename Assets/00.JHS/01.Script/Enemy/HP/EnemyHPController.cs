using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{   
    public class EnemyHPController : HPController
    {
        #region 변수

        Animator m_animator;
        Collider m_collider;
        StateMachine m_machine;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            m_animator = GetComponent<Animator>();
            m_collider = GetComponent<Collider>();
            m_machine = GetComponent<StateMachine>();

            EventManager.Instance.AddListener("게임 오버", GameOver);
            EventManager.Instance.AddListener("스테이지 클리어", StageClear);
        }

        #endregion

        #region 구현부

        protected override void OnDeath()
        {
            m_animator.SetTrigger("DoDeath");
            m_collider.enabled = false;

            m_machine.SetState(null);
        }

        void GameOver()
        {
            m_animator.SetTrigger("DoGameOver");
        }

        void StageClear()
        {
            if(!m_animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) m_animator.SetTrigger("DoDeath");
        }

        #endregion
    }
}
