using UnityEngine;

namespace JHS
{
    #region 인터페이스

    public interface ICollisionEnter { void CollisionEnter(Collision collision); }   
    public interface ICollisionStay { void CollisionStay(Collision collision); }
    public interface ICollisionExit { void CollisionExit(Collision collision); }
    public interface ITriggerEnter { void TriggerEnter(Collider other); }
    public interface ITriggerStay { void TriggerStay(Collider other); }
    public interface ITriggerExit { void TriggerExit(Collider other); }
    public interface IParticleTrigger { void ParticleTrigger(); }
    public interface IParticleCollision { void ParticleCollision(GameObject other); }

    #endregion

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 충돌 처리 순차 제어 <para></para>
    ///
    /// </summary>
    #endregion
    public class OnCollisionAction : MonoBehaviour
    {
        #region 변수

        ICollisionEnter[] m_collisionEnters;
        ICollisionStay[] m_collisionStays;
        ICollisionExit[] m_collisionExits;
        ITriggerEnter[] m_triggerEnters;
        ITriggerStay[] m_triggerStays;
        ITriggerExit[] m_triggerExits;
        IParticleTrigger[] m_particleTriggers;
        IParticleCollision[] m_particleCollisions;

        #endregion

        #region 유니티 생명주기

        private void Awake()
        {
            m_collisionEnters = GetComponents<ICollisionEnter>();
            m_collisionStays = GetComponents<ICollisionStay>();
            m_collisionExits = GetComponents<ICollisionExit>();
            m_triggerEnters = GetComponents<ITriggerEnter>();
            m_triggerStays = GetComponents<ITriggerStay>();
            m_triggerExits = GetComponents<ITriggerExit>();
            m_particleTriggers = GetComponents<IParticleTrigger>();
            m_particleCollisions = GetComponents<IParticleCollision>();
        }

        #endregion

        #region 콜백 함수

        // OnCollisionEnter는 이 collider/rigidbody가 다른 rigidbody/collider에 접촉되기 시작하면 호출됩니다.
        private void OnCollisionEnter(Collision collision)
        {
            if (m_collisionEnters == null) return;
            for (int i = 0; i < m_collisionEnters.Length; i++)
            {
                m_collisionEnters[i].CollisionEnter(collision);
            }
        }

        // OnCollisionStay는 다른 collider/rigidbody에 접촉되어 있는 모든 rigidbody/collider에 대해 프레임당 한 번 호출됩니다.
        private void OnCollisionStay(Collision collision)
        {
            if (m_collisionStays == null) return;
            for (int i = 0; i < m_collisionStays.Length; i++)
            {
                m_collisionStays[i].CollisionStay(collision);
            }
        }

        // OnCollisionExit는 이 collider/rigidbody가 다른 rigidbody/collider 접촉을 중단하면 호출됩니다.
        private void OnCollisionExit(Collision collision)
        {
            if (m_collisionExits == null) return;
            for (int i = 0; i < m_collisionExits.Length; i++)
            {
                m_collisionExits[i].CollisionExit(collision);
            }
        }

        // OnTriggerEnter는 Collider other가 트리거가 될 때 호출됩니다.
        private void OnTriggerEnter(Collider other)
        {
            if (m_triggerEnters == null) return;
            for (int i = 0; i < m_triggerEnters.Length; i++)
            {
                m_triggerEnters[i].TriggerEnter(other);
            }
        }

        // OnTriggerStay는 트리거와 접촉하고 있는 모든 Collider other에 대해 프레임당 한 번 호출됩니다.
        private void OnTriggerStay(Collider other)
        {
            if (m_triggerStays == null) return;
            for (int i = 0; i < m_triggerStays.Length; i++)
            {
                m_triggerStays[i].TriggerStay(other);
            }
        }

        // OnTriggerExit는 Collider other가 트리거 접촉을 중지한 경우 호출됩니다.
        private void OnTriggerExit(Collider other)
        {
            if (m_triggerExits == null) return;
            for (int i = 0; i < m_triggerExits.Length; i++)
            {
                m_triggerExits[i].TriggerExit(other);
            }
        }

        // 파티클 시스템의 파티클이 트리거 모듈의 조건을 충족하는 경우 호출됨
        private void OnParticleTrigger()
        {
            if (m_particleTriggers == null) return;
            for (int i = 0; i < m_particleTriggers.Length; i++)
            {
                m_particleTriggers[i].ParticleTrigger();
            }
        }

        // OnParticleCollision은 particle이 collider에 도달할 때 호출됩니다.
        private void OnParticleCollision(GameObject other)
        {
            if (m_particleCollisions == null) return;
            for (int i = 0; i < m_particleCollisions.Length; i++)
            {
                m_particleCollisions[i].ParticleCollision(other);
            }
        }

        #endregion
    }
}
