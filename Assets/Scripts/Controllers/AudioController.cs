using UnityEngine;

public class AudioController : DontDestroySingleton<AudioController>
{
    [SerializeField] private AudioSource mainMusicSource;
    [SerializeField] private AudioSource firstSoundSource;
    [SerializeField] private AudioSource secondSoundSource;
    [SerializeField] private AudioSource thirdSoundSource;

    [SerializeField] private AudioClip mainSceneBg;
    [SerializeField] private AudioClip buttonClick;

    private float musicVolume;
    private float soundVolume;
    public float SetMusicVolume 
    { set
        {
            if (value > 1)
                value = 1;
            if (value < 0)
                value = 0;
            musicVolume = value;
            mainMusicSource.volume = value;
        } 
    }
    public float SetSoundVolume
    {
        set
        {
            if (value > 1)
                value = 1;
            if (value < 0)
                value = 0;
            soundVolume = value;
            firstSoundSource.volume = value;
            secondSoundSource.volume = value;
            thirdSoundSource.volume = value;
        }
    }

    public void PlayMainSound(MainSounds sound)
    {
        AudioClip clip = mainSceneBg;
        if (sound == MainSounds.MainSceneBg)
            clip = mainSceneBg;

        mainMusicSource.clip = clip;
        mainMusicSource.Play();
    }

    public void PlayUiSound(UiSound sound)
    {
        AudioClip clip = buttonClick;
        if (sound == UiSound.ButtonClick)
            clip = buttonClick;

        firstSoundSource.clip = clip;
        firstSoundSource.Play();
    }
}

public enum MainSounds
{
    MainSceneBg
}

public enum UiSound
{
    ButtonClick
}
