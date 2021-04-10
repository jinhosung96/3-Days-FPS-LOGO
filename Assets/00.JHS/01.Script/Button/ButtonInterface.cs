namespace JHS
{    
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 본 인터페이스를 상속받는 객체는 ButtonController의 제어를 받는다. <para></para>
    ///
    /// </summary>
    #endregion
    public interface IButtonClick
    {
        void OnClick();
    }

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 본 인터페이스를 상속받는 객체는 ButtonController의 제어를 받는다. <para></para>
    ///
    /// </summary>
    #endregion
    public interface IButtonPointerDown
    {
        void OnPointerDown();
    }

    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : 본 인터페이스를 상속받는 객체는 ButtonController의 제어를 받는다. <para></para>
    ///
    /// </summary>
    #endregion
    public interface IButtonPointerUp
    {
        void OnPointerUp();
    }
}
