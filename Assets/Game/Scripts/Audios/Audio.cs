
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static Audio;

/// ВАЖНО: для файлов не нужно указывать Расширение, нужно только имя и targetType 
///         unity сам загрузит файл с таким путём и имененм и попробует превратить его в targetType.
public static class Audio
{
    // sealed class SealedClass :WorldAudioAssetDefinition{
    //  public SealedClass(string fileName) : base($"Audios/WorldSounds/{fileName}") { }
    // }

    [System.Serializable]
    public class WorldSound : WorldAudioAssetDefinition
    {
        public static readonly WorldSound
            ENGINE_1 = new("engine_1__Vehicle_Car_Drive_Exterior_Loop"),

            SINGLE_GUN_SHOT = new("single_shot_1__cannon_01"),
            DEAD_1 = new("dead_1__Grenade6Short")

            ;

        public WorldSound(string fileName) : base($"Audios/WorldSounds/{fileName}") { }
    }

    [System.Serializable]
    public class Music : GlobalAudioAssetDefinition
    {
        public static readonly WorldSound
            // BATTLE_THEME_1 = new("battle_theme_1"),
            MAIN_MENU_1 = new("main_menu_1")

            ;

        public Music(string fileName) : base($"Audios/Musics/{fileName}") { }
    }

    public class InspectorAudio : WorldAudioAssetDefinition
    {
        public AudioClip clip;
        public InspectorAudio(AudioClip clip) : base(clipPath: clip.name, scope: AudioAssetScope.GLOBAL)
        {
            this.clip = clip;
        }
    }
}

[System.Serializable]
public abstract class GlobalAudioAssetDefinition : AudioAssetDefinition
{
    protected GlobalAudioAssetDefinition(string clipPath, AudioAssetScope scope = AudioAssetScope.GLOBAL, float volume = 1, float pitch = 1, bool isLoop = false, float cooldown = 0)
    : base(scope, clipPath, volume, pitch, isLoop, cooldown)
    {
    }
}
public abstract class WorldAudioAssetDefinition : AudioAssetDefinition
{
    protected WorldAudioAssetDefinition(string clipPath, AudioAssetScope scope = AudioAssetScope.WORLD, float volume = 1, float pitch = 1, bool isLoop = false, float cooldown = 0)
    : base(scope, clipPath, volume, pitch, isLoop, cooldown)
    {
    }
}

[System.Serializable]
public abstract class AudioAssetDefinition
{

    // asset part properties
    public AudioAssetScope scope;


    // audio part properties
    public string clipPath;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool isLoop;

    // if scope="GLOBAL" => cooldown for play again
    // if scope="WORLD" => cooldown for create new
    // value is sec
    public float cooldown;

    public AudioAssetDefinition(
        AudioAssetScope scope,
        string clipPath,
         float volume = 1f,
         float pitch = 1f,
         bool isLoop = false,
         float cooldown = 0f)
    {
        this.scope = scope;
        this.clipPath = clipPath;
        this.volume = volume;
        this.pitch = pitch;
        this.isLoop = isLoop;
        this.cooldown = cooldown;
    }

    public override bool Equals(object obj)
    {
        return obj is AudioAssetDefinition definition &&
               scope == definition.scope &&
               clipPath == definition.clipPath &&
               volume == definition.volume &&
               pitch == definition.pitch &&
               isLoop == definition.isLoop &&
               cooldown == definition.cooldown;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(scope, clipPath, volume, pitch, isLoop, cooldown);
    }
}

public enum AudioAssetScope { GLOBAL, WORLD }

public class AudioAssetLoader
{
    private Dictionary<AudioAssetDefinition, AudioClip> loaderAuidoAssets = new();

    public AudioClip Get(AudioAssetDefinition definition)
    {
        if (definition is InspectorAudio) return ((InspectorAudio)definition).clip;
        var temp = loaderAuidoAssets.GetValueOrDefault(definition);
        return (temp != null) ? temp : (temp = this.Load(definition));
    }

    private AudioClip Load(AudioAssetDefinition definition)
    {
        var clip = Resources.Load<AudioClip>(definition.clipPath);
        if (clip == null) throw new Exception($"fail to load AudioClip by path=\"Assets\\Audios\" {definition.clipPath}");
        return clip;
    }


    public static Dictionary<string, string> GetFieldValues(object obj)
    {
        return obj.GetType()
                  .GetFields(BindingFlags.Public | BindingFlags.Static)
                  .Where(f => f.FieldType == typeof(string))
                  .ToDictionary(f => f.Name,
                                f => (string)f.GetValue(null));
    }
}