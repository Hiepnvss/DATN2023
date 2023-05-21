using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShootTank.GameController;
using ShootTank.Tank;

public class SpawnPlayer : MonoBehaviour
{
    public TankManager playerPrefabs;

    public Transform posSpawn;
    public List<Vector3> listPosSpawnTankEnemy;
    [HideInInspector] public TankManager _Player;
    void Start()
    {
        SpawnPlayer_();
        SpawnEnemyBegin();
    }
    public void SpawnPlayer_()
    {
        _Player = Instantiate(playerPrefabs, posSpawn.position, Quaternion.identity);
        _Player.InitInfor(TypeEntity.Tank, TypeTank.TankMain);

        GamePlayController.instance.levelLoader.SetTankManager(_Player);
    }
    private void SpawnEnemyBegin()
    {
        TankManager _t;

        _t = Instantiate(playerPrefabs, listPosSpawnTankEnemy[0], Quaternion.identity);
        _t.InitInfor(TypeEntity.Tank, TypeTank.TankEnemy);
        _t.transform.parent = transform;
        _t.transform.rotation = Quaternion.Euler(0, 0, 180);

        _t = Instantiate(playerPrefabs, listPosSpawnTankEnemy[1], Quaternion.identity);
        _t.InitInfor(TypeEntity.Tank, TypeTank.TankEnemy);
        _t.transform.parent = transform;
        _t.transform.rotation = Quaternion.Euler(0, 0, 180);

        _t = Instantiate(playerPrefabs, listPosSpawnTankEnemy[2], Quaternion.identity);
        _t.InitInfor(TypeEntity.Tank, TypeTank.TankEnemy);
        _t.transform.parent = transform;
        _t.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
   
    public void SpawnTankEnemy()
    {
        TankManager _t;

        _t = Instantiate(playerPrefabs, listPosSpawnTankEnemy[Random.Range(0, 3)], Quaternion.identity);
        _t.InitInfor(TypeEntity.Tank, TypeTank.TankEnemy);
        _t.transform.parent = transform;
        _t.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
}
