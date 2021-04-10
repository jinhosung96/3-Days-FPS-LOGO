using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class HPController : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("최대 체력")] float m_maxHealthPoint;

        float m_currentHealthPoint;

        #endregion

        #region 공개 속성

        public float MaxHP => m_maxHealthPoint;

        public float CurrentHP
        {
            get => m_currentHealthPoint;
            set
            { 
                if (m_currentHealthPoint > value && m_currentHealthPoint <= 0) return;      // 이미 체력이 0 이하인데 데미지를 입을 시
                if (m_currentHealthPoint > value && value > 0) OnTakeDamage();              // 데미지를 입었지만 죽지 않았을 시
                m_currentHealthPoint = Mathf.Clamp(value, 0, MaxHP); RefreshUIElement();    // HP 변동치 적용
                if (m_currentHealthPoint <= 0) OnDeath();                                   // 체력 0 이하 시 사망
            }
        }

        #endregion

        #region 외부 API

        public virtual void TakeDamage(float _damage)
        {
            CurrentHP -= _damage;
        }

        #endregion

        #region 유니티 생명주기

        private void OnEnable()
        {
            CurrentHP = MaxHP;
        }

        #endregion

        #region 구현부

        protected virtual void OnTakeDamage() { }

        protected virtual void RefreshUIElement() { }

        protected virtual void OnDeath() { }

        #endregion
    }
}
