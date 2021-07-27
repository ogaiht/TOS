using System;
using TOS.Common.DataModel;

namespace TOS.Common.MongoDB
{
    public abstract class DocumentModel : BaseModel<Guid>, IDocumentModel
    {
        protected DocumentModel()
        {

        }
    }
}
