using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using ShootTank.GameController;
using System.Collections.Generic;
using System.Linq;
using ShootTank.Map;
using ShootTank.Tank;

public class TaskMovement : Action
{
    public TankEnemy tankEnemy;
    public DirectMove direcMove;

    public bool isMove = false;
    public bool isRandomMove = false;

    public float timeMove = 3;
    public float coumtTime = 0;

    public override void OnStart()
    {
        isMove = true;
        coumtTime = 0;

        if (isRandomMove)
        {
            int _dic = (int)tankEnemy.tankManager.tankMove.direct;
            int[] _arr = new int[4] { 1, 2, 3, 4 };

            List<int> _l = _arr.ToList();
            _l.Remove(_dic);

            direcMove = (DirectMove)_l[Random.Range(0, _l.Count)];
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (GamePlayController.instance.stateGame != StateGame.Playing) return TaskStatus.Failure;
        if (isMove)
        {
            coumtTime += Time.deltaTime;
            if (coumtTime >= timeMove)
            {
                isMove = false;
                StopMove();
                return TaskStatus.Success;
            }
            Movement();
            return TaskStatus.Running;
        }
        StopMove();
        return TaskStatus.Failure;
    }
    private void Movement()
    {
        CheckWall();
        tankEnemy.tankManager.tankMove.direct = direcMove;
        tankEnemy.tankManager.tankMove.isMove = true;
    }
    private void StopMove()
    {
        tankEnemy.tankManager.tankMove.direct = DirectMove.None;
        tankEnemy.tankManager.tankMove.isMove = false;
    }
    private bool CheckWall()
    {
        GameObject Obj = tankEnemy.tankManager.CheckGroundRoundTank(direcMove, 0.1f);


        if (Obj != null)
        {
            if (Obj.GetComponent<ElementMap>() != null)
                if (Obj.GetComponent<ElementMap>().typeElement == TypeElement.Wall)
                {
                    ChangeDirec();
                    return true;
                }
            TankManager tank = null;
            tank = Obj.GetComponent<TankManager>();
            if (tank != null)
            {
                if (tank.typeEntity == tankEnemy.tankManager.typeEntity && tank != tankEnemy.tankManager)
                    RandomDicMoveTank();

            }
        }
        return false;
    }
    private void ChangeDirec()
    {
        switch (direcMove)
        {
            case DirectMove.Top:
                direcMove = DirectMove.Down;
                break;
            case DirectMove.Down:
                direcMove = DirectMove.Top;
                break;
            case DirectMove.Left:
                direcMove = DirectMove.Right;
                break;
            case DirectMove.Right:
                direcMove = DirectMove.Left;
                break;
        }
    }
    private void RandomDicMoveTank()
    {
        int _dic = (int)tankEnemy.tankManager.tankMove.direct;

        int[] _arr = new int[4] { 1, 2, 3, 4 };

        List<int> _l = _arr.ToList();

        _l.Remove(_dic);

        tankEnemy.tankManager.tankMove.direct = (DirectMove)_l[Random.Range(0, _l.Count)];
    }
}