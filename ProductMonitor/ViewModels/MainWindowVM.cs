using ProductMonitor.Models;
using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProductMonitor.ViewModels
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        /// <summary>
        /// 视图模型构造函数
        /// </summary>
        public MainWindowVM()
        {
            #region 初始化环境监控数据
            EnvironmentList = new List<EnvironmentModel>();

            EnvironmentList.Add(new EnvironmentModel { EnItemName = "光照(Lux)", EnItemValue = 123 });
            EnvironmentList.Add(new EnvironmentModel { EnItemName = "噪音(db)", EnItemValue = 55 });
            EnvironmentList.Add(new EnvironmentModel { EnItemName = "温度(℃)", EnItemValue = 80 });
            EnvironmentList.Add(new EnvironmentModel { EnItemName = "湿度(%)", EnItemValue = 43 });
            EnvironmentList.Add(new EnvironmentModel { EnItemName = "PM2.5(m³)", EnItemValue = 20 });
            EnvironmentList.Add(new EnvironmentModel { EnItemName = "硫化氢(PPM)", EnItemValue = 15 });
            EnvironmentList.Add(new EnvironmentModel { EnItemName = "氮气(PPM)", EnItemValue = 18 });
            #endregion
        }

        private UserControl _MonitorUC;

        public UserControl MonitorUC
        {
            get
            {
                if (_MonitorUC == null) { _MonitorUC = new MonitorUC(); }
                return _MonitorUC;
            }
            set
            {
                _MonitorUC = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MonitorUC"));
                }
            }
        }
        #region 环境日期
        /// <summary>
        /// 时间 小时：分钟
        /// </summary>
        public string TimeStr { get { return DateTime.Now.ToString("HH:mm"); } }

        /// <summary>
        /// 日期 年-月-日
        /// </summary>
        public string DateStr { get { return DateTime.Now.ToString("yyyy-MM-dd"); } }

        /// <summary>
        /// 星期
        /// </summary>
        public string WeekStr
        {
            get
            {
                int index = (int)DateTime.Now.DayOfWeek;
                string[] week = new string[7] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                return week[index];
            }

        }
        #endregion

        #region 计数
        /// <summary>
        /// 机台总数
        /// </summary>
        private string _MachineCount="0298";

        public string MachineCount
        {
            get { return _MachineCount; }
            set 
            {   
                _MachineCount = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
                }
            }
        }

        /// <summary>
        /// 生产计数
        /// </summary>
        private string _ProductCount="16034";

        public string ProductCount
        {
            get { return _ProductCount; }
            set 
            {
                _ProductCount = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductCount"));
                }
            }
        }
        
        /// <summary>
        /// 不良计数
        /// </summary>
        private string _BadCount="223";

        public string BadCount
        {
            get { return _BadCount; }
            set 
            {
                _BadCount = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BadCount"));
                }
            }
        }
        #endregion

        #region 环境监控数据
        /// <summary>
        /// 环境监控数据
        /// </summary>
        private List<EnvironmentModel> _EnvironmentList;

        public List<EnvironmentModel> EnvironmentList
        {
            get { return _EnvironmentList; }
            set { 
                _EnvironmentList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EnvironmentList"));
                }    
            }
        }

        #endregion

    }
}
