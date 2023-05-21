using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootTank.Canvas.Home
{

    public class PanelHack : PanelBase
    {
        public void ShowPanel()
        {
            base.Show();
        }
        public void OnClickCoin()
        {
            VariableSystem.StoreCoin += 500;
            HomeUI.instance.storeCoin.InitCoin();
        }
        public void OnClickFullSpeedTank()
        {
            SoundClickButton();
            VariableSystem.TankSpeed = 5;
        }
        public void OnClickFullSpeedBulletTank()
        {
            SoundClickButton();
            VariableSystem.BulletSpeed = 7;
        }
        public void OnClickFullUpgrade()
        {
            VariableSystem.TankSpeed = 5;
            VariableSystem.BulletSpeed = 7;
        }
        public void OnClickResetUpgrade()
        {
            VariableSystem.TankSpeed = 1;
            VariableSystem.BulletSpeed = 2;
        }
        public void HidePanel()
        {
            SceneManager.LoadScene(0);
            base.Hide();
        }
    }
}