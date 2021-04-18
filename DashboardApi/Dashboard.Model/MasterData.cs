using System;
using System.Collections.Generic;

namespace Dashboard.Model
{
    public class MasterData
    {
        public List<Commodity> Commodities { get; set; }
        public List<Model> Models { get; set; }
        public List<int> Years { get; set; }
    }
}
