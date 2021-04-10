using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{   
    public class AnimatorController : MonoBehaviour
    {
        #region 변수

        string m_currentState;

        bool m_isMove;
        bool m_isRun;
        bool m_isWalk;
        bool m_isCrouch;

        #endregion

        #region 공개 속성

        public bool IsMove { get => m_isMove; set => m_isMove = value; }
        public bool IsRun { get => m_isRun; set => m_isRun = value; }
        public bool IsWalk { get => m_isWalk; set => m_isWalk = value; }
        public bool IsCrouch { get => m_isCrouch; set => m_isCrouch = value; }

        #endregion

        #region 유니티 생명주기

        private void Update()
        {
            if (PlayerSystem.Instance.JumpController.IsGrounded)
            {
                if (!IsMove)
                {
                    if (!IsCrouch)
                    {
                        ChangeAnimationState("Idle");
                    }
                    if (IsCrouch)
                    {
                        ChangeAnimationState("Crouch");
                    }
                }
                else
                {
                    if (IsRun)
                    {
                        ChangeAnimationState("Run");
                    }
                    if (IsWalk)
                    {
                        ChangeAnimationState("Walk");
                    }
                    if (IsCrouch)
                    {
                        ChangeAnimationState("Crouch Walk");
                    }
                }
            }
        }

        #endregion

        #region 외부 API

        public void ChangeAnimationState(string _newState, int _layer = 0)
        {
            if (m_currentState == _newState) return;

            Debug.Log($"{m_currentState} -> {_newState}");
            PlayerSystem.Instance.Animator.Play(_newState,  _layer);
            m_currentState = _newState;
        }

        #endregion

        #region 구현부



        #endregion
    }
}
