using Service.Message.Models;
using SuperSocket.ProtoBase;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Message.Filters
{
    /// <summary>
    /// 自定义数据过滤器
    /// </summary>
    public class DataFilter : IPipelineFilter<DataPackage>
    {
        public IPackageDecoder<DataPackage> Decoder { get; set; }

        public object Context { get; set; }

        public IPipelineFilter<DataPackage> NextFilter => this;

        public DataPackage Filter(ref SequenceReader<byte> reader)
        {
            DataPackage txtPackage = new DataPackage { Datas = reader.Sequence.ToArray() };
            while (reader.TryRead(out _)) ;
            return txtPackage;
        }

        public void Reset() { }

    }
}
