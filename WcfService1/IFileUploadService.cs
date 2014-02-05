using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService1
{
    [ServiceContract]
    public interface IFileUploadService
    {
        [OperationContract]
        bool UploadFileData(FileData fileData);
    }

    [DataContract]
    public class FileData
    {
        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public byte[] BufferData { get; set; }

        [DataMember]
        public int FilePosition { get; set; }

    }

    [DataContract]
    public class ErrorDetails
    {
        [DataMember]
        public int ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
