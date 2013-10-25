using System;
using System.Collections.Generic;
using System.Data;
using FISCA.Data;
using FISCA.Presentation.Controls;

namespace AdvancedSettingsScreen
{
    /// <summary>
    /// 根據名稱產生新記錄的表單
    /// </summary>
    public partial class ClassCreatorForm : FISCA.Presentation.Controls.BaseForm
    {
        /// <summary>
        /// 建構式，傳入NameCreatorForm所需要的資料存取物件
        /// </summary>
        /// <param name="vDataAccess">資料存取物件</param>
        public ClassCreatorForm()
        {
            InitializeComponent();         
        }        
    }
}