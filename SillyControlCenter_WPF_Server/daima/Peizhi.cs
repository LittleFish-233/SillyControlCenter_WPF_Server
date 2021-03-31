using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SillyControlCenter_WPF_Server.daima
{
    public class Peizhi
    {
        /// <summary>
        /// 版本
        /// </summary>
        public static int banben = 1;

        /// <summary>
        /// 数据
        /// </summary>
        public Shuju_peizhi Shuju { get; set; } = new Shuju_peizhi();

        private static bool shifou_zhengzai = false;

        /// <summary>
        /// 当前类文件的根目录
        /// </summary>
        private string lujing { get { return Environment.CurrentDirectory + "\\SillyFile_Server\\"; } }

        /// <summary>
        /// 保存基本信息
        /// </summary>
        public void Baocun_jiben()
        {
            if (shifou_zhengzai == true)
            {
                return;
            }
            shifou_zhengzai = true;
            //新建文件夹
            Directory.CreateDirectory(lujing);

            //序列化数据
            //添加基本数据
            using (StreamWriter file = File.CreateText(lujing + "peizhi.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, Shuju);
            }
            shifou_zhengzai = false;
        }
        /// <summary>
        /// 读取基本信息
        /// </summary>
        /// <returns>是否成功</returns>
        public void Duqu_jiben()
        {
            try
            {
                using (StreamReader file = File.OpenText(lujing + "peizhi.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Shuju = (Shuju_peizhi)serializer.Deserialize(file, typeof(Shuju_peizhi));
                }
            }
            catch
            {
                Baocun_jiben();
            }
        }
    }

    /// <summary>
    /// 配置信息
    /// </summary>
    public class Shuju_peizhi
    {
        private string zhujiming = "";
        /// <summary>
        /// 主机名称
        /// </summary>
        public string Zhujiming
        {
            get
            {
                if (string.IsNullOrEmpty(zhujiming) == true)
                {
                    zhujiming = System.Environment.GetEnvironmentVariable("ComputerName");
                }
                return zhujiming;
            }
            set
            {
                zhujiming = value;
            }
        }
        private string weiyi_shibie = "";
        /// <summary>
        /// 唯一识别号 16位数字
        /// </summary>
        ///        

        public string Weiyi_shibie
        {
            get
            {
                if (string.IsNullOrEmpty(weiyi_shibie) == true)
                {
                    Random rd = new Random();

                    weiyi_shibie = rd.Next(10000000, 99999999).ToString() + rd.Next(10000000, 99999999).ToString();
                }
                return weiyi_shibie;
            }
            set
            {
                weiyi_shibie = value;
            }
        }
    }
}
