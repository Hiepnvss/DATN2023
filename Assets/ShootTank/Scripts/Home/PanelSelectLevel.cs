using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Canvas.Home
{

    public class PanelSelectLevel : PanelBase
    {
        [SerializeField] private Transform parentSpawn;
        [SerializeField] private ElementSelectLevel elementSelectLevel;
        [SerializeField] private List<ElementSelectLevel> listElement = new List<ElementSelectLevel>();


        public void ShowPanel()
        {
            base.Show();
            Init();
        }
        public void HidePanel()
        {
            base.Hide();
        }

        //======================

        public void LoadElement()
        {
            for (int i = 0; i < VariableSystem.LevelMax; i++)
            {
                ElementSelectLevel _e = Instantiate(elementSelectLevel, parentSpawn);
                _e.Init(i);
            }
        }
        private void Init()
        {

        }
    }
}
