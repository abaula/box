using BoxLib.Documents;
using BoxLib.Fields;
using BoxLib.Indices;
using BoxLib.Meta;
using BoxLib.Settings;

namespace BoxLib
{
    class BoxLib : IBoxLib
    {
        private readonly MetaManager _metaManager;

        public BoxLib(MetaManager metaManager)
        {
            _metaManager = metaManager;
        }

        public ValueTask<IDocuments> GetDocuments() => throw new NotImplementedException();
        public ValueTask<IFields> GetFields() => throw new NotImplementedException();
        public ValueTask<IIndices> GetIndices() => throw new NotImplementedException();
        public ValueTask<BoxSettings> GetSettings() => throw new NotImplementedException();
    }
}