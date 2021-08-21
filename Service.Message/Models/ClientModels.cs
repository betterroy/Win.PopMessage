using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Message.Models
{
    public class ClientModels
    {

        /// <summary>
        /// 推送内容
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 是否已推送
        /// </summary>
        public bool isPush { get; set; }

    }
}
