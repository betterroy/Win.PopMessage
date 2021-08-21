using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Message.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Message.Controllers
{
    [ApiController]
    public class PushMessageController : ControllerBase
    {
        private Utility.Logger logger = new Utility.Logger(typeof(PushMessageController));

        [HttpGet]
        [Route("api/[controller]/PushStr")]
        public string PushStr(string msg)
        {
            try
            {
                ClientDataHandle.msg = msg;
                return Newtonsoft.Json.JsonConvert.SerializeObject(new ResponseData
                {
                    Code = 200,
                    ReceiveMessage=msg,
                    Message = "添加成功"
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return Newtonsoft.Json.JsonConvert.SerializeObject(new ResponseData
                {
                    Code = 400,
                    Message = ex.Message
                });
            }
        }

        public class ResponseData 
        {
            public int Code { get; set; }
            public string ReceiveMessage { get; set; }
            public string Message { get; set; }
        }

    }
}
