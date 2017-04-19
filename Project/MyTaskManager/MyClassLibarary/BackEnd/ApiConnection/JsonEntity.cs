using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Net;
using Newtonsoft.Json;

namespace MyClassLibarary.BackEnd.ApiConnection
{
    [DataContract]
    public abstract class JsonEntity
    {
        [DataMember]
        protected DataContractJsonSerializer _json;
        protected FileStream _streamWriter;
        [DataMember]
        protected object _thisObject;
        [DataMember]
        protected Type _type;

        public object GetObject()
        {
            using (FileStream fs = new FileStream("tmp.json", FileMode.OpenOrCreate))
            {
                _json.WriteObject(fs, _thisObject);
            }

            using (FileStream fs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Object newObject = _json.ReadObject(fs);
                _thisObject = newObject;
            }
            return _thisObject;
        }
        public void SetJson(DataContractJsonSerializer json)
        {
            _json = json;
        }

        public void SerializeObject()
        {
            using (FileStream fs = new FileStream("tmp.json", FileMode.OpenOrCreate))
            {
                _json = new DataContractJsonSerializer(_type);
            }
        }
        public abstract void GetEntity(object GetingObject);
        async public void SendJson(string url,string method)
        {
            string json = JsonConvert.SerializeObject(_thisObject);
            var body = Encoding.UTF8.GetBytes(json);
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = method;
            request.ContentType = "application/json";

            using (Stream stream = await request.GetRequestStreamAsync())
            {
                stream.Write(body, 0, body.Length);
            }

            using (WebResponse response = await request.GetResponseAsync())
            {
                response.Dispose();
            }
        }

    }
}
