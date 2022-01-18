namespace GoodFramework.Abp.IM.Messages
{
    public enum MessageType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text = 0,
        /// <summary>
        /// 图片消息
        /// </summary>
        Image = 10,
        /// <summary>
        /// 链接
        /// </summary>
        Link = 20,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 30,
        /// <summary>
        /// 音频
        /// </summary>
        Voice = 40,
        /// <summary>
        /// 文件
        /// </summary>
        File = 50
    }
}
