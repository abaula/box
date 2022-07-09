using System.Text.Json;
using BoxLib.Settings;

namespace BoxLib.Meta
{
    class MetaManager
    {
        private readonly BoxSettings _settings;

        public MetaManager(BoxSettings settings)
        {
            _settings = settings;
        }

        public BoxMeta GetBoxMeta()
        {
            return JsonSerializer.Deserialize<BoxMeta>(_settings.BoxMetaPath);
        }
    }
}