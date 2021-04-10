using System.Collections.Generic;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 해당 씬에서 일어나는 이벤트 제어 <para></para>
    /// 참고 : 옵저버 패턴 - https://victorydntmd.tistory.com/296?category=719467 <para></para>
    /// 
    /// ----- 공개 메소드 ----- <para></para>
    /// AddListener(string _eventType, Reaction _reaction) : 리스너 추가, 리스너는 해당 이벤트가 일어났을 때 지정된 리액션을 실행한다. <para></para>
    /// PostNofication(string _eventType) : 지정된 이벤트가 발생했다고 리스너들에게 알림 <para></para>
    /// ClearListeners() : 리스너 목록 초기화 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. Awake()문 오버라이드시 base.Awake()를 필히 호출해야한다. <para></para>
    ///
    /// </summary>
    #endregion
    public class EventManager : SceneObject<EventManager>
    {
        #region 변수

        public delegate void Reaction();
        Dictionary<string, List<Reaction>> m_listeners = new Dictionary<string, List<Reaction>>();

        #endregion

        #region 외부 API

        /// <summary>
        /// 리스너 추가
        /// 리스너는 해당 이벤트가 일어났을 때 지정된 리액션을 실행한다.
        /// </summary>
        /// <param LabelName="_eventType">리액션을 일으킬 이벤트</param>
        /// <param LabelName="_reaction">이벤트가 일어났을 때 실행할 리액션</param>
        public void AddListener(string _eventType, Reaction _reaction)
        {
            if (!m_listeners.ContainsKey(_eventType))
            {
                List<Reaction> tempList = new List<Reaction>();
                m_listeners.Add(_eventType, tempList);
            }

            m_listeners[_eventType].Add(_reaction);
        }

        /// <summary>
        /// 지정된 이벤트가 발생했다고 리스너들에게 알림
        /// 
        /// </summary>
        /// <param LabelName="_eventType">전달할 이벤트</param>
        public void PostNofication(string _eventType)
        {
            if (!m_listeners.ContainsKey(_eventType)) return;

            for (int i = 0; i < m_listeners[_eventType].Count; i++)
            {
                m_listeners[_eventType][i]();
            }
        }

        /// <summary>
        /// 리스너 목록 초기화
        /// </summary>
        public void ClearListeners()
        {
            m_listeners.Clear();
        }

        #endregion
    } 
}
