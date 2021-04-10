using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class CrouchController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("앉은 상태 이동 속도")] float m_crouchSpeed;
        [SerializeField, LabelName("앉았을 때 Y 값")] float m_crouchPosY;

        bool m_isCrouch;
        float m_originPosY;
        float m_applyCrouchPosY;

        #endregion

        #region 공개 속성



        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            
        }

        void Start()
        {
            m_originPosY = CameraSystem.Instance.FPSCamera.transform.localPosition.y;
            m_applyCrouchPosY = m_originPosY;
        }

        void Update()
        {
            
        }

        #endregion

        #region 구현부

        void Crouch()
        {
            m_isCrouch = !m_isCrouch;

            if (m_isCrouch)
            {
                //m_applyCrouchPosY = m_crouchPosY
            }
        }

        #endregion
    }
}
