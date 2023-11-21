using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace webapi.Entity.Api
{
    [DataContract, Serializable]
    public class EmailEntity
        {
            [DataMember]
            public string fromName { get; set; }
            [DataMember]
            public string emailTitle { get; set; }
            [DataMember]
            public string emailBody { get; set; }
            [DataMember]
            public List<string> sendTo { get; set; }
            [DataMember]
            public List<string> sendCc { get; set; }
         }
}
