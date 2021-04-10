using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace Michsky.UI.Dark
{
    public class QualityManager : MonoBehaviour
    {
        [Header("AUDIO")]
        public AudioMixer mixer;
        [SerializeField] bool m_isInit = true;
        public SliderManager masterSlider;
        public SliderManager musicSlider;
        public SliderManager sfxSlider;

        void Start()
        {
            if (!m_isInit) return;
            mixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat(masterSlider.sliderTag + "DarkSliderValue")) * 20);
            mixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat(musicSlider.sliderTag + "DarkSliderValue")) * 20);
            mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat(sfxSlider.sliderTag + "DarkSliderValue")) * 20);
        }

        public void AnisotrpicFilteringEnable()
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }

        public void AnisotrpicFilteringDisable()
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }

        public void AntiAlisasingSet(int index)
        {
            // 0, 2, 4, 8 - Zero means off
            QualitySettings.antiAliasing = index;
        }

        public void VsyncSet(int index)
        {
            // 0, 1 - Zero means off
            QualitySettings.vSyncCount = index;
        }

        public void ShadowResolutionSet(int index)
        {
            if (index == 3)
                QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
            else if (index == 2)
                QualitySettings.shadowResolution = ShadowResolution.High;
            else if (index == 1)
                QualitySettings.shadowResolution = ShadowResolution.Medium;
            else if (index == 0)
                QualitySettings.shadowResolution = ShadowResolution.Low;
        }

        public void ShadowsSet(int index)
        {
            if (index == 0)
                QualitySettings.shadows = ShadowQuality.Disable;
            else if (index == 1)
                QualitySettings.shadows = ShadowQuality.All;
        }

        public void ShadowsCascasedSet(int index)
        {
            //0 = No, 2 = Two, 4 = Four
            QualitySettings.shadowCascades = index;
        }

        public void TextureSet(int index)
        {
            // 0 = Full, 4 = Eight Resolution
            QualitySettings.masterTextureLimit = index;
        }

        public void SoftParticleSet(int index)
        {
            if (index == 0)
                QualitySettings.softParticles = false;
            else if (index == 1)
                QualitySettings.softParticles = true;
        }

        public void ReflectionSet(int index)
        {
            if (index == 0)
                QualitySettings.realtimeReflectionProbes = false;
            else if (index == 1)
                QualitySettings.realtimeReflectionProbes = true;
        }

        public void VolumeSetMaster(float volume)
        {
            mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        }

        public void VolumeSetMusic(float volume)
        {
            mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        }

        public void VolumeSetSFX(float volume)
        {
            mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        }

        public void SetOverallQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void WindowFullscreen()
        {
            Screen.fullScreen = true;
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }

        public void WindowBorderless()
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }

        public void WindowWindowed()
        {
            Screen.fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}