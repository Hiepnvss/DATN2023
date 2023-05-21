using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour
{
    public static SoundMusicManager instance;

    private const string SOUND = "SOUND";
    private const string MUSIC = "MUSIC";
    private const string isFirstGame = "isFistGame";

    [SerializeField] AudioSource audioMusic;
    [SerializeField] AudioSource audioSound;

    [TabGroup("1", "AudioClip")] [SerializeField] AudioClip musicHome;
    [TabGroup("1", "AudioClip")] [SerializeField] AudioClip musicGame;
    [TabGroup("1", "Tank")] [SerializeField] List<AudioClip> listTankDie;

    [Space]
    [TabGroup("2", "AudioGameplay")] [SerializeField] AudioClip click;
    [TabGroup("2", "AudioGameplay")] [SerializeField] AudioClip startGame;
    [TabGroup("2", "AudioGameplay")] [SerializeField] AudioClip lose;
    [TabGroup("2", "AudioGameplay")] [SerializeField] AudioClip win;
    [TabGroup("2", "AudioGameplay")] [SerializeField] AudioClip getItem;
    [TabGroup("2", "AudioGameplay")] [SerializeField] AudioClip showItem;

    [Space]
    [TabGroup("2", "AudioEnvironment")] [SerializeField] AudioClip soundBullet;
    [TabGroup("2", "AudioEnvironment")] [SerializeField] AudioClip buzz_Brick;
    [TabGroup("2", "AudioEnvironment")] [SerializeField] AudioClip buzz_Stone;
    [TabGroup("2", "AudioEnvironment")] [SerializeField] AudioClip addCoin;
    [TabGroup("2", "AudioEnvironment")] [SerializeField] AudioClip upgradeTank;



    static bool isReadly = false;

    private void Start()
    {

        if (IsGameStartedForTheFirstTime())
        {
            SetMusic(1);
            SetSound(1);
            MusicHome();
        }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (isReadly)
        {
            Destroy(gameObject);
            return;
        }

        isReadly = true;
        DontDestroyOnLoad(this.gameObject);
    }
    // is first game

    bool IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("isFirstGame"))
        {
            PlayerPrefs.SetInt("isFirstGame", 0);
            return true;
        }
        return false;
    }


    public void MusicHome()
    {
        if (audioMusic == null)
            return;
        if (GetMusic())
        {
            audioMusic.Stop();
            audioMusic.loop = true;
            audioMusic.clip = musicHome;
            audioMusic.Play();
        }
        else
        {
            audioMusic.Stop();
        }
    }
    public void MusicGame()
    {
        if (audioMusic == null)
            return;
        if (GetMusic())
        {
            audioMusic.Stop();
            audioMusic.loop = true;
            audioMusic.clip = musicGame;
            audioMusic.Play();
        }
        else
        {
            audioMusic.Stop();
        }
    }
    // Set MUSIC

    public void SetMusic(int i)
    {
        PlayerPrefs.SetInt(MUSIC, i);
    }
    public bool GetMusic()
    {
        return PlayerPrefs.GetInt(MUSIC, 0) == 1;
    }

    // Set Sound

    public void SetSound(int i)
    {
        PlayerPrefs.SetInt(SOUND, i);
    }
    public bool GetSound()
    {
        return PlayerPrefs.GetInt(SOUND, 0) == 1;
    }

    //===================================================================
    private void PlaySound(AudioClip clip)
    {
        if (GetSound())
        {
            if (clip != null)
                audioSound.PlayOneShot(clip);
        }
    }
    public void Bullet()
    {
        PlaySound(soundBullet);
    }
    public void TankDie()
    {
        PlaySound(listTankDie[Random.Range(0, listTankDie.Count - 1)]);
    }
    public void Click()
    {
        PlaySound(click);
    }
    public void StartGame(bool isPlay = true)
    {
        if (GetSound() && isPlay)
        {
            audioSound.loop = false;
            audioSound.clip = startGame;
            audioSound.Play();
        }
        else
        {
            audioSound.loop = false;
            audioSound.Stop();
        }
    }
    public void BuzzBrick()
    {
        PlaySound(buzz_Brick);
    }
    public void BuzzStone()
    {
        PlaySound(buzz_Stone);
    }
    public void AddCoin()
    {
        PlaySound(addCoin);
    }
    public void Lose()
    {
        PlaySound(lose);
    }
    public void Win()
    {
        PlaySound(win);
    }
    public void GetItem()
    {
        PlaySound(getItem);
    } public void ShowItem()
    {
        PlaySound(showItem);
    }
    public void UpgradeTank()
    {
        PlaySound(upgradeTank);
    }
}
