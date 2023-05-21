using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using ShootTank.Tank;

public class TankEnemy : Action
{
	public TankManager tankManager;
	public StopBehaviorTree stopBehaviorTree;

	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}