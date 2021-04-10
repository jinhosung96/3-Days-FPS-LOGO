using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class SpawnState : State
    {
        #region 변수

        [SerializeField, LabelName("다음 상태")] State m_nextState;

        Animator m_animator;

        #endregion

        #region 콜백 함수

        // 유니티 생명주기 상의 Awake에서 실행
        // StateMachine을 초기화 후 실행
        // 본 객체가 비활성화 상태여도 실행
        protected override void OnAwake()
        {
            m_animator = GetComponent<Animator>();
        }

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            ChangeState();
        }

        #endregion

        #region 구현부

        private void ChangeState()
        {
            bool animationExit = m_animator.GetCurrentAnimatorStateInfo(0).IsName("Spawn")
                && m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f - m_animator.GetAnimatorTransitionInfo(0).duration;

            if (animationExit)
            {
                m_machine.SetState(m_nextState);
            }
        }

        #endregion
    }
}
