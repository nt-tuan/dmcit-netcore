using DMCIT.Infrastructure.Data.Workflow;

namespace DMCIT.Web.ApiModels.Workflows
{
    public class FileInfoModel
    {
        public string fileName { get; set; }
        public string path { get; set; }
        public FileInfoModel(FileInf fin)
        {
            fileName = fin.FileName;
            path = fin.Path;
        }
    }
}
