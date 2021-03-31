using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SillyControlCenter_WPF_Server.daima
{
    public class Shuju_Shebei_PC
    {
        /// <summary>
        /// 主机名称
        /// </summary>
        public string Mingchen { get; set; }
        /// <summary>
        /// 唯一识别号 16位数字
        /// </summary>
        ///        

        public string Weiyi_shibie { get; set; }
        /// <summary>
        /// 设备识别码 0 PC 1安卓 2 单片机
        /// </summary>
        public int Shebei_shibie { get; set; } = 0;

        /// <summary>
        /// CPU信息
        /// </summary>
        public string Cpu_info { get; set; }
        /// <summary>
        /// GPU信息
        /// </summary>
        public string Gpu_info { get; set; }
        /// <summary>
        /// RAM信息
        /// </summary>
        public string Ram_info { get; set; }
        /// <summary>
        /// 系统信息
        /// </summary>
        public string Sys_info { get; set; }
        /// <summary>
        /// CPU占用率
        /// </summary>
        public float Cpu_use { get; set; }
        /// <summary>
        /// GPU占用率
        /// </summary>
        public float Gpu_use { get; set; }
        /// <summary>
        /// RAM占用率
        /// </summary>
        public float Ram_use { get; set; }
        /// <summary>
        /// HDD占用率
        /// </summary>
        public float Hdd_use { get; set; }
        /// <summary>
        /// 系统运行时间
        /// </summary>
        public string Sys_time { get; set; }
        /// <summary>
        /// CPU温度
        /// </summary>
        public float Cpu_wendu { get; set; }
        /// <summary>
        /// GPU温度
        /// </summary>
        public float Gpu_wendu { get; set; }



        public void Copy(Shuju_Shebei_PC shuju_Shebei_PC)
        {
            Mingchen = shuju_Shebei_PC.Mingchen;
            Weiyi_shibie = shuju_Shebei_PC.Weiyi_shibie;
            Shebei_shibie = shuju_Shebei_PC.Shebei_shibie;
            Cpu_info = shuju_Shebei_PC.Cpu_info;
            Cpu_use = shuju_Shebei_PC.Cpu_use;
            Cpu_wendu = shuju_Shebei_PC.Cpu_wendu;
            Gpu_info = shuju_Shebei_PC.Gpu_info;
            Gpu_use = shuju_Shebei_PC.Gpu_use;
            Gpu_wendu = shuju_Shebei_PC.Gpu_wendu;
            Ram_info = shuju_Shebei_PC.Ram_info;
            Ram_use = shuju_Shebei_PC.Ram_use;
            Sys_info = shuju_Shebei_PC.Sys_info;
            Sys_time = shuju_Shebei_PC.Sys_time;
            Hdd_use = shuju_Shebei_PC.Hdd_use;

            Clear();
        }
        private int jishu = 0;
        /// <summary>
        /// 增加时间计数 到指定值认为设备无响应
        /// </summary>
        public void Jishu()
        {
            jishu++;
        }
        /// <summary>
        /// 清空计数 在设备数据被更新时调用
        /// </summary>
        public void Clear()
        {
            jishu = 0;
        }
        /// <summary>
        /// 获取计数
        /// </summary>
        /// <returns></returns>
        public int Getjishu()
        {
            return jishu;
        }
    }
    public class Shuju_Shebei_AD
    {
        /// <summary>
        /// 主机名称
        /// </summary>
        public string Mingchen { get; set; }
        /// <summary>
        /// 唯一识别号 16位数字
        /// </summary>
        ///        

        public string Weiyi_shibie { get; set; }
        /// <summary>
        /// 设备识别码 0 PC 1安卓 2 单片机
        /// </summary>
        public int Shebei_shibie { get; set; } = 0;
        /// <summary>
        /// 电量
        /// </summary>
        public float Dianliang { get; set; } = 0;
        /// <summary>
        /// 电池温度
        /// </summary>

        public float Dianchi_Wendu { get; set; } = 0;
        /// <summary>
        /// 内存占用
        /// </summary>
        public float Ram_use { get; set; } = 0;
        /// <summary>
        /// 储存占用
        /// </summary>
        public float Hdd_use { get; set; } = 0;

        public void Copy(Shuju_Shebei_AD shuju_Shebei_AD)
        {
            Mingchen = shuju_Shebei_AD.Mingchen;
            Weiyi_shibie = shuju_Shebei_AD.Weiyi_shibie;
            Shebei_shibie = shuju_Shebei_AD.Shebei_shibie;
            Dianliang = shuju_Shebei_AD.Dianliang;
            Dianchi_Wendu = shuju_Shebei_AD.Dianchi_Wendu;
            Ram_use = shuju_Shebei_AD.Ram_use;
            Hdd_use = shuju_Shebei_AD.Hdd_use;


            Clear();
        }
        private int jishu = 0;
        /// <summary>
        /// 增加时间计数 到指定值认为设备无响应
        /// </summary>
        public void Jishu()
        {
            jishu++;
        }
        /// <summary>
        /// 清空计数 在设备数据被更新时调用
        /// </summary>
        public void Clear()
        {
            jishu = 0;
        }
        /// <summary>
        /// 获取计数
        /// </summary>
        /// <returns></returns>
        public int Getjishu()
        {
            return jishu;
        }
    }
}

