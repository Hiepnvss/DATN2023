using ShootTank.Canvas.GamePlay;
using System.Collections.Generic;
using UnityEngine;
using ShootTank.Tank;


namespace ShootTank.GameController.LevelLoad
{
    public class LevelInfor : MonoBehaviour
    {
        public static LevelInfor instance;

        public TankManager tankManager;
        public int amountTankEnemy = 20;
        public int coinGift = 50;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            tankManager = GamePlayController.instance._spawnPlayer._Player;
            ControlCanvas.instance.txtAmountTankEnemy.text = amountTankEnemy + "";
        }
    }
}
