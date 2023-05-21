using I2.Loc;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootTank.Canvas.Home
{
    public class PanelSetting : PanelBase
    {
        [SerializeField] Sprite sprOn;
        [SerializeField] Sprite sprOff;
        [SerializeField] Button btnSound;
        [SerializeField] Button btnMusic;
        [SerializeField] Dropdown dropLanguage;

        [TabGroup("FirstGroup", "UI")] [SerializeField] Button TankGreen;
        [TabGroup("FirstGroup", "UI")] [SerializeField] Button TankYellow;
        [TabGroup("FirstGroup", "UI")] [SerializeField] Button TankRed;

        bool isSound = false;
        bool isMusic = false;
        public void ShowPanel()
        {
            Show();
            isSound = SoundMusicManager.instance.GetSound();
            isMusic = SoundMusicManager.instance.GetMusic();
            btnSound.image.sprite = SoundMusicManager.instance.GetSound() ? sprOn : sprOff;
            btnMusic.image.sprite = SoundMusicManager.instance.GetMusic() ? sprOn : sprOff;
            OnClickTankColor(VariableSystem.TankColor);


        }

        public void OnClickOnOff()
        {
            SoundClickButton();
            isSound = !isSound;
            if (!isSound)
            {
                btnSound.image.sprite = sprOff;
                SoundMusicManager.instance.SetSound(0);
            }
            else
            {
                btnSound.image.sprite = sprOn;
                SoundMusicManager.instance.SetSound(1);
            }
        }
        public void OnClickOnOffMusic()
        {
            SoundClickButton();
            isMusic = !isMusic;
            if (!isMusic)
            {
                btnMusic.image.sprite = sprOff;
                SoundMusicManager.instance.SetMusic(0);
            }
            else
            {
                btnMusic.image.sprite = sprOn;
                SoundMusicManager.instance.SetMusic(1);
            }
        }
        public void OnClickTankColor(int index)
        {
            SoundClickButton();
            VariableSystem.TankColor = index;
            switch (index)
            {
                case 0:
                    TankGreen.image.enabled = true;
                    TankYellow.image.enabled = false;
                    TankRed.image.enabled = false;
                    break;
                case 1:
                    TankGreen.image.enabled = false;
                    TankYellow.image.enabled = true;
                    TankRed.image.enabled = false;
                    break;
                case 2:
                    TankGreen.image.enabled = false;
                    TankYellow.image.enabled = false;
                    TankRed.image.enabled = true;
                    break;
            }
        }
        public void ButtonChangeVibrate()
        {
            SoundClickButton();
            VariableSystem.Vibrate = !VariableSystem.Vibrate;
            //if (VariableSystem.Vibrate)
            //    ActionHelper.SetVibration(200, 100);
            //Config();
        }
        public void OnChangeLanguage()
        {
            SoundClickButton();
            int id = dropLanguage.value;
            LocalizationManager.CurrentLanguage = LocalizationManager.GetAllLanguages()[id];
        }
       
        public void OnClickExit()
        {
            SoundClickButton();
            Hide();
        }
    }
}