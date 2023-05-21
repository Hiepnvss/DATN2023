using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShootTank.Canvas.Home
{
    public class PopupNotResource : PanelBase
    {
        [SerializeField] private Text txtNotice;

        public void ShowPanel(string _content, bool isUpperText = false)
        {
            if (isUpperText)
                _content = _content.ToUpper();
            txtNotice.text = _content;
            base.Show();
        }
        public void HidePanel()
        {
            SoundClickButton();
            base.Hide();
        }
    }

}