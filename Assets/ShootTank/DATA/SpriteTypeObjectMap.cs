using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.Data.Map
{
    [CreateAssetMenu]
    public class SpriteTypeObjectMap : ScriptableObject
    {
        private static readonly ResourceAsset<SpriteTypeObjectMap> asset = new ResourceAsset<SpriteTypeObjectMap>("Object/SpriteTypeObjectMap");

        public ScriptableSpriteMapConfig[] ScriptableSpriteMapConfig;

        private static ScriptableSpriteMapConfig GetSpriteMap(int index)
        {
            return asset.Value.ScriptableSpriteMapConfig[index];
        }

        public static List<Sprite> GetListSpriteMap(int index)
        {
            return asset.Value.ScriptableSpriteMapConfig[index].listSpritesObjectMap;
        }
        public static List<GameObject> GetListGameObjectMap(int index)
        {
            return asset.Value.ScriptableSpriteMapConfig[index].listGameObjectMap;
        }
        public static List<Sprite> GetListSpriteMapFollowTank(int index)
        {
            return asset.Value.ScriptableSpriteMapConfig[index].listSpriteShowInTank;
        }
    }
}