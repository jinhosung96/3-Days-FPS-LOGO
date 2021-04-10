using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 씬 시작 시 BGM 재생 <para></para>
    /// 
    /// </summary>
     #endregion
    public class BGMPlayer : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("BGM")] AudioClip m_clip;

        #endregion

        #region 유니티 생명주기

        private void Start()
        {
            SoundManager.Instance.PlaySoundBGM(m_clip);
        }

        #endregion
    } 
}
