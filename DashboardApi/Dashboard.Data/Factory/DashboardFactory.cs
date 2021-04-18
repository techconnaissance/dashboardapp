    using System;
using Dashboard.Data.Context;
using Dashboard.Data; 

namespace Dashboard.Data
{
    public class DashboardFactory: Factory, IDashboardFactory
    {
        protected DashboardContext _ctx;
        public DashboardFactory(DashboardContext dbcontext) : base(dbcontext)
        {
            this._ctx = dbcontext;
        }
    }
}
