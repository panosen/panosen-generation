using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.Generation
{
    /// <summary>
    /// 生成的文件
    /// </summary>
    public abstract class FileBase
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public abstract ContentType ContentType { get; }
    }
}
