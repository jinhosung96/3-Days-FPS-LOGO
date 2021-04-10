using UnityEditor;
using System.IO;
using System;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 최종 수정 날짜 : 2020-10-03 <para></para>
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : ScriptTemplates에서 #TODAY# 키워드를 오늘 날짜로 자동 변환시켜주는 기능이 정의된 에디터 클래스이다. <para></para>
    ///
    /// </summary>
    #endregion
    public class TodayKeywordReplacer : UnityEditor.AssetModificationProcessor
    {
        //If there would be more than one keyword to replace, add a Dictionary

        public static void OnWillCreateAsset(string metaFilePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(metaFilePath);

            if (!fileName.EndsWith(".cs"))
                return;


            string actualFilePath = $"{Path.GetDirectoryName(metaFilePath)}\\{fileName}";

            string content = File.ReadAllText(actualFilePath);

            string newcontent = content.Replace("#TODAY#", DateTime.Now.ToString("yyyy-MM-dd"));

            if (content != newcontent)
            {
                File.WriteAllText(actualFilePath, newcontent);
                AssetDatabase.Refresh();
            }
        }
    }
}
