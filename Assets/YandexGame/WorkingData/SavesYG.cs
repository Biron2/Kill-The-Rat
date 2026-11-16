
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 0;
        public int level = 0;
        public bool isWeapon2unlocked = false;
        public bool isWeapon3unlocked = false;
        public bool isWeapon4unlocked = false;
        public bool isWeapon5unlocked = false;
        public bool isWeapon6unlocked = false;
        public int choosenWeapon = 1;
        public int bullets_slot_counter = 0;

        public bool is_sounds_changed = false;
        public float sfx = 1;
        public float music = 1;
        public int showedad_for_gun = 0;

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
        }
    }
}
