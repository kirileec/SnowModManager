using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowModManager
{
    public class Mod
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        public string Name { get; set; }
        /// <summary>
        /// 相对路径
        /// </summary>
        [Description("路径")]
        public string Path { get; set; }

        [Description("FullPath")]
        public string FullPath { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string Desc { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        public bool Enabled { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Description("修改时间")]
        public DateTime EditTime { get; set; }
        /// <summary>
        /// 分类(角色)
        /// </summary>
        [Description("角色(分类)")]
        public string Category { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Enabled: {Enabled}";
        }
    }
}
