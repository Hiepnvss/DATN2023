using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections.Generic;
using System.Linq;
using ShootTank.GameController;

public class TaskChangeDirection : Action
{
    public TankEnemy tankEnemy;
    public override void OnStart()
    {

    }

    public override TaskStatus OnUpdate()
    {
        if (GamePlayController.instance.stateGame != StateGame.Playing) return TaskStatus.Failure;
        if (RandomDicMoveTank())
            return TaskStatus.Success;
        return TaskStatus.Failure;
    }
    private bool RandomDicMoveTank()
    {
        int _dic = (int)tankEnemy.tankManager.tankMove.direct;
        Debug.Log("_dic current = " + tankEnemy.tankManager.tankMove.direct);
        int[] _arr = new int[4] { 1, 2, 3, 4 };

        List<int> _l = _arr.ToList();

        _l.Remove(_dic);

        tankEnemy.tankManager.tankMove.direct = (DirectMove)_l[Random.Range(0, _l.Count)];
        _dic = (int)tankEnemy.tankManager.tankMove.direct;
        Debug.Log("_dic new = " + tankEnemy.tankManager.tankMove.direct);
        return true;
    }
}