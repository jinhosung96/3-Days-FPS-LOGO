using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 사운드 제어 기능 정의 <para></para>
    /// 
    /// ----- 공개 메소드 ----- <para></para>
    /// PlaySoundBGM(AudioClip _clip) : 해당 오디오 클립으로 BGM 재생 <para></para>
    /// StopSoundBGM() : BGM 재생 중지 <para></para>
    /// PlaySoundEffect(AudioClip _clip) : 해당 오디오 클립으로 효과음 재생 <para></para>
    /// 
    /// ----- 주의 사항 ----- <para></para>
    /// 1. Awake()문 오버라이드시 base.Awake()를 필히 호출해야한다. <para></para>
    ///
    /// </summary>
     #endregion
    public class SoundManager : SceneObject<SoundManager>
    {
        #region 변수

        [SerializeField, LabelName("배경음 오디오 소스")] AudioSource m_audioSourceForBgm;
        [SerializeField, LabelName("효과음 오디오 소스")] AudioSource m_audioSourceForEffects;
        [SerializeField, LabelName("효과음 볼륨 크기")] float m_bgmVolume;
        [SerializeField, LabelName("효과음 볼륨 크기")] float m_effectsVolume;

        #endregion

        #region 외부 API

        public void PlaySoundBGM(AudioClip _clip, float _magnification = 1)
        {
            m_audioSourceForBgm.clip = _clip;
            m_audioSourceForBgm.volume = Mathf.Clamp01(m_bgmVolume * _magnification);
            m_audioSourceForBgm.Play();
        }

        public void StopSoundBGM()
        {
            m_audioSourceForBgm.Stop();
        }

        public void PlaySoundEffect(AudioClip _clip, float _magnification = 1)
        {
            m_audioSourceForEffects.PlayOneShot(_clip, m_effectsVolume * _magnification);
        }

        #endregion
    } 
}
