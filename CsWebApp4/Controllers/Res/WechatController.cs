using CsWebApp4.Global;
using CsWebApp4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CsWebApp4.Controllers.Res
{
    public class WechatController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        //[Route("api/{controller}/{action}/{id}")]
        [HttpGet]
        [Route("api/Wechat/Index")]
        public ActionRes Index()
        {
            var system_User = db.System_User.ToList();
            if (system_User == null)
            {
                return ActionRes.Fail("");
            }

            return ActionRes.Success("11");
        }

        [HttpGet]
        [Route("api/Wechat/GetSystem_User/{id}")]
        public ActionRes GetSystem_User()
        {
            var system_User = db.System_User.ToList();
            if (system_User == null)
            {
                return ActionRes.Fail("");
            }

            return ActionRes.Success(system_User);
        }

        [HttpGet]
        [Route("api/Wechat/GetOpenId")]
        public ActionRes GetOpenId()
        {
            HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            WeChatInfo wechatInfo = Helper.GetOpenId(context.Request["js_code"]);
            System_User systemUser = db.System_User.Where(user => user.WxOpenId == wechatInfo.openid).FirstOrDefault();
            if (systemUser != null)
                return ActionRes.Success(systemUser);
            else
                return ActionRes.Success(wechatInfo);
        }
    }
}
