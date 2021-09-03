using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.Generation
{
    /// <summary>
    /// 字符串文件
    /// </summary>
    public class PlainFile : FileBase
    {
        /// <summary>
        /// 字符串
        /// </summary>
        public override ContentType ContentType => ContentType.String;

        /// <summary>
        /// 纯文本
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public Encoding Encoding { get; set; }
    }
}
