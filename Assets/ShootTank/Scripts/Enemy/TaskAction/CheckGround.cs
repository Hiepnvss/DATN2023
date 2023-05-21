using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using ShootTank.Tank;
using ShootTank.Map;

public class CheckGround : Conditional
{
    public TankEnemy tankEnemy;
    public DirectMove direcCheck;
    public float distance = 0.1f;

    public bool checkTank = false;
    public bool checkElement = false;
    public bool checkWall = false;

    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (CheckGroundRoundTank())
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
    private bool CheckGroundRoundTank()
    {
        GameObject Obj = tankEnemy.tankManager.CheckGroundRoundTank(direcCheck, distance);
        if (Obj == null)
            return false;

        if (checkTank)
        {
            TankManager _tank = Obj.GetComponent<TankManager>();
            if (_tank != null)
                if (_tank != tankEnemy.tankManager)
                    return true;
            return false;
        }
        else
        if (checkElement)
        {
            ElementMap _ele = Obj.GetComponent<ElementMap>();
            if (_ele != null)
            {
                if (_ele.typeElement == TypeElement.Brick)
                    return true;
                if (_ele.typeElement == TypeElement.Stone && tankEnemy.tankManager.typeTankEnemy == TypeTankEnemy.TankStrong)
                    return true;
                return false;
            }
            return false;
        }

        if (checkWall)
        {
            ElementMap _ele = Obj.GetComponent<ElementMap>();
            if (_ele != null)
            {
                if (_ele.typeElement == TypeElement.Wall || _ele.typeElement == TypeElement.Water)
                    return true;
                if (_ele.typeElement == TypeElement.Stone && tankEnemy.tankManager.typeTankEnemy != TypeTankEnemy.TankStrong)
                    return true;
                return false;
            }
            return false;
        }

        return false;
    }
}