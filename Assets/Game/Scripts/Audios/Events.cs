using Audio.Lib.Tools;
using UnityEngine.Events;

namespace Audio
{
    public static class Event
    {
        
    // public static class MainTheme
    // {
        
    //     public static UnityEvent<WorldAudioAssetDefinition, float> Play = new();
    //     public static UnityEvent<WorldAudioAssetDefinition, ChangeVolume> Stop = new();
    // }

        // List<EventListener<WorldAudioAssetDefinition>>
        public static UnityEvent<WorldAudioAssetDefinition> PlayMainMenuTheme = new();
        public static UnityEvent<WorldAudioAssetDefinition> StopMainMenuTheme = new();

        public static UnityEvent<WorldAudioAssetDefinition> PlayWinTheme = new();
        public static UnityEvent<WorldAudioAssetDefinition, string, float> Test__PlayOnMouseClick = new();
        public static UnityEvent<AudioAssetDefinition, float> ChangeMusicVolume = new();

    }
}