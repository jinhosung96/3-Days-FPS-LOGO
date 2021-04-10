using UnityEngine;

namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-11-26 <para></para>
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
    public class OnCollisionEnterAttack : MonoBehaviour, ICollisionEnter
    {
        #region 변수

        float m_attackDamage;

        #endregion

        #region 공개 속성

        public float AttackDamage { get => m_attackDamage; set => m_attackDamage = value; }

        #endregion

        #region 외부 API

        public void CollisionEnter(Collision collision)
        {
            HPController hpController = collision.gameObject.GetComponent<HPController>();
            if(hpController !=  null) hpController.TakeDamage(AttackDamage);
        }

        #endregion

        #region 구현부



        #endregion
    }
}
