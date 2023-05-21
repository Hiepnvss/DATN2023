using ShootTank.GameController.LevelLoad;
using Script.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootTank.Tank;
using ShootTank.Item;

public enum StateGame
{
    Win,
    Lose,
    Playing
}

namespace ShootTank.GameController
{
    public class GamePlayController : MonoBehaviour
    {
        public static GamePlayController instance;

        public SpawnPlayer _spawnPlayer;
        public LevelLoader levelLoader;
        public StateGame stateGame;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            SoundMusicManager.instance.StartGame(true);
            stateGame = StateGame.Playing;
            RandomItem();
        }

        #region [CONTROL]
        public void OnShoot()
        {
            _spawnPlayer._Player.tankShoot.OnShoot();
        }
        public void OnClickTop(bool isMove)
        {
            _spawnPlayer._Player.tankMove.MoveTop = isMove;
        }
        public void OnClickDown(bool isMove)
        {
            _spawnPlayer._Player.tankMove.MoveDown = isMove;
        }
        public void OnClickLeft(bool isMove)
        {
            _spawnPlayer._Player.tankMove.MoveLeft = isMove;
        }
        public void OnClickRight(bool isMove)
        {
            _spawnPlayer._Player.tankMove.MoveRight = isMove;
        }
        public void PowerBullet()
        {
            VariableSystem.isPowerBullet = true;
            Invoke(nameof(Off_PowerBullet), 5);
        }
        #endregion

        void Off_PowerBullet()
        {
            VariableSystem.isPowerBullet = false;
        }
        public void LoadLevelLoader()
        {
            levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        }

        #region [ Random Item Support ]

        public float timeRandom = 5;

        [HideInInspector] public SupportItem supportItem = null;
        public SupportItem supportItemSpawn = null;

        private IEnumerator IE_RANDOM;
        private IEnumerator IE_Random()
        {
            yield return new WaitForSeconds(timeRandom);

            Vector2 posRandom = new(Random.Range(-4, 4), Random.Range(-4, 4));
            SoundMusicManager.instance.ShowItem();
            supportItem = Instantiate(supportItemSpawn, posRandom, Quaternion.identity);
        }

        public void RandomItem()
        {
            timeRandom = Random.Range(5.0f, 10.0f);

            IE_RANDOM = IE_Random();
            StartCoroutine(IE_RANDOM);
        }

        #endregion
    }
}
