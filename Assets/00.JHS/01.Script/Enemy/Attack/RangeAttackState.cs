using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class RangeAttackState : State
    {
        #region 변수

        [SerializeField, LabelName("다음 상태")] State m_nextState;
        [SerializeField, LabelName("투사체")] GameObject m_projectole;
        [SerializeField, LabelName("발사 위치")] Transform m_firePos;
        [SerializeField, LabelName("공격 데미지")] float m_attackDamage;
        [SerializeField, LabelName("발사 사운드")] AudioClip m_shootEffectSound;


        Animator m_animator;

        #endregion

        #region 콜백 함수

        // 유니티 생명주기 상의 Awake에서 실행
        // StateMachine을 초기화 후 실행
        // 본 객체가 비활성화 상태여도 실행
        protected override void OnAwake()
        {
            m_animator = GetComponent<Animator>();
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태로 진입했을 때 1회 실행
        public override void OnEnter()
        {
            transform.LookAt(PlayerSystem.Instance.PlayerTr.position);

            m_animator.SetBool("IsAttack", true);
        }

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            ChangeState();
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public override void OnExit()
        {
            m_animator.SetBool("IsAttack", false);
        }

        #endregion

        #region 외부 API

        public void Shoot()
        {
            GameObject projectile = PoolManager.Instance.PopObject(m_projectole);
            projectile.transform.position = m_firePos.position;
            projectile.transform.forward = transform.forward;
            projectile.transform.parent = FolderSystem.Instance.ProjectileFolder;
            projectile.GetComponent<OnCollisionEnterAttack>().AttackDamage = m_attackDamage;
            SoundManager.Instance.PlaySoundEffect(m_shootEffectSound);
        }

        #endregion

        #region 구현부

        private void ChangeState()
        {
            bool animationExit = m_animator.GetCurrentAnimatorStateInfo(0).IsName("Range Attack")
                && m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f - m_animator.GetAnimatorTransitionInfo(0).duration;

            if (animationExit)
            {
                m_machine.SetState(m_nextState);
            }
        }

        #endregion
    }
}
