namespace ChannelEngineOrderDemo.Logic.Objects
{
    /*
     * Communication object of patch data
     */
    public class PatchData
    {
        public object Value { set; get; }
        public string Path { set; get; }
        public string Op { set; get; }
    }
}
