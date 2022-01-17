using Elasticsearch.Net;
using Nest;
using System;
using System.Linq;

namespace GoodFramework.Abp.Elasticsearch
{
    public class AbpElasticsearchOptions
    {
        public bool Enabled { get; set; }
        /// <summary>
        /// 字段名称 是否为 camelCase 格式
        /// 如果为true, 在ES中为 camelCase
        /// 如果为false，在ES中为 CamelCase
        /// 默认：false
        /// </summary>
        public bool FieldCamelCase { get; set; }
        public string NodeUris { get; set; }
        public int ConnectionLimit { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public TimeSpan ConnectionTimeout { get; set; }
        public IConnection Connection { get; set; }
        public ConnectionSettings.SourceSerializerFactory SerializerFactory { get; set; }

        public AbpElasticsearchOptions()
        {
            this.ConnectionLimit = ConnectionConfiguration.DefaultConnectionLimit;
            this.ConnectionTimeout = ConnectionConfiguration.DefaultTimeout;
        }

        internal IConnectionSettingsValues CreateConfiguration()
        {
            IConnectionPool connectionPool;
            var nodes = this.NodeUris
                .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(uriString => new Uri(uriString));
            if (nodes.Count() == 1)
            {
                connectionPool = new SingleNodeConnectionPool(nodes.First());
            }
            else
            {
                connectionPool = new StaticConnectionPool(nodes);
            }
            var configuration = new ConnectionSettings(
                connectionPool,
                this.Connection,
                this.SerializerFactory)
                .ConnectionLimit(this.ConnectionLimit)
                .RequestTimeout(this.ConnectionTimeout);

            if (!FieldCamelCase)
            {
                configuration.DefaultFieldNameInferrer((name) => name);
            }

            if (this.UserName.IsNullOrWhiteSpace())
            {
                configuration.BasicAuthentication(this.UserName, this.Password);
            }

            return configuration;
        }
    }
}
