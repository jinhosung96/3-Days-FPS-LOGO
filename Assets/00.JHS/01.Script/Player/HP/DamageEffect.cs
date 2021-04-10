using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{    
    public class DamageEffect : MonoBehaviour
    {
        #region 변수

        CanvasGroup m_effectImage;

        float m_timer;
        [SerializeField, LabelName("효과 지속시간")] float m_duration;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            m_effectImage = GetComponent<CanvasGroup>();

            EventManager.Instance.AddListener("플레이어 체력 갱신", () => { m_timer = m_duration; });
        }

        void Update()
        {
            if (m_timer > 0)
            {
                m_effectImage.alpha = Mathf.Lerp(m_effectImage.alpha, 1, 0.1f); 
                m_timer -= Time.unscaledDeltaTime;
            }
            else m_effectImage.alpha = Mathf.Lerp(m_effectImage.alpha, 0, 0.1f);
        }

        #endregion
    }
}
