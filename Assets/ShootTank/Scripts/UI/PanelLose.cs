using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootTank.Canvas
{
    public class PanelLose : PanelBase
    {
        public void ShowPanel()
        {
            Show();
            VariableSystem.TankLife = 3;
        }
        public void OnClickReplay()
        {
            SoundClickButton();
            SceneManager.LoadScene(1);
        }
        public void OnClickOut()
        {
            SoundClickButton();
            SceneManager.LoadScene(0);
        }
    }
}
