/* *Документация по всему Audio*
Термины:
- WORLD audio = аудио что звучат по всему миру, не являются 3D звуками, их расположение не влияет не на что.
       Пример: фоновая музыка, UI звуки при выборе/подтверждении/изменении пункта меню.
- LOCAL audio = аудио что звучат локально, по идеи это 3D звуки их расположение влияет на их слышимость для Игрок(AudioListener)
       Пример: Звук выстрела/взрыва/подбора бонуса/езды
- PlayList = (как Java enum) static class с набором констант с Типом ***AudioAssetDefinition сгруппированных по темам.
       Пример: Music - набор музыки что может играть на фоне.
       !!! ВАЖНО: PlayList.value - нужно указывать только имя аудио-файла, Расширение не нужно.
       !!! ВАЖНО: PlayList.value - все аудио-файлы должны лежать в папке Assets/Resources/Audios/... .
*/

/* TODO по Audio
- Tools - Object with Component - WorldAudioPlayer {}
              - подписывается на Event и управлять состоянием Аудио внутри.
- Future - Game.settings.audio [musicVolume, effectVolume] - как это реализовать, если не компоненты?
- 
*/
using Audio.Lib.Tools;

namespace Audio.Lib
{

    /* PlayLists */


    public class Tank : LocalAudioAssetDefinition
    {
        public static readonly Tank
            ENGINE_1 = new("engine_1__Vehicle_Car_Drive_Exterior_Loop"),

            SINGLE_GUN_SHOT = new("single_shot_1__cannon_01"),
            DEAD_1 = new("dead_1__Grenade6Short")

            ;

        public Tank(string fileName) : base($"Audios/WorldSounds/{fileName}") { }
    }

    public class Music : WorldAudioAssetDefinition
    {
        public static readonly Music
            WIN_THEME_1 = new("not implements"),
            MAIN_MENU_1 = new("main_menu_1")

            ;

        public Music(string fileName) : base($"Audios/Musics/{fileName}") { }
    }

}