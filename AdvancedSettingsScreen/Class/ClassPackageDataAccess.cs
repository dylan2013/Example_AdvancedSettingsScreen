using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using System.Data;
using FISCA.Data;

namespace AdvancedSettingsScreen
{
    /// <summary>
    /// 班級資料存取
    /// </summary>
    public class ClassPackageDataAccess : IConfigurationDataAccess<ClassPackage>
    {
        private AccessHelper mAccessHelper;
        private QueryHelper mQueryHelper;

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public ClassPackageDataAccess()
        {
            mAccessHelper = new AccessHelper();
            mQueryHelper = new QueryHelper();
        }

        #region IConfigurationDataAccess<TeacherPackage> 成員

        /// <summary>
        /// 顯示名稱
        /// </summary>
        public string DisplayName
        {
            get { return "班級管理"; }
        }

        /// <summary>
        /// 其他指令
        /// </summary>
        public List<ICommand> ExtraCommands
        {
            get
            {
                List<ICommand> Commands = new List<ICommand>();

                Commands.Add(new ExportClassCommand());

                return Commands;
            }
        }
        #endregion


        public List<string> SelectKeys()
        {
            throw new System.NotImplementedException();
        }

        public List<string> Search(string SearchText)
        {
            throw new System.NotImplementedException();
        }

        public string Insert(string NewKey, string CopyKey)
        {
            throw new System.NotImplementedException();
        }

        public string Update(string Key, string NewKey)
        {
            throw new System.NotImplementedException();
        }

        public string Delete(string Key)
        {
            throw new System.NotImplementedException();
        }

        public ClassPackage Select(string Key)
        {
            throw new System.NotImplementedException();
        }

        public string Save(ClassPackage Value)
        {
            throw new System.NotImplementedException();
        }
    }
}