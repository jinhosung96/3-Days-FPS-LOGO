using Michsky.UI.Dark;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{
  public class PanelController : MonoBehaviour
    {
        #region 변수

        [SerializeField] bool m_enableBrushAnimation;
        [SerializeField] LayoutGroup[] m_layouts;        
        [SerializeField] GameObject m_prevKeyShortCutList;

        #endregion

        #region 외부 API

        public void ShowPanel()
        {

            GetComponent<Animator>().Play("Panel In");

            if (m_enableBrushAnimation == true)
            {
                PanelBrushManager nextBrush = GetComponent<PanelBrushManager>();
                if (nextBrush.brushAnimator != null)
                    nextBrush.BrushSplashIn();
            }

            for (int i = 0; i < m_layouts.Length; i++)
            {
                m_layouts[i].enabled = false;
                m_layouts[i].enabled = true;
            }
            m_prevKeyShortCutList.SetActive(false);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
        }

        public void HidePanel()
        {
            GetComponent<Animator>().Play("Panel Out");

            if (m_enableBrushAnimation == true)
            {
                PanelBrushManager nextBrush = GetComponent<PanelBrushManager>();
                if (nextBrush.brushAnimator != null)
                    nextBrush.BrushSplashOut();
            }
            m_prevKeyShortCutList.SetActive(true);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Time.timeScale = 1;
        }

        #endregion
    }
}
