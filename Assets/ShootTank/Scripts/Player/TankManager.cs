using ShootTank.Canvas.GamePlay;
using Sirenix.OdinInspector;
using UnityEngine;
using ShootTank.GameController;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;

namespace ShootTank.Tank
{
    public class TankManager : EntityManager
    {
        [TabGroup("First", ("Tank"))] public BehaviorTree behaviorTree;
        [TabGroup("First", ("Tank"))] public TankShoot tankShoot;
        [TabGroup("First", ("Tank"))] public TankMove tankMove;
        [TabGroup("First", ("Tank"))] public TankEffect tankEffect;
        [TabGroup("First", ("Tank"))] public SpriteRenderer sprTank;
        [TabGroup("First", ("Tank"))] public LayerMask layerRaycast;
        [TabGroup("First", ("Tank"))] public DirectMove directMove;


        [TabGroup("First", ("Sprite"))] [SerializeField] List<Sprite> listSprTankGreen = new List<Sprite>();
        [TabGroup("First", ("Sprite"))] [SerializeField] List<Sprite> listSprTankYellow = new List<Sprite>();
        [TabGroup("First", ("Sprite"))] [SerializeField] List<Sprite> listSprTankRed = new List<Sprite>();
        [TabGroup("First", ("Sprite"))] [SerializeField] List<Sprite> listSprTankEnemy = new List<Sprite>();

        private void Awake()
        {
        }

        private void Start()
        {
            ControlCanvas.instance.btnShoot.interactable = true;
            ControlCanvas.instance.btnPower.interactable = true;

            if (typeTank == TypeTank.TankMain)
            {
                switch (VariableSystem.TankColor)
                {
                    case 0:
                        sprTank.sprite = listSprTankGreen[0];
                        break;
                    case 1:
                        sprTank.sprite = listSprTankYellow[0];
                        break;
                    case 2:
                        sprTank.sprite = listSprTankRed[0];
                        break;
                }
                VariableSystem.LevelTankInGame = 0;
                tankShoot.ChangeTimeReload();
                switch (VariableSystem.TankColor)
                {
                    case 0:
                        sprTank.sprite = listSprTankGreen[VariableSystem.LevelTankInGame];
                        break;
                    case 1:
                        sprTank.sprite = listSprTankYellow[VariableSystem.LevelTankInGame];
                        break;
                    case 2:
                        sprTank.sprite = listSprTankRed[VariableSystem.LevelTankInGame];
                        break;
                }
            }
            if (typeTank == TypeTank.TankEnemy)
            {
                int _rd = Random.Range(0, listSprTankEnemy.Count);

                sprTank.sprite = listSprTankEnemy[_rd];
                behaviorTree.enabled = true;
                behaviorTree.FindTask<TankEnemy>().tankManager = this;
                behaviorTree.StartWhenEnabled = true;
                behaviorTree.EnableBehavior();
                ConfigSpeedTankEnemy(_rd);
            }
        }
        private void ConfigSpeedTankEnemy(int rd)
        {
            float speedPlus = VariableSystem.LevelPlaying * 0.2f;
            tankMove.speed = 0.5f;

            if (rd == 1)
                tankMove.speed = 1.5f;
            if (rd == 3)
                tankMove.speed = 1f;

            tankMove.speed += speedPlus;
        }
        public void UpgradeTank()
        {
            VariableSystem.LevelTankInGame++;
            tankShoot.ChangeTimeReload();
            switch (VariableSystem.TankColor)
            {
                case 0:
                    sprTank.sprite = listSprTankGreen[VariableSystem.LevelTankInGame];
                    break;
                case 1:
                    sprTank.sprite = listSprTankYellow[VariableSystem.LevelTankInGame];
                    break;
                case 2:
                    sprTank.sprite = listSprTankRed[VariableSystem.LevelTankInGame];
                    break;
            }
        }
        /// <summary>
        /// return gameObject when raycast != null
        /// </summary>
        /// <param name="direc"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public GameObject CheckGroundRoundTank(DirectMove direc, float distance)
        {
            Vector2 pos = transform.position;

            BoxCollider2D box = GetComponent<BoxCollider2D>();

            RaycastHit2D hit = Physics2D.BoxCast(transform.position, box.size, 0, new Vector2(0, 0), distance, layerRaycast);

            //RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, distance, layerRaycast);

            switch (direc)
            {
                case DirectMove.Top:
                    //   hit = Physics2D.Raycast(pos, Vector2.up, distance, layerRaycast);
                    hit = Physics2D.BoxCast(transform.position, box.size, 0, Vector2.up, distance, layerRaycast);
                    break;
                case DirectMove.Down:
                    //hit = Physics2D.Raycast(pos, Vector2.down, 180, distance, layerRaycast);
                    hit = Physics2D.BoxCast(transform.position, box.size, 0, Vector2.down, distance, layerRaycast);
                    break;
                case DirectMove.Left:
                    //hit = Physics2D.Raycast(pos, Vector2.left, -90, distance, layerRaycast);
                    hit = Physics2D.BoxCast(transform.position, box.size, 0, Vector2.left, distance, layerRaycast);
                    break;
                case DirectMove.Right:
                    //hit = Physics2D.Raycast(pos, Vector2.right, distance, layerRaycast);
                    hit = Physics2D.BoxCast(transform.position, box.size, 0, Vector2.right, distance, layerRaycast);
                    break;
            }

            if (hit.collider == null)
                return null;

            return hit.collider.gameObject;
        }
    }
}
