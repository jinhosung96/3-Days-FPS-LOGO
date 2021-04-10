using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class FolderSystem : SceneObject<FolderSystem>
    {
        #region 변수

        [OdinSerialize, LabelText("투사체 폴더")] Transform m_projectileFolder;
        [OdinSerialize, LabelText("적 유닛 폴더")] Transform m_enemyFolder;

        #endregion

        #region 공개 속성

        public Transform ProjectileFolder => m_projectileFolder;

        public Transform EnemyFolder => m_enemyFolder;

        #endregion
    }
}
