using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsWebApp4.Global
{
    public class ActionRes
    {
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public string tips { get; set; }

        public ActionRes(int code = 1, string msg = "", object data = null)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
            this.tips = "";
        }
        public static ActionRes Success(object data)
        {
            return new ActionRes(1, "", data);
        }
        public static ActionRes Fail(string msg)
        {
            return new ActionRes(-1, msg, null);
        }
        public static ActionRes Result(int code = 1, string msg = "", object data = null)
        {
            return new ActionRes(code, msg, data);
        }
    }
}