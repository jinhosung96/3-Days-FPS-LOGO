using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-02 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 투사체 이동 방법 제어 <para></para>
    /// 
    /// ----- 공개 속성 ----- <para></para>
    /// AttackDamage : 투사체 적중 시 입는 데미지 <para></para>
    /// KnuckBack : 투사체 적중 시 넉백되는 정보 (현재 사용되지 않고 있다) <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. 충돌 시 투사체를 파괴해버리기 때문에 다른 컴포넌트에서 제어되는 충돌 판정이 정상 작동을 안할 수가 있다. <para></para>
    /// 
    /// TODO 진호성 : 충돌 처리에 대한 구조를 새로 짤 필요성이 있음 <para></para>
    ///
    /// </summary>
     #endregion
    public class ProjectileMover : MonoBehaviour
    {
        #region 변수

        private Rigidbody m_rigidbody;
        [SerializeField] float speed = 15f;
        [SerializeField] GameObject flash;

        public Rigidbody Rigidbody
        {
            get
            {
                if(m_rigidbody ==  null) m_rigidbody = GetComponent<Rigidbody>();
                return m_rigidbody;
            }
        }

        #endregion

        #region 유니티 생명주기

        private void OnEnable()
        {
            Rigidbody.constraints = RigidbodyConstraints.None;
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.angularVelocity = Vector3.zero;
        }

        void FixedUpdate()
        {
            Rigidbody.velocity = transform.forward * speed;
        }

        #endregion

        #region 외부 API

        public void Flash()
        {
            if (flash != null)
            {
                var flashInstance = PoolManager.Instance.PopObject(flash);
                flashInstance.transform.position = transform.position;
                flashInstance.transform.localRotation = Quaternion.identity;
                flashInstance.transform.parent = FolderSystem.Instance.ProjectileFolder;
                flashInstance.layer = this.gameObject.layer;

                flashInstance.transform.forward = gameObject.transform.forward;
                var flashPs = flashInstance.GetComponent<ParticleSystem>();
                if (flashPs != null)
                {
                    PoolManager.Instance.DelayPushObject(flashInstance, flashPs.main.duration);
                }
                else
                {
                    var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    PoolManager.Instance.DelayPushObject(flashInstance, flashPsParts.main.duration);
                }
            }
        }

        #endregion
    } 
}
