
namespace BoxLib.Fields
{
    public interface IFields
    {
        ValueTask<IField[]> GetAllFields();
        ValueTask<IField> Get(int id);
        ValueTask<IField> Get(string id);
        ValueTask Add(IField field);
        ValueTask Delete(IField field);
        ValueTask Delete(int fieldId);
        ValueTask Delete(string fieldId);
    }
}