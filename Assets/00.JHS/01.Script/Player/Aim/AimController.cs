using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class AimController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("수직 상향 제한 반경")] float m_playerVerticalUpRotationLimit;
        [SerializeField, LabelName("수직 하향 제한 반경")] float m_playerVerticalDownRotationLimit;
        [SerializeField, LabelName("허리 회전 오프셋")] Vector3 m_spineOffset;

        float m_mouseSensitivity;
        float m_currentPlayerRotationX;
        float m_currentPlayerRotationY;

        #endregion

        #region 유니티 생명주기

        private void Start()
        {
            SetSensitivity(PlayerPrefs.GetFloat("SensitivityDarkSliderValue"));
        }

        void Update()
        {
            if (PlayerSystem.Instance.Pause) return;

            Aim();

            transform.localEulerAngles = new Vector3(0f, m_currentPlayerRotationY, 0f);
        }

        private void LateUpdate()
        {
            if (PlayerSystem.Instance.Pause) return;

            CameraSystem.Instance.CameraArm.localEulerAngles = new Vector3(-m_currentPlayerRotationX, transform.localEulerAngles.y, 0f);

            Vector3 spineDir = CameraSystem.Instance.CameraArm.position + CameraSystem.Instance.CameraArm.forward * 20f;
            PlayerSystem.Instance.PlayerSpineTr.LookAt(spineDir);
            PlayerSystem.Instance.PlayerSpineTr.rotation = PlayerSystem.Instance.PlayerSpineTr.rotation * Quaternion.Euler(m_spineOffset);
        }

        #endregion

        #region 외부 API

        public void SetSensitivity(float _value)
        {
            m_mouseSensitivity = _value * 5 + 1;
        }

        #endregion

        #region 구현부

        void Aim()
        {
            RotateVertical();
            RotateHorizontal();
        }

        void RotateVertical()
        {
            float xRotation = Input.GetAxisRaw("Mouse Y");
            float playerRotaionX = xRotation * m_mouseSensitivity * Time.timeScale;
            m_currentPlayerRotationX += playerRotaionX;
            m_currentPlayerRotationX = Mathf.Clamp(m_currentPlayerRotationX, -m_playerVerticalDownRotationLimit, m_playerVerticalUpRotationLimit);
        }

        void RotateHorizontal()
        {
            float yRotation = Input.GetAxisRaw("Mouse X");
            float playerRotaionY = yRotation * m_mouseSensitivity * Time.timeScale;
            m_currentPlayerRotationY += playerRotaionY;
        }

        #endregion
    }
}
