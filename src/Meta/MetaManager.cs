using System.Text;
using System.Text.Json;
using BoxLib.Settings;

namespace BoxLib.Meta
{
    class MetaManager
    {
        private readonly BoxSettings _settings;
        private Lazy<BoxMeta> _boxMeta;

        public MetaManager(BoxSettings settings)
        {
            _settings = settings;
            _boxMeta = new Lazy<BoxMeta>(LoadMeta);
        }

        public BoxMeta BoxMeta => _boxMeta.Value;

        private BoxMeta LoadMeta()
        {
            var fileContent = File.ReadAllText(_settings.BoxMetaPath, Encoding.UTF8);

            return JsonSerializer.Deserialize<BoxMeta>(fileContent);
        }
    }
}