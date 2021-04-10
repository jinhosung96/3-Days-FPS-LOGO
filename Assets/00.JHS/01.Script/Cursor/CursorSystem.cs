using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class CursorSystem : SceneObject<CursorSystem>
    {
        #region 변수

        [OdinSerialize, LabelText("마우스 커서 숨김 여부")] bool m_isCursorVisible;
        [OdinSerialize, LabelText("마우스 커서 잠금 모드")] CursorLockMode m_cursorLockMode;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {

            Cursor.visible = m_isCursorVisible;
            Cursor.lockState = m_cursorLockMode;

            EventManager.Instance.AddListener("게임 오버", ()=> 
            { 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            });
            EventManager.Instance.AddListener("스테이지 클리어", () =>
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None; 
            });
        }

        #endregion
    }
}
