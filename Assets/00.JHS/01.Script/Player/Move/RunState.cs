using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class RunState : State
    {
        #region 변수

        [SerializeField, LabelName("이동 속도")] float m_runSpeed;
        [SerializeField, LabelName("달리기 발자국 사운드")] AudioClip m_runFootStepEffectSound;

        #endregion

        #region 공개 속성



        #endregion

        #region 콜백 함수     

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태로 진입했을 때 1회 실행
        public override void OnEnter()
        {
            PlayerSystem.Instance.MoveController.MoveSpeed = m_runSpeed;
            PlayerSystem.Instance.Animator.SetBool("IsRun", true);
        }     

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            if (Input.GetButton("Crouch"))
            {
                m_machine.SetState(PlayerSystem.Instance.CrouchState);
            }
            if (Input.GetButton("Walk"))
            {
                m_machine.SetState(PlayerSystem.Instance.WalkState);
            }
        }   

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public override void OnExit()
        {
            PlayerSystem.Instance.Animator.SetBool("IsRun", false);
        }

        #endregion

        #region 외부 API

        public void FootStep_Run()
        {
            SoundManager.Instance.PlaySoundEffect(m_runFootStepEffectSound);
        }

        #endregion
    }
}
