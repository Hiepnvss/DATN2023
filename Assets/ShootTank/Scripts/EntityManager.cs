using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using ShootTank.Tank;
using ShootTank.GameController;
using ShootTank.Map;
using ShootTank.Canvas.GamePlay;

public enum TypeEntity
{
    Tank,
    Bullet,
    Main
}
public enum TypeTank
{
    TankMain,
    TankEnemy
}
public enum TypeTankEnemy
{
    TankNormal,
    TankSpeed,
    TankStrong,
    TankSmart
}
public class EntityManager : MonoBehaviour
{
    public TypeEntity typeEntity;
    public TypeTank typeTank;

    [ShowIf("typeTank", TypeTank.TankEnemy)] public TypeTankEnemy typeTankEnemy;

    public void InitInfor(TypeEntity typeEntity, TypeTank typeTank, TypeTankEnemy typeTankEnemy = TypeTankEnemy.TankNormal)
    {
        this.typeEntity = typeEntity;
        this.typeTank = typeTank;
        this.typeTankEnemy = typeTankEnemy;

        //if (typeTank == TypeTank.TankEnemy && typeEntity == TypeEntity.Tank)
        //{
        //    gameObject.AddComponent<TankEnemyManager>().tankManager = (TankManager)this;
        //}
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (typeEntity == TypeEntity.Bullet)
        {
            if (collision.gameObject.GetComponent<Main>() != null)
            {
                ActionHelper.SetVibration(100, 50);
                GamePlayController.instance.stateGame = StateGame.Lose;
                ControlCanvas.instance.ShowLose();

                collision.gameObject.GetComponent<TankEffect>().PlayEffectTankDie();


                Destroy(collision.gameObject);
                Destroy(gameObject);
                return;
            }

            EntityManager _entity = collision.gameObject.GetComponent<EntityManager>();

            if (_entity != null)
            {
                if (_entity.typeEntity == TypeEntity.Tank)
                {
                    if (_entity.typeTank != typeTank)
                    {
                        // effect tank die
                        ActionHelper.SetVibration(30, 30);

                        ControlCanvas.instance.RefreshTankLife(_entity.typeTank);
                        TankManager _tank = (TankManager)_entity;

                        _tank.tankEffect.PlayEffectTankDie();

                        SoundMusicManager.instance.TankDie();

                        Destroy(_entity.gameObject);
                        Destroy(gameObject);
                    }
                }
                if (_entity.typeEntity == TypeEntity.Bullet)
                {
                    // effect bullet vs bullet

                    Destroy(_entity.gameObject);
                    Destroy(gameObject);
                }
            }

            ElementMap _ele = collision.gameObject.GetComponent<ElementMap>();
            if (_ele != null)
            {
                switch (_ele.typeElement)
                {
                    case TypeElement.Brick:

                        // effect bullet vs brick
                        SoundMusicManager.instance.BuzzBrick();


                        Destroy(_ele.gameObject);
                        Destroy(gameObject);
                        break;
                    case TypeElement.Stone:

                        // effect bullet vs stone
                        SoundMusicManager.instance.BuzzStone();

                        if (VariableSystem.LevelTankInGame == 4)
                            Destroy(_ele.gameObject);
                        Destroy(gameObject);
                        break;

                    case TypeElement.Wall:

                        // effect bullet vs wall
                        SoundMusicManager.instance.BuzzStone();

                        Destroy(gameObject);
                        break;

                }
            }

        }
        if (typeEntity == TypeEntity.Tank)
        {

        }
    }
}
