using UnityEngine;
using System.Collections;

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-11-13 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 :  <para></para>
    /// 
    /// ----- 공개 메소드 ----- <para></para>
    /// OnCollisionEnter(Collision collision) : 해당 객체가 충돌 했을 때 호출
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 객체에 컴포넌트로 OnCollisionAction가 있어야 한다.
    ///
    /// </summary>
     #endregion
    [RequireComponent(typeof(OnCollisionAction))]
    public class OnCollisionEnterDestroy : MonoBehaviour, ICollisionEnter
    {
        #region 유니티 생명주기

        private void OnEnable()
        {
            StartCoroutine(Co_DelayPush());
        }

        #endregion

        #region 외부 API

        public void CollisionEnter(Collision collision)
        {
            PoolManager.Instance.PushObject(gameObject);
            StopAllCoroutines();
        }

        #endregion

        #region 구현부

       IEnumerator Co_DelayPush()
        {
            yield return new WaitForSeconds(5);

            PoolManager.Instance.PushObject(gameObject);
        }

        #endregion
    }
}
