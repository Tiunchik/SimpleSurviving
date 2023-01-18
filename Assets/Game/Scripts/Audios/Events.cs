using Audio.Lib.Tools;
using UnityEngine.Events;

namespace Audio
{
    public static class Event
    {
        public static UnityEvent<WorldAudioAssetDefinition>
            PlayMainMenuTheme,
            PlayWinTheme,

            Test__PlayOnMouseClick
        ;
    }
}