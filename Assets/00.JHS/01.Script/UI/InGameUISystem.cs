using Doozy.Engine.UI;
using Michsky.UI.Dark;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class InGameUISystem : SceneObject<InGameUISystem>
    {
        #region 변수

        [OdinSerialize, LabelText("게임 오버 뷰")] UIView m_gameOverView;
        [OdinSerialize, LabelText("스테이지 클리어 뷰")] UIView m_stageClearView;

        ModalWindowManager m_gameOverMoalWindowManager;
        ModalWindowManager m_stageClearMoalWindowManager;

        #endregion

        #region 공개 속성

        public UIView GameOverView => m_gameOverView;
        public ModalWindowManager GameOverMoalWindowManager
        {
            get
            {
                if (m_gameOverMoalWindowManager == null) m_gameOverMoalWindowManager = GameOverView.GetComponent<ModalWindowManager>();
                return m_gameOverMoalWindowManager;
            }
        }

        public UIView StageClearView => m_stageClearView;
        public ModalWindowManager StageClearMoalWindowManager
        {
            get
            {
                if (m_stageClearMoalWindowManager == null) m_stageClearMoalWindowManager = StageClearView.GetComponent<ModalWindowManager>();
                return m_stageClearMoalWindowManager;
            }
        }

        #endregion
    }
}
