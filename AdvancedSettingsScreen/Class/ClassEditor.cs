using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FISCA.UDT;
using System.Drawing;

namespace AdvancedSettingsScreen
{
    /// <summary>
    /// 單一時間表（含時間表分段）編輯器
    /// 需要補上資料行驗證訊息。
    /// </summary>
    public partial class ClassEditor : UserControl, IContentEditor<ClassPackage>
    {
        private const int iWeekDay = 0;
        private const int iStartTime = 1;
        private const int iEndTime = 2;
        private const int iBusyDesc = 3;

        private AccessHelper mHelper = new AccessHelper();
        private TimeTableBusyEditor mTimeTableBusyEditor = null;
        private int mSelectedRowIndex;
        private bool mIsDirty = false;
        private string mEditorName = string.Empty;

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public ClassEditor()
        {
            InitializeComponent();

            ReiEver();
        }

        #region private functions
        private int ParsePeriod(string strPeriod)
        {
            if (strPeriod.Equals("午休"))
                return 0;
            else
                return K12.Data.Int.Parse(strPeriod);
        }

        private int GetWeekFlagInt(string Weekflag)
        {
            switch (Weekflag)
            {
                case "單": return 1;
                case "雙": return 2;
                case "單雙": return 3;
                default: return 3;
            }
        }

        private string GetWeekFlagStr(int WeekFlag)
        {
            switch (WeekFlag)
            {
                case 1: return "單";
                case 2: return "雙";
                case 3: return "單雙";
                default: return "單雙";
            }
        }
        
        private void ReiEver()
        {
            menuBusy.Click += (sender, e) =>
            {
                IsDirty = true;
            };

            menuBusyDesc.Click += (sender, e) =>
            {
                IsDirty = true;
            };

            menuFree.Click += (sender, e) =>
            {
                IsDirty = true;
            };

            txtGradeYear.TextChanged += (sender, e) =>
            {
                int vGradeYear;

                if (!int.TryParse(txtGradeYear.Text, out vGradeYear))
                    errGradeYear.SetError(txtGradeYear, "年級必須是數字！");
                else
                    errGradeYear.Clear();
                IsDirty = true;
            };

            textBoxX1.TextChanged += (sender, e) =>
            {
                IsDirty = true;
            };

            textBoxX2.TextChanged += (sender, e) =>
            {
                IsDirty = true;
            };
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Prepare()
        {
            mTimeTableBusyEditor = new TimeTableBusyEditor();

        }
        
        /// <summary>
        /// 是否被修改
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return mIsDirty;
            }
            set
            {
                mIsDirty = value;

                lblName.Text = mIsDirty ? mEditorName + "<font color='red'>（已修改）</font>" : mEditorName;
            }
        }

        /// <summary>
        /// 將自己傳回
        /// </summary>
        public UserControl Control { get { return this; } }

        /// <summary>
        /// 驗證表單資料是否合法
        /// </summary>
        /// <returns></returns>
        public new bool Validate()
        {
            bool pass = true;

            if (!string.IsNullOrEmpty(errGradeYear.GetError(txtGradeYear)))
                pass &= false;

            return pass;
        }
        #endregion

        #region DataGrid事件
        /// <summary>
        ///  當進入到某個Cell引發的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTimeTableSecs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 當欄位狀態改變時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTimeTableSecs_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 滑鼠右鍵用來刪除現有記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTimeTableSecs_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        /// <summary>
        /// 使用者刪除資料時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTimeTableSecs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }
        #endregion

        private void tabControlPanel5_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            tabItem4.Visible = !tabItem4.Visible;
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            tabItem4.Visible = !tabItem4.Visible;
        }

        public void SetTitle(string name)
        {
            lblName.Text = name;
        }

        public ClassPackage Content
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}