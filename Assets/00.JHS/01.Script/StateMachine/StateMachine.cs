using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 각 스테이트를 관리하는 스테이트 머신 <para></para>
    /// 참고 : 스테이트 패턴 - https://victorydntmd.tistory.com/294 <para></para>
    /// 
    /// ----- 공개 속성 ----- <para></para>
    /// m_currentState : 현재 상태 반환(읽기 전용) <para></para>
    ///
    /// ----- 공개 메소드 ----- <para></para>
    /// SetState(State _nextState, bool _isReset = true) : 현재 상태를 _nextState로 전환. _isReset이 true일 시 상태를 바꾸기 전에 OnReset() 함수 호출 후 상태 전환 <para></para>
    /// PrevState() : 현재 상태를 이전 상태로 전환 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. State 객체가 없을 시 참조 오류 발생 <para></para>
    ///
    /// </summary>
     #endregion
    public class StateMachine : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("초기 상태")] State m_initState;
        public State m_currentState { get; private set; }
        State m_prevState;

        #endregion

        #region 유니티 생명주기

        private void OnEnable()
        {
            SetState(m_initState);
        }

        #endregion

        #region 인터페이스부

        public void SetState(State _nextState, bool _isReset = true)
        {
            m_prevState = m_currentState; // 현재 상태를 이전 상태로
            m_prevState?.OnExit(); // 이전 상태 종료
            if (_isReset) m_prevState?.OnReset(); // 이전 상태 리셋
            m_currentState = _nextState; // 현재 상태를 다음 상태로
            m_currentState?.OnEnter(); // 현재 상태 시작
        }

        public void PrevState()
        {
            State temp = m_prevState;
            m_prevState = m_currentState;
            m_currentState?.OnExit();
            m_currentState = temp;
            m_currentState?.OnEnter();
        }

        #endregion
    }
}
