using ShootTank.Canvas.GamePlay;
using ShootTank.GameController.LevelLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootTank.Canvas
{
    public class PanelWin : PanelBase
    {
        [SerializeField] private Button btnContinue;
        [SerializeField] private Text txtCoin;
        [SerializeField] private Image imgCoin;

        private int coinGift;

        public void ShowPanel()
        {
            Show();

            VariableSystem.LevelPlaying++;

            if (VariableSystem.LevelPlaying > VariableSystem.LevelCurrent)
                VariableSystem.LevelCurrent++;

            coinGift = LevelLoader.instance.map.coinGift;
            txtCoin.text = coinGift.ToString();
            btnContinue.gameObject.SetActive(true);

            AddCoin();
        }
        private void AddCoin()
        {

            VariableSystem.StoreCoin += LevelLoader.instance.map.coinGift;

            Vector3 _posSpawn = imgCoin.GetComponent<RectTransform>().anchoredPosition;
            Vector2 _size = imgCoin.GetComponent<RectTransform>().sizeDelta;

            float[] rangePos = new float[] { 40, 40 };
            ControlCanvas.instance.storeCoin.SpawnCoinRandomPosition(_posSpawn, imgCoin.transform, rangePos, _size, coinGift, 5, 1, 0.1f, true);
        }
        public void OnClickContinue()
        {
            SoundClickButton();

            if (VariableSystem.LevelPlaying > VariableSystem.LevelMax)
            {
                VariableSystem.LevelPlaying = VariableSystem.LevelMax;
                VariableSystem.LevelCurrent = VariableSystem.LevelMax;
                SceneManager.LoadScene(0);
            }
            else
                SceneManager.LoadScene(1);
        }
        public void OnClickBackHome()
        {
            SoundClickButton();
            SceneManager.LoadScene(0);
        }
    }
}
