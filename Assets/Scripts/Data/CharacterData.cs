using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Data
{
    [CreateAssetMenu(menuName = "CharacterData/ CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public string characterName = "CharacterData";
        
        [Space(10)]
        public int maxHealth = 100;
        public int currentHealth = 100;
        
        [Space(10)]
        public int maxMana = 100;
        public int currentMana = 100;
        
        [Space(10)]
        public float maxLimit = 100;
        public float currentLimit = 100;
        
        [Space(10)]
        public float maxSpeed = 10;
        public float currentSpeed;


        [Space(10)] 
        public UnityEvent onAttack;
        public UnityEvent onWasAttacked;
        public bool playerJustAttacked;

        [Space(10)] 
        public CharacterState characterState;

        [Space(10)] 
        public CharacterTeam characterTeam;

        [Space(16)] 
        public CharacterData target;
        
        #region Properties
        public bool IsReadyForAction => currentSpeed >= maxSpeed;
        public bool CanAttackTarget => target.characterState is CharacterState.Idle or CharacterState.Ready;
        
        #endregion

        public void Init()
        {
            onAttack.AddListener(CharacterActionTaken);
            onWasAttacked.AddListener(CharacterAttacked);

            characterState = CharacterState.Idle;
            currentSpeed = Random.Range(0, maxSpeed);
        }

        public IEnumerator CharacterTimeLoop()
        {
            while (characterState != CharacterState.Died)
            {
                if (currentSpeed >= maxSpeed)
                {
                    currentSpeed = maxSpeed;
                    characterState = CharacterState.Ready;
                }
                else
                {
                    currentSpeed += Time.deltaTime; 
                    characterState = CharacterState.Idle;
                }

                yield return null;
            }
        }

        public void Attack()
        {
            onAttack.Invoke();

            target.TakeDamage(10);
            Debug.Log($"Target attacked health remaining: {target.currentHealth}]");
        }

        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                characterState = CharacterState.Died;
            }
            
            onWasAttacked.Invoke();
        }

        void CharacterActionTaken()
        {
            playerJustAttacked = false;
            currentSpeed = 0;
        }

        void CharacterAttacked()
        {
            Debug.Log(characterName + " was attacked");
        }
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
        Attacking,
        Died
    }
}
