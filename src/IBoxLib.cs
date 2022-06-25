
using BoxLib.Documents;
using BoxLib.Fields;
using BoxLib.Indices;
using BoxLib.Settings;

namespace BoxLib
{
    public interface IBoxLib
    {
        ValueTask<BoxSettings> GetSettings();
        ValueTask<IFields> GetFields();
        ValueTask<IIndices> GetIndices();
        ValueTask<IDocuments> GetDocuments();
    }
}