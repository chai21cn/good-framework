using Good.Framework.Platform.Routes;
using System;
using System.Collections.Generic;

namespace Good.Framework.Platform.Menus
{
    public class MenuDto : RouteDto
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 菜单布局页
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 框架
        /// </summary>
        public string Framework { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 所属布局标识
        /// </summary>
        public Guid LayoutId { get; set; }

        public bool IsPublic { get; set; }
    }
}
