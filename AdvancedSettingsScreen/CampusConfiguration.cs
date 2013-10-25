using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using FISCA.Presentation.Controls;
using System.ComponentModel;

namespace AdvancedSettingsScreen
{
    /// <summary>
    /// 通用型的新增、更新、刪除及匯入匯出表單
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class CampusConfiguration<T> : ConfigurationItem
    {
        private IConfigurationDataAccess<T> mDataAccess;
        private IContentEditor<T> mEditor;
        private string mCurrentSelectedName;
        private int mCurrentSelectedRow;
        private bool mIsSimpleSwitch = false;

        /// <summary>
        /// 建構式，傳入DataAccess物件
        /// </summary>
        /// <param name="vEditor"></param>
        /// <param name="vDataAccess"></param>
        public CampusConfiguration(IConfigurationDataAccess<T> vDataAccess, IContentEditor<T> vEditor)
        {
            InitializeComponent();

            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            mDataAccess = vDataAccess;
            mEditor = vEditor;
            this.pnlExpandable.TitleText = mDataAccess.DisplayName;
            this.Caption = mDataAccess.DisplayName;
            this.pnlEditor.Controls.Add(mEditor.Control);
            mEditor.Control.Dock = DockStyle.Fill;

            if (mDataAccess.ExtraCommands != null)
                mDataAccess.ExtraCommands.ForEach
                (x =>
                    {
                        ButtonItem ButtonItem = new ButtonItem(x.Name, x.Text);
                        ButtonItem.Click += (sender, e) =>
                        {
                            x.Execute(GetSelectedName());
                            if (x.IsChangeData)
                            {
                                mEditor.Prepare();
                                Refill();
                            }
                        };
                        btnMore.SubItems.Add(ButtonItem);
                    }
                );
        }

        /// <summary>
        /// 取得選取名稱
        /// </summary>
        /// <returns>選擇名稱</returns>
        private string GetSelectedName()
        {
            string SelectedName = string.Empty;
            if (grdNameList.SelectedRows.Count == 1)
            {
                DataGridViewRow Row = grdNameList.SelectedRows[0];

                if (Row != null)
                {
                    DataGridViewCell Cell = Row.Cells[0];

                    if (Cell != null)
                        SelectedName = "" + Cell.Value;
                }
            }

            return SelectedName;
        }

        private void SetSelectedName(string Name)
        {
            if (grdNameList.SelectedRows.Count == 1)
            {
                DataGridViewRow Row = grdNameList.SelectedRows[0];

                if (Row != null)
                {
                    DataGridViewCell Cell = Row.Cells[0];

                    Cell.Value = Name;
                }
            }
        }

        /// <summary>
        /// 重新取得資料項目名稱
        /// </summary>
        private void Refill()
        {
            string SelectedName = GetSelectedName();

            grdNameList.Rows.Clear();

            BackgroundWorker BGW = new BackgroundWorker();
            BGW.WorkerReportsProgress = true;

            List<string> Names = new List<string>();

            BGW.DoWork += delegate
            {
                Names = mDataAccess.SelectKeys();
                Names.Sort();
            };

            BGW.RunWorkerCompleted += delegate
            {
                foreach (string Name in Names)
                {
                    if (Name.Equals(SelectedName))
                        grdNameList.Rows[grdNameList.Rows.Add(Name)].Selected = true;
                    else
                        grdNameList.Rows.Add(Name);
                }
                FISCA.Presentation.MotherForm.SetStatusBarMessage("完成!!");
            };

            BGW.RunWorkerAsync();

            FISCA.Presentation.MotherForm.SetStatusBarMessage("取得時間表清單...");
        }

        /// <summary>
        /// 重新取得資料項目名稱
        /// </summary>
        private void Search()
        {
            //當內容有改變時告知使用者
            if (this.mEditor.IsDirty)
            {
                MessageBox.Show("您未儲存目前資料，請先儲存後再進行搜尋。");
                return;
            }

            string SelectedName = GetSelectedName();

            grdNameList.Rows.Clear();

            List<string> Names = mDataAccess.Search(txtSearch.Text);

            Names.Sort();

            foreach (string Name in Names)
            {
                int RowIndex = grdNameList.Rows.Add();

                grdNameList.Rows[RowIndex].SetValues(Name);

                if (Name.Equals(SelectedName))
                    grdNameList.Rows[RowIndex].Selected = true;
            }
        }

        /// <summary>
        /// 當被呼叫時填入時
        /// </summary>
        protected override void OnActive()
        {
            Refill();
        }        

        BackgroundWorker BGW = new BackgroundWorker();
        bool IsBusy = false;
        string SelectedName;

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            T SelectRecord = mDataAccess.Select(SelectedName);
            e.Result = SelectRecord;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IsBusy)
            {
                IsBusy = false;
                BGW.RunWorkerAsync();
                return;
            }

            T SelectRecord = (T)e.Result;
            mEditor.Content = SelectRecord;
            mCurrentSelectedName = SelectedName;
            mCurrentSelectedRow = grdNameList.SelectedRows[0].Index;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}