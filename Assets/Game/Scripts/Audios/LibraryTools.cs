using System;
using System.Collections.Generic;
using UnityEngine;

namespace Audio.Lib.Tools
{
    /// Тип для интеграции с Unity Inspector
    public class InspectorAudio : LocalAudioAssetDefinition
    {
        public AudioClip clip;
        public InspectorAudio(AudioClip clip) : base(clip.name) { this.clip = clip; }
    }


    public abstract class WorldAudioAssetDefinition : AudioAssetDefinition
    {
        protected WorldAudioAssetDefinition(string clipPath, float volume = 1, float pitch = 1, bool isLoop = false)
                : base(clipPath, volume, pitch, isLoop) { }
    }
    public abstract class LocalAudioAssetDefinition : AudioAssetDefinition
    {
        public float minDistance, maxDistance;
        protected LocalAudioAssetDefinition(string clipPath, float volume = 1, float pitch = 1, bool isLoop = false,
            float minDistance = 1f, float maxDistance = 100f) : base(clipPath, volume, pitch, isLoop)
        {
            this.minDistance = minDistance;
            this.maxDistance = maxDistance;
        }
    }

    // DSL конфигурация - описывается Аудио-файл и его Перенастроек AudioSource(Component) или ему подобных.
    /// Базовый Тип для Предописания 
    public abstract class AudioAssetDefinition
    {
        public string clipPath;

        [Range(0f, 1f)]
        public float volume;

        [Range(0.1f, 3f)]
        public float pitch;

        public bool isLoop;

        public AudioAssetDefinition(
            string clipPath,
             float volume = 1f,
             float pitch = 1f,
             bool isLoop = false)
        {
            this.clipPath = clipPath;
            this.volume = volume;
            this.pitch = pitch;
            this.isLoop = isLoop;
        }

        public override bool Equals(object obj) 
            => obj is AudioAssetDefinition definition && clipPath == definition.clipPath;


        public override int GetHashCode() => clipPath.GetHashCode();
    }

    public static class AudioClipLoader
    {
        // private static ConcurrentDictionary<AudioAssetDefinition, AudioClip> loaderAudioAssets = new();
        private static Dictionary<AudioAssetDefinition, AudioClip> loaderAudioAssets = new();


        public static AudioClip GetOrLoad(AudioAssetDefinition definition)
        {
            if (definition is InspectorAudio) return ((InspectorAudio)definition).clip;
            var temp = loaderAudioAssets.GetValueOrDefault(definition);
            return (temp != null) ? temp : (temp = Load(definition));
        }

        /// todo - impl
        public static AudioClip GetOrLoadAsync(AudioAssetDefinition definition)
        {
            throw new NotImplementedException();
        }
        /// todo - impl
        public static AudioClip GetAllOrLoadAsync(params AudioAssetDefinition[] definitions)
        {
            throw new NotImplementedException();
        }
        /// todo - impl
        public static AudioClip GetAllOrLoadAsyncParallel(params AudioAssetDefinition[] definitions)
        {
            throw new NotImplementedException();
        }

        public static AudioClip Load(AudioAssetDefinition definition)
        {
            var clip = Resources.Load<AudioClip>(definition.clipPath);
            if (clip == null) throw new Exception($"fail to load AudioClip by path=\"Assets\\Audios\" {definition.clipPath}");
            return clip;
        }

        /// todo - impl
        public static AudioClip LoadAsync(AudioAssetDefinition definition)
        {
            throw new NotImplementedException();
        }

        /// todo - impl
        /// загрузить все файлы в Одной корутюне.
        public static AudioClip LoadAsyncAll(params AudioAssetDefinition[] definitions)
        {
            throw new NotImplementedException();
        }
        /// todo - impl
        /// загрузить все файлы в отдельных корутюнах. 10 файлов == 10 корутюн
        public static AudioClip LoadAsyncAllParallel(params AudioAssetDefinition[] definitions)
        {
            throw new NotImplementedException();
        }

        /// Пример: checkCanBeNormallyLoadPlayList<Music>
        /// Проверка что все enum-values(аудио пре-ассеты) из класса T могут быть загружены корректно.
        /// обычно для DEBUG и проверки корректности путей Resources files.
        public static List<Exception> checkCanBeNormallyLoadPlayList<T>() where T : AudioAssetDefinition
        {
            throw new NotImplementedException();
        }

    }

}