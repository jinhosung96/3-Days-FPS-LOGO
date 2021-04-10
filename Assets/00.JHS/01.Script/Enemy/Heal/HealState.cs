using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JHS
{    
    public class HealState : State
    {
        #region 변수

        [SerializeField, LabelName("사정 거리")] float m_healDistance;
        [SerializeField, LabelName("회복의 광선")] HealBeamStatic m_healBeamStatic;
        [SerializeField, LabelName("초당 회복량")] float m_healPerSecond;
        [SerializeField, LabelName("회복 주기")] float m_healCycle;
        [SerializeField, LabelName("다음 상태")] State m_nextState;


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
            m_animator.SetBool("IsHeal", true);
        }

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            transform.LookAt(BossSystem.Instance.BossTr.position);

            ChangeState();
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public override void OnExit()
        {
            m_healBeamStatic.RemoveBeam();
            StopAllCoroutines();
            m_animator.SetBool("IsHeal", false);
        }

        #endregion

        #region 구현부

        public void Heal()
        {
            m_healBeamStatic.SpawnBeam();
            StartCoroutine(Co_Heal());
        }

        IEnumerator Co_Heal()
        {
            while (true)
            {
                BossSystem.Instance.BossHPController.CurrentHP += m_healPerSecond * m_healCycle;
                yield return new WaitForSeconds(m_healCycle);
            }
        }

        private void ChangeState()
        {            
            if (m_nextState && Vector3.Distance(transform.position, BossSystem.Instance.BossTr.position) > m_healDistance)
            {
                m_machine.SetState(m_nextState);
            }
        }

        #endregion
    }
}
