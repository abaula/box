using BoxLib.Fields;
using BoxLib.Filters;

namespace BoxLib.Documents
{
    public interface IDocuments
    {
        ValueTask<IDocument> GetDocument(long documentId);
        ValueTask<long[]> FindDocumentIds(IField field, byte[] fieldValue, IFilter filter);
    }
}