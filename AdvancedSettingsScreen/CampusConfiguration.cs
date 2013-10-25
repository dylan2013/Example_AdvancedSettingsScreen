using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using FISCA.Presentation.Controls;
using System.ComponentModel;

namespace AdvancedSettingsScreen
{
    /// <summary>
    /// �q�Ϋ����s�W�B��s�B�R���ζפJ�ץX���
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
        /// �غc���A�ǤJDataAccess����
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
        /// ���o����W��
        /// </summary>
        /// <returns>��ܦW��</returns>
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
        /// ���s���o��ƶ��ئW��
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
                FISCA.Presentation.MotherForm.SetStatusBarMessage("����!!");
            };

            BGW.RunWorkerAsync();

            FISCA.Presentation.MotherForm.SetStatusBarMessage("���o�ɶ���M��...");
        }

        /// <summary>
        /// ���s���o��ƶ��ئW��
        /// </summary>
        private void Search()
        {
            //���e�����ܮɧi���ϥΪ�
            if (this.mEditor.IsDirty)
            {
                MessageBox.Show("�z���x�s�ثe��ơA�Х��x�s��A�i��j�M�C");
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
        /// ��Q�I�s�ɶ�J��
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