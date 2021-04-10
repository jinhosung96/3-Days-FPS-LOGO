using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    [Serializable]
    public class SpawnEnemy
    {
        [SerializeField, LabelName("스폰 객체")] GameObject m_gameObject;
        [SerializeField, LabelName("스폰 상대 확률")] float m_probability;

        public GameObject GameObject => m_gameObject; 
        public float Probability => m_probability;
    }

    public class SpawnController : SerializedMonoBehaviour
    {
        #region 변수

        [SerializeField] SpawnEnemy[] m_spawnEnemy;

        float m_sum = 0;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            for (int i = 0; i < m_spawnEnemy.Length; i++)
            {
                m_sum += m_spawnEnemy[i].Probability;
            }

            EventManager.Instance.AddListener("부하 소환", Spawn);
        }

        #endregion

        #region 구현부

        void Spawn()
        {            
            float percentage = UnityEngine.Random.Range(0, m_sum);

            float temp = 0;
            for (int i = 0; i < m_spawnEnemy.Length; i++)
            {
                if (percentage < temp + m_spawnEnemy[i].Probability)
                {
                    GameObject enemy = PoolManager.Instance.PopObject(m_spawnEnemy[i].GameObject);
                    enemy.transform.position = transform.position;
                    enemy.transform.LookAt(PlayerSystem.Instance.PlayerTr.position);
                    enemy.transform.parent = FolderSystem.Instance.EnemyFolder;

                    return;
                }

                temp += m_spawnEnemy[i].Probability;
            }
        }

        #endregion
    }
}
