using System.Collections;
using UnityEngine;

namespace JHS
{    
    public class FrameSystem : MonoBehaviour
    {
        #region 변수

        [SerializeField, LabelName("타겟 프레임")] int m_targetFrameRate;
        [SerializeField, LabelName("프레임 표시 여부")] bool m_isShowFrame; 

        float deltaTime = 0.0f;

        GUIStyle style;
        Rect rect;
        float msec;
        float fps;
        float worstFps = 100f;
        string text;

        #endregion

        #region 유니티 생명주기

        void Awake()
        {
            Application.targetFrameRate = m_targetFrameRate;

            if (!m_isShowFrame) return;

            int w = Screen.width, h = Screen.height;

            rect = new Rect(0, 0, w, h * 4 / 100);

            style = new GUIStyle();
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 4 / 100;
            style.normal.textColor = Color.cyan;

            StartCoroutine("worstReset");
        }

        void Update()
        {
            if (!m_isShowFrame) return;

            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }

        void OnGUI()//소스로 GUI 표시.
        {
            if (!m_isShowFrame) return;

            msec = deltaTime * 1000.0f;
            fps = 1.0f / deltaTime;  //초당 프레임 - 1초에

            if (fps < worstFps)  //새로운 최저 fps가 나왔다면 worstFps 바꿔줌.
                worstFps = fps;
            text = msec.ToString("F1") + "ms (" + fps.ToString("F1") + ") //worst : " + worstFps.ToString("F1");
            GUI.Label(rect, text, style);
        }

        #endregion

        #region 구현부

        IEnumerator worstReset() //코루틴으로 15초 간격으로 최저 프레임 리셋해줌.
        {
            while (true)
            {
                yield return new WaitForSeconds(15f);
                worstFps = 100f;
            }
        }

        #endregion
    }
}