using System.Collections.Generic;

namespace AdvancedSettingsScreen
{
    /// <summary>
    /// 班級及班級不排課時段（2013/3/20，檢查OK）
    /// </summary>
    public class ClassPackage
    {
        /// <summary>
        /// 班級
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 班級不排課時段
        /// </summary>
        public List<string> ClassBusys { get; set; }
    }
}