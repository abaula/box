using BoxLib.Settings;

namespace BoxLib
{
    public static class BoxLibFactory
    {
        public static ValueTask<BoxSettings> LoadSettings(string path)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<IBoxLib> Create(BoxSettings settings)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<IBoxLib> Create(string settingsPath)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<IBoxLib> Get(string settingsPath)
        {
            throw new NotImplementedException();
        }
    }
}