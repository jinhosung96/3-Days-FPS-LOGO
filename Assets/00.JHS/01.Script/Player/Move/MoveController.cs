using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class MoveController : StateMachine
    {
        #region 변수

        float m_moveSpeed;
        Vector3 m_moveDirection;

        bool m_isMove;

        #endregion

        #region 공개 속성

        public float MoveSpeed { get => m_moveSpeed; set => m_moveSpeed = value; }
        public Vector3 MoveDirection { get => m_moveDirection; private set => m_moveDirection = value; }

        #endregion

        #region 유니티 생명주기

        void FixedUpdate()
        {
            if (PlayerSystem.Instance.Pause)
            {
                MoveDirection = Vector3.zero;
                // 애니메이션 적용
                PlayerSystem.Instance.Animator.SetFloat("HorizontalMove", MoveDirection.x);
                PlayerSystem.Instance.Animator.SetFloat("VerticalMove", MoveDirection.z);
                return;
            }

            Move();
        }

        #endregion

        #region 구현부

        private void Move()
        {
            // 현재 캐릭터가 땅에 있는가?
            if (PlayerSystem.Instance.JumpController.IsGrounded || PlayerSystem.Instance.JumpController == null || PlayerSystem.Instance.JumpController.enabled == false)
            {
                // 위, 아래 움직임 셋팅. 
                MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                // 애니메이션 적용
                PlayerSystem.Instance.Animator.SetFloat("HorizontalMove", MoveDirection.x);
                PlayerSystem.Instance.Animator.SetFloat("VerticalMove", MoveDirection.z);

                // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
                MoveDirection = transform.TransformDirection(MoveDirection.normalized);

                // 스피드 증가.
                MoveDirection *= MoveSpeed;
            }

            // 캐릭터 움직임.
            PlayerSystem.Instance.Rigidbody.MovePosition(transform.position + MoveDirection * Time.deltaTime);
        }

        #endregion

    }
}
