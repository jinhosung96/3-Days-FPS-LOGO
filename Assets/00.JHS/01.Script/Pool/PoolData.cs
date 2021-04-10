using System;
using UnityEngine;

namespace JHS
{
    #region TargetObj

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 풀을 초기화에 사용될 객체에 대한 정보를 가지고 있는 스크립터블 오브젝트 <para></para>
    /// 
    /// ----- 공개 속성 ----- <para></para>
    /// Obj : 풀 초기화에 사용될 프리팹 <para></para>
    /// PoolSize : 생성될 풀의 사이즈 <para></para>
    /// 
    /// </summary>
    #endregion
    [Serializable]
    public class TargetObj
    {
        [SerializeField, LabelName("대상 오브젝트")] private GameObject m_obj;
        [SerializeField, LabelName("풀 사이즈")] private int m_poolSize;

        public GameObject Obj { get => m_obj; set => m_obj = value; }
        public int PoolSize { get => m_poolSize; set => m_poolSize = value; }
    }

    #endregion

    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-03 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 풀을 초기화에 사용될 객체에 대한 정보를 가지고 있는 스크립터블 오브젝트 <para></para>
    /// 
    /// ----- 공개 속성 ----- <para></para>
    /// TargetObjs : 풀을 초기화에 사용될 객체 정보 목록 <para></para>
    /// 
    /// </summary>
    #endregion
    public class PoolData : SingletonScriptableObject<PoolData>
    {
        #region 변수

        [SerializeField, ArrayElementLabelName("m_obj")] private TargetObj[] m_targetObjs;

        #endregion

        #region 공개 속성

        public TargetObj[] TargetObjs { get => m_targetObjs; }

        #endregion
    } 
}
