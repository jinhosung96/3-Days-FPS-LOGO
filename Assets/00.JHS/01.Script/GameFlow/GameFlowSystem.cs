using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class GameFlowSystem : SingletonObject<GameFlowSystem>
    {
        #region 변수

        bool m_isStart;

        #endregion

        #region 공개 속성

        public bool IsStart { get => m_isStart; set => m_isStart = value; }

        #endregion
    }
}
