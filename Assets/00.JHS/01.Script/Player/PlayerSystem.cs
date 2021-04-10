using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{    
    public class PlayerSystem : SceneObject<PlayerSystem>
    {
        #region 변수

        [OdinSerialize, LabelText("플레이어")] GameObject m_playerGO;
        Transform m_playerSpineTr;

        Rigidbody m_rigidbody;
        CapsuleCollider m_capsuleCollider;
        Animator m_animator;

        MoveController m_moveController;
        JumpController m_jumpController;
        AimController m_aimControllter;
        ViewController m_viewController;
        PlayerHPController m_playerHPController;

        RunState m_runState;
        WalkState m_walkState;
        CrouchState m_crouchState;

        bool m_pause;

        #endregion

        #region 공개 속성

        public GameObject PlayerGO => m_playerGO;
        public Transform PlayerTr => m_playerGO.transform;
        public Transform PlayerSpineTr
        {
            get
            {
                if (m_playerSpineTr == null) m_playerSpineTr = m_animator.GetBoneTransform(HumanBodyBones.Spine);

                return m_playerSpineTr;
            }
        }

        public Rigidbody Rigidbody
        {
            get
            {
                if (m_rigidbody == null) m_rigidbody = m_playerGO.GetComponent<Rigidbody>();

                return m_rigidbody;
            }
        }
        public CapsuleCollider CapsuleCollider
        {
            get
            {
                if (m_capsuleCollider == null) m_capsuleCollider = m_playerGO.GetComponent<CapsuleCollider>();

                return m_capsuleCollider;
            }
        }
        public Animator Animator
        {
            get
            {
                if (m_animator == null) m_animator = m_playerGO.GetComponent<Animator>();

                return m_animator;
            }
        }

        public MoveController MoveController
        {
            get
            {
                if (m_moveController == null) m_moveController = m_playerGO.GetComponent<MoveController>();

                return m_moveController;
            }
        }
        public JumpController JumpController
        {
            get
            {
                if (m_jumpController == null) m_jumpController = m_playerGO.GetComponent<JumpController>();

                return m_jumpController;
            }
        }
        public AimController AimController
        {
            get
            {
                if (m_aimControllter == null) m_aimControllter = m_playerGO.GetComponent<AimController>();

                return m_aimControllter;
            }
        }
        public ViewController ViewController
        {
            get
            {
                if (m_viewController == null) m_viewController = m_playerGO.GetComponent<ViewController>();

                return m_viewController;
            }
        }
        public PlayerHPController PlayerHPController
        {
            get
            {
                if (m_playerHPController == null) m_playerHPController = m_playerGO.GetComponent<PlayerHPController>();

                return m_playerHPController;
            }
        }

        public RunState RunState
        {
            get
            {
                if (m_runState == null) m_runState = m_playerGO.GetComponent<RunState>();

                return m_runState;
            }
        }
        public WalkState WalkState
        {
            get
            {
                if (m_walkState == null) m_walkState = m_playerGO.GetComponent<WalkState>();

                return m_walkState;
            }
        }
        public CrouchState CrouchState
        {
            get
            {
                if (m_crouchState == null) m_crouchState = m_playerGO.GetComponent<CrouchState>();

                return m_crouchState;
            }
        }

        public bool Pause => m_pause;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            EventManager.Instance.AddListener("게임 오버", ()=> { m_pause = true; });
            EventManager.Instance.AddListener("스테이지 클리어", () => { m_pause = true; });
        }

        #endregion
    }
}
