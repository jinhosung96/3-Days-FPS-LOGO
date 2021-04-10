using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JHS
{    
    public class PlayerHPText : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("접두사")] string m_prefix;
        [SerializeField, LabelName("접미사")] string m_suffix;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            EventManager.Instance.AddListener("플레이어 체력 갱신", RefreshUIElement);
        }

        void OnEnable()
        {
            RefreshUIElement();
        }

        #endregion

        #region 외부 API

        public void RefreshUIElement()
        {
            GetComponent<Text>().text = $"{m_prefix}\n{PlayerSystem.Instance.PlayerHPController.CurrentHP} / {PlayerSystem.Instance.PlayerHPController.MaxHP}{m_suffix}";
        }

        #endregion
    }
}
