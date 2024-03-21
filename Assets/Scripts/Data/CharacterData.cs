
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "CharacterData/ CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        
        [Space(10)]
        public int maxHealth;
        public int currentHealth;
        
        [Space(10)]
        public int maxMana;
        public int currentMana;
        
        [Space(10)]
        public int maxLimit;
        public int currentLimit;
        
        [Space(10)]
        public int maxSpeed;
        public int currentSpeed;

        [Space(10)] 
        public CharacterState characterState;

        [Space(10)] 
        public CharacterTeam characterTeam;
    }

    public enum CharacterTeam
    {
        Friendly,
        Enemy
    }

    public enum CharacterState
    {
        Loading,
        Idle,
        Ready,
        Attacked,
        Attacking
    }
}
