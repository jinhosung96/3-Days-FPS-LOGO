using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{    
    public class BossHPBar : MonoBehaviour
    {
        #region 변수

        Slider m_bossHPBar;
        Animator m_animator;

        float m_targetValueByHPBar01 = 1;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            m_bossHPBar = GetComponent<Slider>();
            m_animator = GetComponent<Animator>();

            EventManager.Instance.AddListener("보스 체력 갱신", RefreshUIElement);
        }

        void Update()
        {
            if (Mathf.Abs(m_bossHPBar.value - m_targetValueByHPBar01) > 0.001f)
            {
                m_bossHPBar.value = Mathf.Lerp(m_bossHPBar.value, m_targetValueByHPBar01, 0.3f);
                if (Mathf.Abs(m_bossHPBar.value - m_targetValueByHPBar01) <= 0.001f)
                {
                    m_bossHPBar.value = m_targetValueByHPBar01;
                    m_animator.SetBool("IsNormal", true);
                }
            }
        }

        #endregion

        #region 구현부

        void RefreshUIElement()
        {
            m_targetValueByHPBar01 = BossSystem.Instance.BossHPController.CurrentHP / BossSystem.Instance.BossHPController.MaxHP;
            m_animator.SetTrigger("Pressed");
            m_animator.SetBool("IsNormal", false);
        }

        #endregion
    }
}
