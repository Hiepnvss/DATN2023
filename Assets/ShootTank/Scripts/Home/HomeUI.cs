using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ShootTank.Data;

namespace ShootTank.Canvas.Home
{
    public class HomeUI : PanelBase
    {
        public static HomeUI instance;

        [TabGroup("1", "PANEL")] [SerializeField] PanelConfirmExit panelConfirmExit = null;
        [TabGroup("1", "PANEL")] [SerializeField] PanelSetting panelSetting = null;
        [TabGroup("1", "PANEL")] [SerializeField] PanelUpgradeTank panelUpgradeTank = null;
        [TabGroup("1", "PANEL")] [SerializeField] PanelHack panelHack = null;
        [TabGroup("1", "PANEL")] [SerializeField] PanelSelectLevel panelSelectLevel = null;

        [TabGroup("1", "POPUP")] [SerializeField] PopupNotResource popupNotResource = null;
        [TabGroup("1", "POPUP")] public PopupNotice popupNotice = null;

        public StoreCoin storeCoin;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            LoadElement();
        }

        /// <summary>
        /// Load Element First
        /// </summary>
        private void LoadElement()
        {
            panelSelectLevel?.LoadElement();
        }
        #region [ Action Click ]

        /// <summary>
        /// Quit Game
        /// </summary>
        public void OnClickExit()
        {
            SoundMusicManager.instance.Click();
            panelConfirmExit?.Show();
        }

        /// <summary>
        /// Click play now
        /// </summary>
        public void OnClickPlayNow()
        {
            SoundClickButton();
            ShowPanelSelectLevel();
        }

        /// <summary>
        /// Click funct Setting
        /// </summary>
        public void OnClickSetting()
        {
            SoundMusicManager.instance.Click();
            panelSetting?.ShowPanel();
        }

        /// <summary>
        /// Click funct Upgrade Tank
        /// </summary>
        public void OnClickUpgradeTank()
        {
            SoundClickButton();
            panelUpgradeTank?.ShowPanel();
        }
        /// <summary>
        /// Click funct Hack
        /// </summary>
        public void OnClickShowHack()
        {
            SoundClickButton();
            panelHack?.ShowPanel();
        }

        #endregion

        #region [ Call Funct ]

        public void ShowPopupNotice(string _str = "")
        {
            popupNotice.ShowPanel(_str);
        }

        public void ShowPanelSelectLevel()
        {
            panelSelectLevel?.ShowPanel();
        }

        public void ShowPopupNotResource(string _strNoti, bool isUpper = false)
        {
            popupNotResource?.ShowPanel(_strNoti, isUpper);
        }

        #endregion
    }
}
