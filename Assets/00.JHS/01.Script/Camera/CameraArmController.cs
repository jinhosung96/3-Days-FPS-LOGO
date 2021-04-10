using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class CameraArmController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("카메라 바디 오프셋")] Vector3 m_cameraBodyOffset;

        #endregion

        #region 공개 속성

        public Vector3 CameraBodyOffset { get => m_cameraBodyOffset; set => m_cameraBodyOffset = value; }

        #endregion

        #region 유니티 생명주기

        void LateUpdate()
        {
            Transform playerTr = PlayerSystem.Instance.PlayerTr;

            transform.position
                = playerTr.position
                + playerTr.right * CameraBodyOffset.x
                + playerTr.up * CameraBodyOffset.y
                + playerTr.forward * CameraBodyOffset.z;
        }

        #endregion
    }
}
