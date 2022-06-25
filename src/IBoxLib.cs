
using BoxLib.Settings;

namespace BoxLib
{
    public interface IBoxLib
    {
        ValueTask<BoxSettings> GetSettings();
        ValueTask Init();
    }
}