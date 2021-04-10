using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class BossSystem : SceneObject<BossSystem>
    {
        #region 변수

        [SerializeField, LabelName("보스 객체")]GameObject m_bossGO;

        BossHPController m_bossHPController;
        RoarController m_roarController;

        #endregion

        #region 공개 속성

        public GameObject BossGO => m_bossGO;
        public Transform BossTr => m_bossGO.transform;

        public BossHPController BossHPController
        {
            get
            {
                if (m_bossHPController == null) m_bossHPController = BossGO.GetComponent<BossHPController>();
                return m_bossHPController;
            }
        }
        public RoarController RoarController
        {
            get
            {
                if (m_roarController == null) m_roarController = BossGO.GetComponent<RoarController>();
                return m_roarController;
            }
        }

        #endregion
    }
}
