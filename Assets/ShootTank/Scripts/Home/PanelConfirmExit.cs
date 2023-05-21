using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Canvas.Home
{
    public class PanelConfirmExit : PanelBase
    {
        public void OnClickYes()
        {
            SoundClickButton();

            if (ActionHelper.IsEditor())
            {

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else
                Application.Quit();

            Hide();
        }
        public void OnClickNo()
        {
            SoundClickButton();
            Hide();
        }
    }
}