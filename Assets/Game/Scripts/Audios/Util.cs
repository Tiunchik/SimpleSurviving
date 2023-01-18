using System;
using System.Diagnostics.CodeAnalysis;
using Audio.Lib.Tools;
using UnityEngine;

namespace Audio
{
    public static class Util
    {


        public static AudioSource AddAudioToObject(AudioClip audio, Transform target)
            => AddAudioToObject(new InspectorAudio(audio), target.gameObject);
        public static AudioSource AddAudioToObject(AudioClip audio, GameObject target)
            => AddAudioToObject(new InspectorAudio(audio), target);
        public static AudioSource AddAudioToObject(AudioAssetDefinition audio, Transform target)
            => AddAudioToObject(audio, target.gameObject);
        public static AudioSource AddAudioToObject(AudioAssetDefinition audio, GameObject target)
            => InitAudio(audio, target);


        /// <summary>Создаёт {EmptyGameObject} по указанным координатам с единственным компонентом {AudioSource}.</summary>
        /// <param name="definition">аудио-ассет для AudioSource компонента.</param>
        /// <param name="position">позиция где будет создан Объект.</param>
        /// <param name="destroyAfter">уничтожить Объект по окончания воспроизведения звуковой дорожки. default=true</param>
        public static AudioSource CreateLocalAudioObject(LocalAudioAssetDefinition definition,
            Vector2 objPos, bool playNow = true, bool destroyAfter = true)
        {
            var worldSoundObject = new GameObject($"World Sound Object - {definition.clipPath}");
            worldSoundObject.transform.position = objPos;

            var audio = InitAudio(definition, worldSoundObject);
            audio.rolloffMode = AudioRolloffMode.Linear;
            audio.minDistance = definition.minDistance;
            audio.maxDistance = definition.maxDistance;
            audio.spatialBlend = 1;
            if (destroyAfter) UnityEngine.Object.Destroy(worldSoundObject, audio.clip.length);
            if (playNow) audio.Play();
            return audio;
        }


        /// <summary>Создаёт {EmptyGameObject} по указанным координатам с единственным компонентом {AudioSource}.
        /// используется для работы со значениями из Inspector.</summary>
        /// <param name="clip">аудио-ассет для AudioSource компонента.</param>
        public static AudioSource CreateLocalAudioObject(AudioClip clip, Vector2 position, bool playNow = true, bool destroyAfter = true)
            => CreateLocalAudioObject(new InspectorAudio(clip), position, playNow, destroyAfter);



        /* private part */


        /// в Доке сказано что лучше НЕ использовать .Play(delay: ${delay})
        private static void PlayAudioComponent(AudioSource audioSourceComponent, float delay)
        {
            if (delay < 0f)
                audioSourceComponent.Play();
            else
                audioSourceComponent.PlayDelayed(delay);
        }

        private static AudioSource InitAudio(
            [NotNull] AudioAssetDefinition definition, [NotNull] GameObject target)
        {
            if (definition == null) throw new Exception("definition must be NotNull!");
            if (target == null) throw new Exception("target must be NotNull!");

            var audio = target.AddComponent<AudioSource>();
            audio.clip = AudioClipLoader.GetOrLoad(definition);
            audio.volume = definition.volume;
            audio.pitch = definition.pitch;
            audio.loop = definition.isLoop;

            // Debug.Log($"audio={audio.clip.ToString()}");
            return audio;
        }
    }
}