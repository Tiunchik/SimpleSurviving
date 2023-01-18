using System.Collections.Generic;
using Audio.Lib.Tools;
using UnityEngine;
using Utils;


/* *Документация*
    Термины:
    - WORLD audio = аудио что звучат по всему миру, не являются 3D звуками, их расположение не влияет не на что.
        Пример: фоновая музыка, UI звуки при выборе/подтверждении/изменении пункта меню.
    - LOCAL audio = аудио что звучат локально, по идеи это 3D звуки их расположение влияет на их слышимость для Игрок(AudioListener)
        Пример: Звук выстрела/взрыва/подбора бонуса/езды
        
    Ответственность класса(class responsibility):
    - 
    - 
    
    Потенциал развития:
    - сделать AudioManager GameEventListener или что-то такое - что бы выкинуть жосткую связанность кода
        через publish static final INSTANCE
    - при потребности сделать timer|cooldown для GLOBLA audio - что бы не было спама звука
    - ? вынести работу с WORLD audio куда-то, тут оставить только код для GLOBLA audio
    - проверка что все заранее прописанные в коде Аудио-Ассеты МОГУТ быть успешно загружены(файлы рили существуют и норм грузятся).



    *ХУЙНЯ*
    scope: [global(singltone) | world(prototype)]
    playTimeCooldown: float, default = 0;


    Sound Properties:
    clipPath
    volume
    pitch
    isLoop
    cooldown


    API:
    - Play() // start or resume
    - Pause()
    - Reset() ???
    - AudioClipLoader.Dispose()
    - AudioClipLoader.Load()
    - 
    AudioSource PlayGlobal
    AudioSource AddAudioToObject(Transform|GameObject targetObj, SoundDefenition definition);
    GameObject CreateAudioSourceGameObject(Vector3 position)


    ? а как управлять звуками у перса(world) если их нужно проигрывать снова?
    // todo -  
    // todo - у WORLD по идеи не должно быть cooldown? пока хз.
    // 
    // todo - SOUND, WORLD - как enum, мб не плохая идея??? -- это не особо рельно технически. (((
    *ХУЙНЯ - КОНЕЦ*
*/

// public static readonly Audio.WorldSound Newtonsoft_THEME_1 = new ("");
public class AudioManager : MonoBehaviour
{
    private static AudioManager _currentSceneAudioManager;
    public static AudioManager INST
    {
        get
        {
            return (_currentSceneAudioManager == null)
            ? (_currentSceneAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>())
            : _currentSceneAudioManager;
        }
    }



    // private AudioAssetLoader loader = new();
    private Dictionary<AudioAssetDefinition, float> audioCooldownTimers = new();
    private Dictionary<AudioAssetDefinition, AudioSource> allGlobalAudio = new();
    private Dictionary<AudioAssetDefinition, AudioSource> allWorldAudio = new();
    private GameObject globalAudioObjectContainer;

    void Start()
    {
        globalAudioObjectContainer = this.gameObject;
    }


    /* GLOBAL part API */


    public AudioSource GetOrLoad(WorldAudioAssetDefinition definition)
    {
        return this.allGlobalAudio.computeIfAbsent(definition, def => this.AddAudioToGlobal(def));
    }

    public AudioSource Play(WorldAudioAssetDefinition definition, float delay = 0f)
    {
        var audio = this.GetOrLoad(definition);
        this.PlayAudioComponent(audio, delay);
        return audio;
    }


    /* WORLD part API */


    // public AudioSource AddAudioToObject(WorldAudioAssetDefinition definition, Transform targetObj)
    //     => AddAudioToObject(definition, targetObj.gameObject);
    // public AudioSource AddAudioToObject(WorldAudioAssetDefinition definition, GameObject targetObj)
    //     => this.InitAudio(definition, targetObj, allWorldAudio);


    // /// <summary>Создаеёт {EmptyGameObject} по указанным координатам с единственным компонентом {AudioSource}.</summary>
    // /// <param name="definition">аудио-ассет для AudioSource компонента.</param>
    // /// <param name="position">позиция где будет создан Объект.</param>
    // /// <param name="destroyAfter">уничтожить Объект по окончания воспроизведения звукойой дорожки. defaul=true</param>
    // public GameObject CreateAudioObject(WorldAudioAssetDefinition definition,
    //     Vector2 position, bool playNow = true, bool destroyAfter = true)
    // {
    //     var worldSoundObject = new GameObject($"World Sound Object - {definition.clipPath}");
    //     worldSoundObject.transform.position = position;

    //     var audio = this.InitAudio(definition, worldSoundObject, allWorldAudio);
    //     audio.rolloffMode = AudioRolloffMode.Linear;
    //     if (destroyAfter) Destroy(worldSoundObject, audio.clip.length);
    //     if (playNow) audio.Play();
    //     return worldSoundObject;
    // }

    
    // /// <summary>Создаеёт {EmptyGameObject} по указанным координатам с единственным компонентом {AudioSource}.
    // /// используется для работы со значениями из Inspector.</summary>
    // /// <param name="clip">аудио-ассет для AudioSource компонента.</param>
    // public GameObject CreateAudioObject(AudioClip clip, Vector2 position, bool playNow = true, bool destroyAfter = true)
    //     => this.CreateAudioObject(new InspectorAudio(clip), position, playNow, destroyAfter);



    // /* private part */


    // /// в Доке сказано что лучше НЕ использовать .Play(delay: ${delay})
    // private void PlayAudioComponent(AudioSource audioSourceComponent, float delay)
    // {
    //     if (delay < 0f)
    //         audioSourceComponent.Play();
    //     else
    //         audioSourceComponent.PlayDelayed(delay);
    // }

    // private AudioSource AddAudioToGlobal(AudioAssetDefinition definition)
    // {
    //     return InitAudio(definition, globalAudioObjectContainer, allGlobalAudio);
    // }

    // private AudioSource InitAudio(AudioAssetDefinition definition, GameObject targetObj,
    //     Dictionary<AudioAssetDefinition, AudioSource> allAudioByType)
    // {
    //     if (definition == null) throw new Exception("definition must be NotNull!");
    //     if (targetObj == null) throw new Exception("targetObj must be NotNull!");

    //     var audio = targetObj.AddComponent<AudioSource>();
    //     audio.clip = loader.Get(definition);
    //     audio.volume = definition.volume;
    //     audio.pitch = definition.pitch;
    //     audio.loop = definition.isLoop;
    //     // audio.??? = definition.cooldown; // todo - make timer and cooldown
    //     allAudioByType[definition] = audio;

    //     // Debug.Log($"audio={audio.clip.ToString()}");
    //     return audio;
    // }

}