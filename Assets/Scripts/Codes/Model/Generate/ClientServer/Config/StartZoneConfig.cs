using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;


namespace ET
{
    [Config]
    public partial class StartZoneConfigCategory : ConfigSingleton<StartZoneConfigCategory>, IMerge
    {
        [BsonIgnore] private Dictionary<int, StartZoneConfig> dict = new Dictionary<int, StartZoneConfig>();

        [BsonElement] private List<StartZoneConfig> list = new List<StartZoneConfig>();

        public void Merge(object o)
        {
            StartZoneConfigCategory s = o as StartZoneConfigCategory;
            this.list.AddRange(s.list);
        }


        public void ProtoEndInit()
        {
            foreach (StartZoneConfig config in list)
            {
                config.AfterEndInit();
                this.dict.Add(config.Id, config);
            }

            this.list.Clear();

            this.AfterEndInit();
        }

        public StartZoneConfig Get(int id)
        {
            this.dict.TryGetValue(id, out StartZoneConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof(StartZoneConfig)}，配置id: {id}");
            }

            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, StartZoneConfig> GetAll()
        {
            return this.dict;
        }

        public StartZoneConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }

            return this.dict.Values.GetEnumerator().Current;
        }
    }


    public partial class StartZoneConfig : ProtoObject, IConfig
    {
        /// <summary>Id</summary>

        public int Id { get; set; }

        /// <summary>数据库地址</summary>

        public string DBConnection { get; set; }

        /// <summary>数据库名</summary>

        public string DBName { get; set; }
    }
}