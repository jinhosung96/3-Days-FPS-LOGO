using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 스테이트 머신에 의해 제어되는 스테이트에 대한 부모 클래스, 스테이트 머신의 현재 상태가 본 상태일 경우에만 작동한다. <para></para>
    /// 참고 : 스테이트 패턴 - https://victorydntmd.tistory.com/294 <para></para>
    /// 
    /// ----- 공개 메소드 ----- <para></para>
    /// OnEnter() : 본 상태로 진입했을 때 1회 실행 <para></para>
    /// OnExit() : 본 상태에서 빠져나갈 때 1회 실행 <para></para>
    /// OnReset() : 본 상태에서 빠져나갈 때 필요에 따라 1회 실행 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. StateMachine 객체가 없을 시 참조 오류 발생 <para></para>
    ///
    /// </summary>
     #endregion
    [RequireComponent(typeof(StateMachine))]
    public class State : MonoBehaviour
    {
        #region 변수

        protected StateMachine m_machine;

        #endregion

        #region 유니티 생명 주기

        protected void Awake()
        {
            m_machine = GetComponent<StateMachine>();
            OnAwake();
        }

        protected void OnEnable()
        {
            OnActive();
        }

        protected void Start()
        {
            OnStart();
        }

        protected void FixedUpdate()
        {
            if (m_machine.m_currentState != this) return;
            OnFixedUpdate();
        }

        // Update is called once per frame
        protected void Update()
        {
            if (m_machine.m_currentState != this) return;
            OnUpdate();
        }

        protected void LateUpdate()
        {
            if (m_machine.m_currentState != this) return;
            OnLateUpdate();
        }

        protected void OnDisable()
        {
            OnInActive();
        }

        #endregion

        #region 가상 함수

        ////////////////////////////////////////////
        // 가상 함수, 자식에서 오버라이드해서 사용//
        ////////////////////////////////////////////

        // 유니티 생명주기 상의 Awake에서 실행
        // StateMachine을 초기화 후 실행
        // 본 객체가 비활성화 상태여도 실행
        protected virtual void OnAwake() { }

        // 유니티 생명주기 상의 OnEnable에서 실행
        protected virtual void OnActive() { }

        // 유니티 생명주기 상의 Start에서 실행
        protected virtual void OnStart() { }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태로 진입했을 때 1회 실행
        public virtual void OnEnter() { } // 해당 상태로 진입했을 때

        // 유니티 생명주기 상의 FixedUpdate에서 실행
        // 물리 연산 처리는 해당 메소드에서 처리
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected virtual void OnFixedUpdate() { }

        // 유니티 생명주기 상의 Update에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected virtual void OnUpdate() { }
        
        // 유니티 생명주기 상의 LateUpdate에서 실행
        // 스테이트 머신의 현 상태가 본 상태일 때만 실행
        protected virtual void OnLateUpdate() { }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 실행
        // 본 상태에서 나갈 때 1회 실행
        // StopAllCourtine() 등 실행
        public virtual void OnExit() { }

        // m_machine.SetState(State _state, bool _isReset = true) 함수  호출 시 매개 변수 _isReset에 인자값으로 true를 전달할 시 실행
        // 본 상태에서 나갈 때 1회 실행
        public virtual void OnReset() { }

        // 유니티 생명주기 상의 OnDisable에서 실행
        protected virtual void OnInActive() { }

        #endregion
    }
}
