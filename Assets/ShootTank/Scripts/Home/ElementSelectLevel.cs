using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootTank.Canvas.Home
{

    public class ElementSelectLevel : PanelBase
    {
        private int id;
        [SerializeField] private Text txtLevel;
        [SerializeField] private Image imgLevel;
        [SerializeField] private Button btnSelect;

        [Space]
        [SerializeField] private Color colorPassed;
        [SerializeField] private Color colorPlaying;
        [SerializeField] private Color colorNotPassed;

        public void Init(int _id)
        {
            id = _id;
            txtLevel.text = (id + 1).ToString();
            if ((id + 1) < VariableSystem.LevelCurrent)
                LevelPassed();
            else
            if ((id + 1) == VariableSystem.LevelCurrent)
                LevelPlaying();
            else
                LevelNotPassed();
        }
        private void LevelPassed()
        {
            imgLevel.color = colorPassed;
            btnSelect.interactable = true;
        }
        private void LevelPlaying()
        {
            imgLevel.color = colorPlaying;
            btnSelect.interactable = true;
        }
        private void LevelNotPassed()
        {
            imgLevel.color = colorNotPassed;
            btnSelect.interactable = false;
        }
        public void OnClickLevel()
        {
            if ((id + 1) <= VariableSystem.LevelCurrent)
            {
                SoundClickButton();
                VariableSystem.LevelPlaying = id + 1;
                VariableSystem.LevelTankInGame = 0;
                SceneManager.LoadScene(1);
            }
            else
            {
                SoundClickButton();
                string _str = I2.Loc.ScriptLocalization.You_need_to_pass_previous_levels_to_be_able_to_pla;
                HomeUI.instance.ShowPopupNotice(_str);
            }
        }
    }

}