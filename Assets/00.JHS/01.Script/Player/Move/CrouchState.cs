using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class CrouchState : State
    {
        #region 변수

        [SerializeField, LabelName("이동 속도")] float m_crouchSpeed;
        //[SerializeField, LabelName("앉았을 때 카메라 오프셋")] Vector3 m_crouchCameraOffset;

        //Vector3 m_origineCameraOffset;

        #endregion

        #region 공개 속성



        #endregion

        #region 콜백 함수     

        protected override void OnAwake()
        {
            //m_origineCameraOffset = CameraSystem.Instance.CameraArmController.CameraBodyOffset;
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태로 진입했을 때 1회 실행
        public override void OnEnter()
        {
            PlayerSystem.Instance.MoveController.MoveSpeed = m_crouchSpeed;
            PlayerSystem.Instance.Animator.SetBool("IsCrouch", true);
            //CameraSystem.Instance.CameraArmController.CameraBodyOffset = m_crouchCameraOffset;
        }   

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            if (Input.GetButtonUp("Crouch"))
            {
                m_machine.SetState(PlayerSystem.Instance.RunState);
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
            PlayerSystem.Instance.Animator.SetBool("IsCrouch", false);
            //CameraSystem.Instance.CameraArmController.CameraBodyOffset = m_origineCameraOffset;
        }

        #endregion

        #region 구현부



        #endregion
    }
}
