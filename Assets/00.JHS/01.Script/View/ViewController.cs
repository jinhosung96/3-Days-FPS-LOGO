using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class ViewController : MonoBehaviour
    {
        #region 변수

        [SerializeField] Renderer[] m_bodyRenderers;

        #endregion

        #region 공개 속성

        public Renderer[] BodyRenderers => m_bodyRenderers;

        #endregion
    }
}
