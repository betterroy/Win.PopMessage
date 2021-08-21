using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Message.Models
{
    /// <summary>
    /// 自定义数据包
    /// </summary>
    public class DataPackage
    {
        /// <summary>
        /// 功能码
        /// </summary>
        public int FCode { get; set; } = -1;
        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Datas { get; set; }
    }
}
