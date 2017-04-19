using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace MyClassLibarary.BackEnd.ApiConnection
{
    [DataContract]
    public class UserEntity:JsonEntity
    {
        private UserEntity _user;

        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string EmailId { get; set; }

        public override void GetEntity(object GetingObject)
        {
            _user = GetingObject as UserEntity;
            _thisObject = _user;
        }
    }
}
