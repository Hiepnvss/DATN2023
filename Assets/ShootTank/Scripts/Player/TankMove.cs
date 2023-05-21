using ShootTank.BuildMap;
using ShootTank.GameController;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectMove : byte
{
    None = 0,
    Top = 1,
    Down = 2,
    Left = 3,
    Right = 4,
}
namespace ShootTank.Tank
{
    public class TankMove : MonoBehaviour
    {
        [SerializeField] private TankManager tankManager;
        [SerializeField] private LayerMask layerMAP;

        public bool isMove = false;
        public float speed = 1f;

        public bool MoveTop = false;
        public bool MoveDown = false;
        public bool MoveLeft = false;
        public bool MoveRight = false;

        public DirectMove direct;
        private void Start()
        {
            direct = DirectMove.None;
            if (tankManager.typeTank == TypeTank.TankEnemy)
                direct = (DirectMove)(UnityEngine.Random.Range(2, 5));
            else
                speed = VariableSystem.TankSpeed;
        }
        void Update()
        {
            if (GamePlayController.instance.stateGame != StateGame.Playing) return;

            Vector2 raycastDirect = Vector2.zero;


            if (tankManager.typeTank == TypeTank.TankEnemy)
            {

            }
            else
            {
                direct = DirectMove.None;
                if (Input.GetKey(KeyCode.W) || MoveTop)
                {
                    raycastDirect = Vector2.up;
                    direct = DirectMove.Top;
                }
                else if (Input.GetKey(KeyCode.S) || MoveDown)
                {
                    raycastDirect = Vector2.down;
                    direct = DirectMove.Down;
                }
                else if (Input.GetKey(KeyCode.D) || MoveRight)
                {
                    raycastDirect = Vector2.right;
                    direct = DirectMove.Right;
                    Debug.Log("????");
                }
                else if (Input.GetKey(KeyCode.A) || MoveLeft)
                {
                    raycastDirect = Vector2.left;
                    direct = DirectMove.Left;
                }
            }

            float deltaMove = Time.deltaTime * speed;

            //BoxCollider2D box = GetComponent<BoxCollider2D>();
            //RaycastHit2D hit = Physics2D.BoxCast(transform.position, box.size, 0, raycastDirect, deltaMove, layerMAP);
            //if (hit.collider != null)
            //{
            //    deltaMove = hit.distance;
            //    if (deltaMove <= 0.2f)
            //        return;
            //}

            switch (direct)
            {
                case DirectMove.Top:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    //transform.position = new Vector3(transform.position.x, transform.position.y + deltaMove, 0);
                    break;
                case DirectMove.Down:
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    //transform.position = new Vector3(transform.position.x, transform.position.y + deltaMove * -1, 0);
                    break;
                case DirectMove.Right:
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    //  transform.position = new Vector3(transform.position.x + deltaMove, transform.position.y, 0);
                    break;
                case DirectMove.Left:
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    //   transform.position = new Vector3(transform.position.x + deltaMove * -1, transform.position.y, 0);
                    break;
                default:
                    break;
            }
            if (direct != DirectMove.None)
                transform.Translate(0, deltaMove, 0);
        }
    }
}
