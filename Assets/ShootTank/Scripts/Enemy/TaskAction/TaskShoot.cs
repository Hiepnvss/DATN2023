using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using ShootTank.GameController;

public class TaskShoot : Action
{
    public TankEnemy tankEnemy;
    public bool isShoot = false;
    public float timeShoot = 3;
    public float countTime = 0;
    public override void OnStart()
    {
        isShoot = true;
        countTime = 0;
    }

    public override TaskStatus OnUpdate()
    {
        if (GamePlayController.instance.stateGame != StateGame.Playing) return TaskStatus.Failure;
        if (isShoot)
        {
            countTime += Time.deltaTime;
            if (countTime >= timeShoot)
            {
                isShoot = false;
                return TaskStatus.Success;
            }
            Shoot();
            return TaskStatus.Running;
        }
        return TaskStatus.Failure;
    }
    private void Shoot()
    {
        tankEnemy.tankManager.tankShoot.OnShoot();
    }
}