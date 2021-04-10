using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class GravitySystem : SceneObject<GravitySystem>
    {
        #region 변수

        [OdinSerialize, LabelText("중력")] float m_gravity;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            Physics.gravity = Vector3.down * m_gravity;
        }

        #endregion
    }
}
