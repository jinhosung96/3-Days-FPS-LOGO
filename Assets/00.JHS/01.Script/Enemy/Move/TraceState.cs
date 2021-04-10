using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JHS
{    
    public class TraceState : State
    {
        #region 변수

        [SerializeField, LabelName("접근 거리")] float m_traceDistance;
        [SerializeField, LabelName("다음 상태")] State m_nextState;
        [SerializeField, LabelName("Roar 상태")] State m_roarState;

        NavMeshAgent m_agent;
        Animator m_animator;

        #endregion

        #region 콜백 함수

        // 유니티 생명주기 상의 Awake에서 실행
        // StateMachine을 초기화 후 실행
        // 본 객체가 비활성화 상태여도 실행
        protected override void OnAwake()
        {
            m_agent = GetComponent<NavMeshAgent>();
            m_animator = GetComponent<Animator>();
        }

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            Trace();
            ChangeState();
        }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public override void OnExit()
        {
            m_agent.ResetPath();
            m_agent.isStopped = true;
        }

        #endregion

        #region 구현부

        private void Trace()
        {
            m_agent.SetDestination(PlayerSystem.Instance.PlayerTr.position);
            m_agent.isStopped = false;
        }

        private void ChangeState()
        {
            if(m_roarState != null && BossSystem.Instance.RoarController.IsRoarOn)
            {
                m_machine.SetState(m_roarState);
            }
            if (m_nextState && Vector3.Distance(transform.position, PlayerSystem.Instance.PlayerTr.position) <= m_traceDistance)
            {
                m_machine.SetState(m_nextState);
            }
        }

        #endregion
    }
}
