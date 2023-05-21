using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Canvas.GamePlay
{

    public class PanelPause : PanelBase
    {
        public void ShowPanel()
        {
            Time.timeScale = 0;
            base.Show();
        }
        public void OnClickHide()
        {
            SoundClickButton();
            Time.timeScale = 1;
            base.Hide();
        }
    }

}