using BoxLib.Fields;

namespace BoxLib.Indices
{
    public interface IIndices
    {
        ValueTask<IIndex[]> GetAll();
        ValueTask<IIndex[]> Get(IField field);
        ValueTask AddIndex(IField field, IndexSettings settings);
        ValueTask Delete(IIndex index);
    }
}