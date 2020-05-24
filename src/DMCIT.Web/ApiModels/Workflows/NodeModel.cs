namespace DMCIT.Web.ApiModels.Workflows
{
    public class NodeModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public NodeModel(string id, string name, string parentId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }
    }

}
