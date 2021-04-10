using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class PauseObject : MonoBehaviour
    {
        #region 유니티 생명주기

        void OnEnable()
        {
            Time.timeScale = 0f;
        }

        void OnDisable()
        {
            Time.timeScale = 1f;
        }

        #endregion
    }
}
