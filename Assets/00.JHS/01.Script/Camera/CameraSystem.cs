using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class CameraSystem : SceneObject<CameraSystem>
    {
        #region 변수

        [OdinSerialize, LabelText("카메라 암")] Transform m_cameraArm;
        [OdinSerialize, LabelText("FPS 카메라")] Camera m_fpsCamera;
        [OdinSerialize, LabelText("TPS 카메라")] Camera m_tpsCamera;

        CameraArmController m_cameraArmController;

        bool m_isfps;

        #endregion

        #region 공개 속성

        public Transform CameraArm => m_cameraArm;
        public Camera FPSCamera => m_fpsCamera;
        public Camera TPSCamera => m_tpsCamera;

        public CameraArmController CameraArmController
        {
            get
            {
                if (m_cameraArmController == null) m_cameraArmController = CameraArm.GetComponent<CameraArmController>();

                return m_cameraArmController;
            }
        }

        public bool Isfps { get => m_isfps; private set => m_isfps = value; }

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            Isfps = true;
            FPSCamera.enabled = true;
            TPSCamera.enabled = false;
            for (int i = 0; i < PlayerSystem.Instance.ViewController.BodyRenderers.Length; i++)
            {
                PlayerSystem.Instance.ViewController.BodyRenderers[i].enabled = false;
            }
        }

        void Update()
        {
            if (PlayerSystem.Instance.Pause) return;

            if (Input.GetButtonDown("ChangeCamera"))
            {
                ChangeCamera();
            }
        }

        #endregion

        #region 외부API

        public void ChangeCamera()
        {
            if (Isfps)
            {
                TPSCamera.enabled = true;
                FPSCamera.enabled = false;
                for (int i = 0; i < PlayerSystem.Instance.ViewController.BodyRenderers.Length; i++)
                {
                    PlayerSystem.Instance.ViewController.BodyRenderers[i].enabled = true;
                }
            }
            else
            {
                FPSCamera.enabled = true;
                TPSCamera.enabled = false;
                for (int i = 0; i < PlayerSystem.Instance.ViewController.BodyRenderers.Length; i++)
                {
                    PlayerSystem.Instance.ViewController.BodyRenderers[i].enabled = false;
                }
            }
            Isfps = !Isfps;
        }

        #endregion
    }
}
