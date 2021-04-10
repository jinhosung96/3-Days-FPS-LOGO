using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class RoarController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("쿨타임")] float m_roarCoolDownTime;
        bool m_isRoarOn = true;

        #endregion

        #region 공개 속성

        public bool IsRoarOn { get => m_isRoarOn; set => m_isRoarOn = value; }

        #endregion

        #region 유니티 생명주기

        void OnEnable()
        {
            StartCoroutine(Co_CoolDownRoar());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        #endregion

        #region 구현부

        IEnumerator Co_CoolDownRoar()
        {
            while (true)
            {
                while (m_isRoarOn) yield return null;

                yield return new WaitForSeconds(m_roarCoolDownTime);

                IsRoarOn = true;
            }
        }

        #endregion
    }
}
