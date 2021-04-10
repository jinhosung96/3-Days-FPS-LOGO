using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public class BossHPController : EnemyHPController
    {
        #region 구현부

        protected override void RefreshUIElement()
        {
            EventManager.Instance.PostNofication("보스 체력 갱신");
        }

        protected override void OnDeath()
        {
            base.OnDeath();

            InGameUISystem.Instance.StageClearView.Show();
            InGameUISystem.Instance.StageClearMoalWindowManager.ModalWindowIn();

            EventManager.Instance.PostNofication("스테이지 클리어");
        }

        #endregion
    }
}
