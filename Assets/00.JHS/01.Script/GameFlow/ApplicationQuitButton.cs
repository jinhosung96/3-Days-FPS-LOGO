using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;

namespace JHS
{    
    public class ApplicationQuitButton : MonoBehaviour, IButtonClick
    {
        #region 콜백 함수

        public void OnClick()
        {
            Application.Quit();
        }

        #endregion
    }
}
