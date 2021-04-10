using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class PauseSystem : MonoBehaviour
    {
        #region 변수

        [SerializeField] PanelController m_pausePanel;

        #endregion

        #region 유니티 생명주기

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_pausePanel.ShowPanel();
            }
        }

        #endregion
    }
}
