using System.Web.Http;

namespace Demo.Controllers
{
    [RoutePrefix("api/Json")]
    public class JsonController : ApiController
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Serialize")]
        public dynamic Serialize()
        {
            var viewModel = new ViewModel()
            {
                ID = 1,
                Name = "Address",
                Address = "India"
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(viewModel);
        }

        /// <summary>
        /// 反序列化（已知key反序列化）
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Deserialize")]
        public dynamic Deserialize()
        {
            var str = "{\"ID\":1,\"Name\":\"Manas\",\"Address\":\"India\"}";
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ViewModel>(str);
        }

        /// <summary>
        /// 反序列化（未知key反序列化）
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Deserialize2")]
        public dynamic Deserialize2()
        {
            var str = "{\"ID\":1,\"Name\":\"Manas\",\"Address\":\"India\"}";
            var json = new System.Collections.Generic.Dictionary<string, string>();

            // 循环获取键值
            foreach (var item in Newtonsoft.Json.Linq.JObject.Parse(str))
            {
                json.Add(item.Key, System.Convert.ToString(item.Value));
            }

            return json;
        }
    }

    /// <summary>
    /// ViewModel视图模型
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
    }
}