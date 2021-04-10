using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class AutoDestroyer : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("수명")] float m_lifeTime;

        #endregion

        #region 유니티 생명주기

        void OnEnable()
        {
            StartCoroutine(Co_AutoDestroy());
        }

        #endregion

        #region 구현부

        IEnumerator Co_AutoDestroy()
        {
            yield return new WaitForSeconds(m_lifeTime);

            PoolManager.Instance.PushObject(this.gameObject);
        }

        #endregion
    }
}
