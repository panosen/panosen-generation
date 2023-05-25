using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.Generation
{
    /// <summary>
    /// 生成结果
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Ban Duplicate
        /// </summary>
        public Dictionary<string, int> FileCountMap { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// 文件
        /// </summary>
        public List<FileBase> Files { get; private set; } = new List<FileBase>();

        /// <summary>
        /// 写入字符串
        /// </summary>
        public void Add(string path, string content, Encoding encoding = null, bool skipIfExists = false)
        {
            this.Add(new PlainFile
            {
                FilePath = path,
                Content = content,
                Encoding = encoding,
                SkipIfExists = skipIfExists
            });
        }

        /// <summary>
        /// 写入字节
        /// </summary>
        public void Add(string path, byte[] bytes, bool skipIfExists = false)
        {
            this.Add(new BytesFile
            {
                FilePath = path,
                Bytes = bytes,
                SkipIfExists = skipIfExists
            });
        }

        /// <summary>
        /// 防止重复写入文件
        /// </summary>
        /// <param name="file"></param>
        private void Add(FileBase file)
        {
            var path = file.FilePath;

            var fileCount = this.FileCountMap.ContainsKey(path) ? this.FileCountMap[path] : 0;
            if (fileCount == 0)
            {
                this.Files.Add(file);
                this.FileCountMap[path] = 1;
                return;
            }

            file.FilePath = path + "." + fileCount;
            this.Files.Add(file);
            this.FileCountMap[path] = fileCount + 1;
        }
    }
}
