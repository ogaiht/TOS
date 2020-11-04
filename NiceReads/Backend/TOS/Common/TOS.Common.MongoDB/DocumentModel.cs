using MongoDB.Bson;
using TOS.Common.DataModel;

namespace TOS.Common.MongoDB
{
    public abstract class DocumentModel : BaseModel<ObjectId>, IDocumentModel
    {
        protected DocumentModel()
        {

        }
    }
}
