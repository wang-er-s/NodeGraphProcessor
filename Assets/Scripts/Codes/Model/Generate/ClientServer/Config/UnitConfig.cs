using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;


namespace ET
{
    
    [Config]
    public partial class UnitConfigCategory : ConfigSingleton<UnitConfigCategory>, IMerge
    {
        
        [BsonIgnore]
        private Dictionary<int, UnitConfig> dict = new Dictionary<int, UnitConfig>();
		
        [BsonElement]
        
        private List<UnitConfig> list = new List<UnitConfig>();
		
        public void Merge(object o)
        {
            UnitConfigCategory s = o as UnitConfigCategory;
            this.list.AddRange(s.list);
        }
		
		       
        public void ProtoEndInit()
        {
            foreach (UnitConfig config in list)
            {
                config.AfterEndInit();
                this.dict.Add(config.Id, config);
            }
            this.list.Clear();
            
            this.AfterEndInit();
        }
		
        public UnitConfig Get(int id)
        {
            this.dict.TryGetValue(id, out UnitConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (UnitConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, UnitConfig> GetAll()
        {
            return this.dict;
        }

        public UnitConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    
	public partial class UnitConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		
		public int Id { get; set; }
		/// <summary>Type</summary>
		
		public int Type { get; set; }
		/// <summary>名字</summary>
		
		public string Name { get; set; }
		/// <summary>位置</summary>
		
		public int Position { get; set; }
		/// <summary>身高</summary>
		
		public int Height { get; set; }
		/// <summary>体重</summary>
		
		public int Weight { get; set; }

	}
}
