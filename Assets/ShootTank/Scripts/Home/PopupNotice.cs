using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootTank.Canvas.Home
{
    public class PopupNotice : PanelBase
    {
        [SerializeField] private Text txtContent;

        public void ShowPanel(string _strContent)
        {
            base.Show();
            txtContent.text = _strContent;
        }
        public void OnClickGotIt()
        {
            SoundClickButton();
            base.Hide();
        }
    }
}