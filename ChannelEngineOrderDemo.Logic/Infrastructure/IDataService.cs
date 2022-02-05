using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Logic.Infrastructure
{
    public interface IDataService<T>
    {
        Task<IList<T>> GetList(IDictionary<string, string> filters); 
    }
}
