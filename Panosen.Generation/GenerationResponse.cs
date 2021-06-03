using System;
using System.Collections.Generic;

namespace Panosen.Generation
{
    /// <summary>
    /// 生成结果
    /// </summary>
    public class GenerationResponse
    {
        /// <summary>
        /// Ban Duplicate
        /// </summary>
        public Dictionary<string, int> FileCountMap { get; private set; } = new Dictionary<string, int>();

        /// <summary>
        /// 文件
        /// </summary>
        public Dictionary<string, FileBase> Files { get; private set; } = new Dictionary<string, FileBase>();

        public void Write(string path, string content)
        {
            this.Write(path, new PlainFile { FilePath = path, Content = content });
        }

        public void Write(string path, byte[] bytes)
        {
            this.Write(path, new BytesFile { FilePath = path, Bytes = bytes });
        }

        /// <summary>
        /// 防止重复写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        private void Write(string path, FileBase file)
        {
            var fileCount = this.FileCountMap.ContainsKey(path) ? this.FileCountMap[path] : 0;
            if (fileCount == 0)
            {
                this.Files.Add(path, file);
                this.FileCountMap[path] = 1;
                return;
            }

            this.Files.Add(path + "." + fileCount, file);
            this.FileCountMap[path] = fileCount + 1;
        }
    }
}
