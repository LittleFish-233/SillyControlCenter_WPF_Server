using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SillyControlCenter_WPF_Server.daima
{
    public class Mianban
    {
        /// <summary>
        /// PC设备列表
        /// </summary>
        public List<Shuju_Shebei_PC> shuju_Shebei_PCs = new List<Shuju_Shebei_PC>();
        /// <summary>
        /// 安卓设备列表
        /// </summary>
        public List<Shuju_Shebei_AD> shuju_Shebei_ADs = new List<Shuju_Shebei_AD>();

        /// <summary>
        /// 服务器配置
        /// </summary>
        public Peizhi peizhi = new Peizhi();

        public Mianban()
        {
            peizhi.Duqu_jiben();
        }
        /// <summary>
        /// 检查无响应设备并移除
        /// </summary>
        public void Check()
        {
            try
            {
                for(int i=0;i<shuju_Shebei_ADs.Count;i++)
                {
                    shuju_Shebei_ADs[i].Jishu();
                    if(shuju_Shebei_ADs[i].Getjishu()>5)
                    {
                        shuju_Shebei_ADs.RemoveAt(i);
                    }
                }
                for (int i = 0; i < shuju_Shebei_PCs.Count; i++)
                {
                    shuju_Shebei_PCs[i].Jishu();
                    if (shuju_Shebei_PCs[i].Getjishu() > 5)
                    {
                        shuju_Shebei_PCs.RemoveAt(i);
                    }
                }
            }
            catch(Exception exc)
            {

            }
        }

        /// <summary>
        /// 建立UDP服务器监听 尝试异步使用
        /// </summary>
        public void Udp_jianting()
        {
            UdpClient udpclient = new UdpClient(22333);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 22333);
            try
            {
                while (true)
                {
                    //接收信息
                    byte[] bytes = udpclient.Receive(ref ipendpoint);
                    string strIP = "信息来自" + ipendpoint.Address.ToString();
                    string strInfo = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                    //解析信息
                    Gengxin(strInfo);

                    //序列化信息
                    Shuju_chuang shuju_Chuang = new Shuju_chuang();
                    //PC数据
                    shuju_Chuang.shuju_Shebei_PCs = shuju_Shebei_PCs;
                    //AD数据
                    shuju_Chuang.shuju_Shebei_ADs = shuju_Shebei_ADs;
                    //控制端本身数据
                    shuju_Chuang.Kongzhi = peizhi.Shuju;

                    string jieguo = "";
                    using (TextWriter file = new StringWriter())
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, shuju_Chuang);
                        jieguo = file.ToString();
                    }

                    //回调信息
                    bytes = System.Text.Encoding.UTF8.GetBytes(jieguo);
                    IPEndPoint ipendpoint_ = new IPEndPoint(ipendpoint.Address, 22334);
                    udpclient.Send(bytes,bytes.Length, ipendpoint_);
                }
            }
            catch (Exception e)
            {

            }

        }

        public void Gengxin(string json_str)
        {
            
            var json = (JObject)JsonConvert.DeserializeObject(json_str);
            try
            {
                switch (int.Parse(json["Shebei_shibie"].ToString()))
                {
                    case 0:

                        //检查是否有相同的类
                        foreach (var item in shuju_Shebei_PCs)
                        {
                            if (item.Weiyi_shibie == json["Weiyi_shibie"].ToString())
                            {
                                using (TextReader str = new StringReader(json_str))
                                {
                                    JsonSerializer serializer = new JsonSerializer();
                                    item.Copy((Shuju_Shebei_PC)serializer.Deserialize(str, typeof(Shuju_Shebei_PC)));
                                }
                                return;
                            }
                        }
                        //添加
                        using (TextReader str = new StringReader(json_str))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            shuju_Shebei_PCs.Add((Shuju_Shebei_PC)serializer.Deserialize(str, typeof(Shuju_Shebei_PC)));
                        }
                        break;
                    case 1:
                        //检查是否有相同的类
                        foreach (var item in shuju_Shebei_ADs)
                        {
                            if (item.Weiyi_shibie == json["Weiyi_shibie"].ToString())
                            {
                                using (TextReader str = new StringReader(json_str))
                                {
                                    JsonSerializer serializer = new JsonSerializer();
                                    item.Copy((Shuju_Shebei_AD)serializer.Deserialize(str, typeof(Shuju_Shebei_AD)));
                                }
                                return;
                            }
                        }
                        //添加
                        using (TextReader str = new StringReader(json_str))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            shuju_Shebei_ADs.Add((Shuju_Shebei_AD)serializer.Deserialize(str, typeof(Shuju_Shebei_AD)));
                        }
                        break;
                    case 3:
                        using (TextReader str = new StringReader(json_str))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            Mingling_Fu mingling = (Mingling_Fu)serializer.Deserialize(str, typeof(Mingling_Fu));
                            Mingling_(mingling);
                        }
                        break;
                }
            }
            catch (Exception exc)
            {

            }
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="mingling_Fu"></param>
        public void Mingling_(Mingling_Fu mingling_Fu)
        {
            switch(mingling_Fu.Mingling)
            {
                case "修改主机名":
                    peizhi.Shuju.Zhujiming = mingling_Fu.Canshu;
                    peizhi.Baocun_jiben();
                    break;
            }
        }
    }
}
