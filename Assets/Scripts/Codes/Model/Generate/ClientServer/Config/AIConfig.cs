using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;


namespace ET
{
    
    [Config]
    public partial class AIConfigCategory : ConfigSingleton<AIConfigCategory>, IMerge
    {
        
        [BsonIgnore]
        private Dictionary<int, AIConfig> dict = new Dictionary<int, AIConfig>();
		
        [BsonElement]
        
        private List<AIConfig> list = new List<AIConfig>();
		
        public void Merge(object o)
        {
            AIConfigCategory s = o as AIConfigCategory;
            this.list.AddRange(s.list);
        }
		
		       
        public void ProtoEndInit()
        {
            foreach (AIConfig config in list)
            {
                config.AfterEndInit();
                this.dict.Add(config.Id, config);
            }
            this.list.Clear();
            
            this.AfterEndInit();
        }
		
        public AIConfig Get(int id)
        {
            this.dict.TryGetValue(id, out AIConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (AIConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, AIConfig> GetAll()
        {
            return this.dict;
        }

        public AIConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    
	public partial class AIConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		
		public int Id { get; set; }
		/// <summary>所属ai</summary>
		
		public int AIConfigId { get; set; }
		/// <summary>此ai中的顺序</summary>
		
		public int Order { get; set; }
		/// <summary>节点名字</summary>
		
		public string Name { get; set; }
		/// <summary>节点参数</summary>
		
		public int[] NodeParams { get; set; }

	}
}
