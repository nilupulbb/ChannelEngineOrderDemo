using ChannelEngineOrderDemo.Logic.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Logic.Infrastructure
{
    /*
     * Specifies common methods to implement for communicating with a data service
     */
    public interface IDataService<T>
    {
        /*
         * Gets a list from data service
         */
        Task<IList<T>> GetList(IDictionary<string, string> filters);

        /*
         * Patch an entity using data service
         */
        Task Patch(IList<PatchData> patches, string id);
    }
}
