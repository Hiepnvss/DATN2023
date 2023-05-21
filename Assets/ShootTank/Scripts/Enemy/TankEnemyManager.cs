using ShootTank.Canvas.GamePlay;
using ShootTank.GameController;
using ShootTank.GameController.LevelLoad;
using UnityEngine;

namespace ShootTank.Tank
{
    public class TankEnemyManager : EntityManager
    {
        public TankManager tankManager;

        bool isResetMove = true;


        private void Update()
        {
            GetDirecMove();
        }
        private void GetDirecMove()
        {
            GameObject _objTop = CheckTop();
            GameObject _objDown = CheckDown();
            GameObject _objLeft = CheckLeft();
            GameObject _objRight = CheckRight();

            if (_objTop == null)
            {
                if (_objDown == null)
                {
                    if (_objLeft == null)
                    {
                        if (_objRight == null)
                        {
                            if (isResetMove)
                                Movement(DirectMove.Down, 2);
                        }
                        else
                        {
                            // check type gameobject
                            // shoot
                        }
                    }
                    else
                    {
                        // check type gameobject
                        // shoot
                    }
                }
                else
                {
                    // check type gameobject
                    // shoot
                }
            }
            else
            {
                // check type gameobject
                // shoot
            }
        }
        private GameObject CheckTop()
        {
            return tankManager.CheckGroundRoundTank(DirectMove.Top, 0.1f);
        }
        private GameObject CheckDown()
        {
            return tankManager.CheckGroundRoundTank(DirectMove.Down, 0.1f);
        }
        private GameObject CheckLeft()
        {
            return tankManager.CheckGroundRoundTank(DirectMove.Left, 0.1f);
        }
        private GameObject CheckRight()
        {
            return tankManager.CheckGroundRoundTank(DirectMove.Right, 0.1f);
        }
        private void Movement(DirectMove directMove, float timeMove)
        {
            isResetMove = false;
            tankManager.tankMove.direct = directMove;
            tankManager.tankMove.isMove = true;
            StartCoroutine(ActionHelper.StartAction(() =>
            {
                isResetMove = true;
                tankManager.tankMove.isMove = false;
            }, timeMove));

        }
        private void Shoot()
        {

        }
    }
}
