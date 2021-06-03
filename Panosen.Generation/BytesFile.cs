using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.Generation
{
    /// <summary>
    /// 字节文件
    /// </summary>
    public class BytesFile : FileBase
    {
        /// <summary>
        /// 字节
        /// </summary>
        public override ContentType ContentType => ContentType.Bytes;

        /// <summary>
        /// 字节
        /// </summary>
        public byte[] Bytes { get; set; }
    }
}
