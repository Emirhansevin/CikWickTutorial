using UnityEngine;

public class Consts : MonoBehaviour
{
   public struct SceneNames
    {
        public  const string GAME_SCENE = "GameScene";
    }

    public struct PlayerAnimations
    {
        public const string IS_MOVÝNG = "IsMoving";
        public const string IS_JUMPÝNG = "IsJumping";
        public const string IS_SLIDING = "IsSliding";
        public const string IS_SLIDING_ACTÝVE = "IsSlidingActive";
    }

    public struct OtherAnimaitons
    {
        public const string IS_SPATULA_JUMPING = "IsSpatulaJumping";
    }

    public struct WheatTypes
    {
        public const string GOLD_WHEAT = "GoldWheat";
        public const string HOLY_WHEAT = "HolyWheat";
        public const string ROTTEN_WHEAT = "RottenWheat";
    }
}

