using System.Text.Json;
using BoxLib.Settings;

namespace BoxLib
{
    public static class BoxLibFactory
    {
        /// <summary>
        /// Создаёт экземпляр настроек из файла.
        /// </summary>
        /// <param name="path">Путь к файлу настроек.</param>
        /// <returns>Экземпляр настроек.</returns>
        public static BoxSettings LoadSettings(string path)
        {
            return JsonSerializer.Deserialize<BoxSettings>(path);
        }

        /// <summary>
        /// Создаёт новый Box.
        /// </summary>
        /// <param name="settings">Экземпляр настроек.</param>
        /// <returns>Ссылка на объект BoxLib.</returns>
        /// <exception cref="System.InvalidOperationException">Ошибка при создании Box.</exception>
        public static ValueTask<IBoxLib> Create(BoxSettings settings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создаёт новый Box.
        /// </summary>
        /// <param name="settingsPath">Путь к файлу настроек.</param>
        /// <returns>Ссылка на объект BoxLib.</returns>
        /// <exception cref="System.InvalidOperationException">Ошибка при создании Box.</exception>
        public static ValueTask<IBoxLib> Create(string settingsPath)
        {
            var settings = LoadSettings(settingsPath);

            return Create(settings);
        }

        /// <summary>
        /// Открывает существующий Box.
        /// </summary>
        /// <param name="settingsPath">Путь к файлу настроек.</param>
        /// <returns>Ссылка на объект BoxLib.</returns>
        public static ValueTask<IBoxLib> Open(string settingsPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет все данные Box.
        /// </summary>
        /// <param name="settingsPath">Путь к файлу настроек.</param>
        public static ValueTask Delete(string settingsPath)
        {
            throw new NotImplementedException();
        }
    }
}