using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ShootTank.GameController.LevelLoad;
using ShootTank.GameController;
using ShootTank.Data;

namespace ShootTank.Canvas.GamePlay
{
    public class ControlCanvas : MonoBehaviour
    {
        public static ControlCanvas instance;

        [TabGroup("1", "Panel")] [SerializeField] PanelWin panelWin;
        [TabGroup("1", "Panel")] [SerializeField] PanelLose panelLose;
        [TabGroup("1", "Panel")] [SerializeField] PanelPause panelPause;
        [TabGroup("1", "Panel")] public StoreCoin storeCoin;

        [TabGroup("1", "UIGamePlay")] public Button btnBackHome;
        [TabGroup("1", "UIGamePlay")] public Button btnShoot;
        [TabGroup("1", "UIGamePlay")] public Button btnPower;
        [TabGroup("1", "UIGamePlay")] public Text txtAmountTankEnemy;
        [TabGroup("1", "UIGamePlay")] public Text txtLevel;
        [TabGroup("1", "UIGamePlay")] public Image imgTank;
        [TabGroup("1", "UIGamePlay")] public Text txtTankLife;

        [SerializeField] List<Sprite> listSprTank = new List<Sprite>();

        private int amountTankEnemy;
        private int countTankEnemySpawned;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        private void Start()
        {
            txtLevel.text = I2.Loc.ScriptLocalization.Level + " " + VariableSystem.LevelPlaying;
            amountTankEnemy = LevelLoader.instance.map.amountTankEnemy;
            countTankEnemySpawned = 3;
            imgTank.sprite = listSprTank[VariableSystem.TankColor];
            txtTankLife.text = VariableSystem.TankLife.ToString();
        }
        public void OnClickPause()
        {
            SoundMusicManager.instance.Click();
            panelPause.ShowPanel();
        }
        public void OnClickHome()
        {
            SoundMusicManager.instance.StartGame(false);
            SceneManager.LoadSceneAsync("HomeScene");
        }
        public void OnClickReset()
        {
            SoundMusicManager.instance.StartGame(false);
            SceneManager.LoadSceneAsync("GamePlayScene");
        }
        public void ShowLose()
        {
            btnBackHome.gameObject.SetActive(false);
            GamePlayController.instance.stateGame = StateGame.Lose;
            StartCoroutine(ActionHelper.StartAction(() =>
            {
                panelLose.ShowPanel();
            }, 1));
        }
        public void ShowWin()
        {
            storeCoin.gameObject.SetActive(true);
            btnBackHome.gameObject.SetActive(false);
            GamePlayController.instance.stateGame = StateGame.Win;
            StartCoroutine(ActionHelper.StartAction(() =>
            {
                panelWin.ShowPanel();
            }, 1));
        }

        public void RefreshTankLife(TypeTank typeTank)
        {
            if (typeTank == TypeTank.TankMain)
            {
                VariableSystem.LevelTankInGame -= 2;
                VariableSystem.TankLife--;

                if (VariableSystem.TankLife <= -1)
                {
                    btnShoot.interactable = false;
                    ShowLose();
                }
                else
                {
                    btnShoot.interactable = true;
                    GamePlayController.instance._spawnPlayer.SpawnPlayer_();
                    txtTankLife.text = VariableSystem.TankLife.ToString();
                }
            }
            else
            {
                amountTankEnemy--;
                txtAmountTankEnemy.text = amountTankEnemy + "";
                if (amountTankEnemy <= 0)
                {
                    if (countTankEnemySpawned >= LevelInfor.instance.amountTankEnemy)
                    {
                        ShowWin();
                        return;
                    }
                }
                else
                {

                    if (countTankEnemySpawned < LevelInfor.instance.amountTankEnemy)
                    {
                        GamePlayController.instance._spawnPlayer.SpawnTankEnemy();
                        countTankEnemySpawned++;
                    }
                }
            }
        }

    }
}
