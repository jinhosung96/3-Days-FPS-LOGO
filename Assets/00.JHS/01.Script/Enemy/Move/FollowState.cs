using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace JHS
{    
    public class FollowState : State
    {
        #region 변수

        [SerializeField, LabelName("접근 거리")] float m_followDistance;
        [SerializeField, LabelName("다음 상태")] State m_nextState;

        NavMeshAgent m_agent;

        #endregion

        #region 콜백 함수

        // 유니티 생명주기 상의 Awake에서 실행
        // StateMachine을 초기화 후 실행
        // 본 객체가 비활성화 상태여도 실행
        protected override void OnAwake()
        {
            m_agent = GetComponent<NavMeshAgent>();
        }

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected override void OnUpdate()
        {
            Follow();
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

        private void Follow()
        {
            m_agent.SetDestination(BossSystem.Instance.BossTr.position);
            m_agent.isStopped = false;
        }

        private void ChangeState()
        {
            if (m_nextState && Vector3.Distance(transform.position, BossSystem.Instance.BossTr.position) <= m_followDistance)
            {
                m_machine.SetState(m_nextState);
            }
        }

        #endregion
    }
}
