using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class JumpController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("점프 속도")] float m_jumpSpeed;
        [SerializeField, LabelName("착지음")] AudioClip m_landSound;

        bool m_isGrounded;
        bool m_isJump;

        #endregion

        #region 공개 속성

        public bool IsGrounded
        {
            get => m_isGrounded;
            set
            {
                if (m_isGrounded != value)
                {
                    m_isGrounded = value;
                    PlayerSystem.Instance.Animator.SetBool("IsGrounded", IsGrounded);
                }
            }
        }

        #endregion

        #region 유니티 생명주기

        void FixedUpdate()
        {
            if (PlayerSystem.Instance.Pause) return;

            IsGround();
            Jump();
        }

        #endregion

        #region 구현부

        private void IsGround()
        {
            Vector3 center = transform.TransformPoint(PlayerSystem.Instance.CapsuleCollider.center);
            Vector3 direction = Vector3.down;
            float maxDistance = PlayerSystem.Instance.CapsuleCollider.bounds.extents.y + 0.1f;
            float radius = PlayerSystem.Instance.CapsuleCollider.bounds.extents.x - 0.1f;

            IsGrounded = 
                Physics.Raycast(center, direction, maxDistance) 
                || Physics.Raycast(center + Vector3.forward * radius, direction, maxDistance)
                || Physics.Raycast(center + Vector3.back * radius, direction, maxDistance)
                || Physics.Raycast(center + Vector3.right * radius, direction, maxDistance)
                || Physics.Raycast(center + Vector3.left * radius, direction, maxDistance);
        }

        private void Jump()
        {
            // 캐릭터 점프
            if (Input.GetButton("Jump") && IsGrounded && !m_isJump)
            {
                PlayerSystem.Instance.Rigidbody.velocity = transform.up * m_jumpSpeed;
                PlayerSystem.Instance.Animator.SetTrigger("DoJump");
                m_isJump = true;
            }
        }

        private void Land()
        {
            m_isJump = false;
            SoundManager.Instance.PlaySoundEffect(m_landSound, 2f);
        }

        #endregion
    }
}
