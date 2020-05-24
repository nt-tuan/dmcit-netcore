using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels
{
    public class ResponseModel
    {
        static string ERROR_TYPE = "error";
        static string WARNING_TYPE = "warning";
        static string INFO_TYPE = "info";
        public ICollection<MessageModel> messages { get; set; } = new List<MessageModel>();
        public string type { get; set; }
        public dynamic data { get; set; }
        public ResponseModel()
        {

        }

        public ResponseModel(ICollection<string> mes)
        {
            if (mes == null)
                return;
            messages = mes.Select(u => MessageModel.CreateError(u)).ToList();
        }

        public ResponseModel(string mes)
        {
            messages.Add(MessageModel.CreateError(mes));
        }

        public ResponseModel(string mes, dynamic re) : this(mes)
        {
            data = re;
        }

        public ResponseModel(ICollection<string> messages, dynamic re) : this(messages)
        {
            data = re;
        }

        public ResponseModel(dynamic re) : this()
        {
            data = re;
        }

        public static ResponseModel CreateWarning(string mes)
        {
            var r = new ResponseModel(mes);
            r.type = WARNING_TYPE;
            return r;
        }

        public static ResponseModel CreateError(string mes)
        {
            var r = new ResponseModel(mes);
            r.type = ERROR_TYPE;
            return r;
        }

        public static ResponseModel CreateError(ICollection<string> mes)
        {
            var r = new ResponseModel(mes);
            r.type = ERROR_TYPE;
            return r;
        }

        public static ResponseModel CreateInfo(string mes)
        {
            var r = new ResponseModel();
            r.type = INFO_TYPE;
            return r;
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
