using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class ShootController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("Flash 효과")] ParticleSystem m_flash;
        
        [SerializeField, LabelName("Impact 효과")] GameObject m_impact;
        [SerializeField, LabelName("Impact 회전 오프셋")] Vector3 m_impactRotationOffset;
        [SerializeField, LabelName("발사 데미지")] float m_shootDamage;
        [SerializeField, LabelName("초당 발사 횟수")] float m_shootPerSecond;
        [SerializeField, LabelName("발사음")] AudioClip m_shootEffectSound;

        bool m_pause;

        #endregion

        #region 유니티 생명주기

        void Update()
        {
            if (PlayerSystem.Instance.Pause) { StopAllCoroutines(); return; }

            if (Input.GetButtonDown("Shoot"))
            {
                PlayerSystem.Instance.Animator.SetBool("IsShoot", true);

                StartCoroutine(Co_Shoot());
            }
            if(Input.GetButtonUp("Shoot"))
            {
                PlayerSystem.Instance.Animator.SetBool("IsShoot", false);

                StopAllCoroutines();
            }
        }

        #endregion

        #region 구현부

        IEnumerator Co_Shoot()
        {
            while (true)
            {
                SoundManager.Instance.PlaySoundEffect(m_shootEffectSound, 3f);

                m_flash.Play();

                Camera currentCamera = CameraSystem.Instance.Isfps ? CameraSystem.Instance.FPSCamera : CameraSystem.Instance.TPSCamera;

                RaycastHit hit;
                Ray ray = currentCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject impact = PoolManager.Instance.PopObject(m_impact);
                    impact.transform.position = hit.point;
                    impact.transform.LookAt(hit.point + hit.normal);
                    impact.transform.rotation *= Quaternion.Euler(m_impactRotationOffset);
                    impact.transform.parent = FolderSystem.Instance.ProjectileFolder;

                    EnemyHPController enemyHPController = hit.transform.GetComponent<EnemyHPController>();
                    if(enemyHPController != null) enemyHPController.TakeDamage(m_shootDamage);
                }

                yield return new WaitForSeconds(1 / m_shootPerSecond);
            }
        }

        #endregion
    }
}
