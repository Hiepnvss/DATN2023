using ShootTank.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Item
{

public class ItemStar : SupportItem
{
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            TankManager t = collision.gameObject.GetComponent<TankManager>();
            if (t != null)
            {
                if (t.typeTank == TypeTank.TankMain)
                {
                    SoundMusicManager.instance.GetItem();
                    t.UpgradeTank();
                }
            }
            base.OnTriggerEnter2D(collision);
        }
    }

}