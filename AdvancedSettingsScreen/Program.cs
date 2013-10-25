using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Presentation;

namespace AdvancedSettingsScreen
{
    public class Program
    {
        /// <summary>
        /// 主要進入函式
        /// </summary>
        [FISCA.MainMethod()]
        public static void Main()
        {
            #region 班級管理
            ClassEditor vClassEditor = new ClassEditor();
            ClassPackageDataAccess vClassDataAccess = new ClassPackageDataAccess();
            winConfiguration<ClassPackage> configClass = new winConfiguration<ClassPackage>(vClassDataAccess, vClassEditor);

            MotherForm.RibbonBarItems["學務作業", "範例"]["進階設定畫面"].Size = RibbonBarButton.MenuButtonSize.Medium;
            MotherForm.RibbonBarItems["學務作業", "範例"]["進階設定畫面"].Click += delegate
            {
                vClassEditor.Prepare();
                configClass.ShowDialog();
            };
            #endregion



        }
    }
}
