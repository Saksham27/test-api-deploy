using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EmpManagement.CL.Models
{
    #region ResponseMessage
    [DataContract]
    [Serializable]
    public class ResponseMessage
    {
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        [DataMember(Name = "Status")]
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        [DataMember(Name = "Message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Data
        /// </summary>
        [DataMember(Name = "Data")]
        public List<DisplayAllDetails> Data { get; set; } = null;
    }
    #endregion
}
