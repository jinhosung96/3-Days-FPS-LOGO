namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 씬 전환 방법 정의 인터페이스 <para></para>
    /// 
    /// ----- 공개 메소드 ----- <para></para>
    /// ChangeScene(string _nextSceneName) : 인자값으로 넘겨진 문자열을 이름으로 가진 씬으로 효과와 함께 전환 <para></para>
    /// 
    /// </summary>
     #endregion
    public interface ISceneChangeType
    {
        #region 외부 API

        void ChangeScene(string _nextSceneName);

        #endregion
    }
}