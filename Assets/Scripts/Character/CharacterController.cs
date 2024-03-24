using Data;
using UI;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        CharacterUIController _characterUIController;
        [SerializeField] CharacterData characterData;
        [SerializeField] CharacterController targetController;
        [SerializeField] GameObject characterStatsGameObject;
        [SerializeField] GameObject characterNameGameObject;

        void Awake()
        {
            InitializeCharacterData();
            InitializeFriendlyCharacterUI();
        }

        void Start()
        {
            StartCoroutine(characterData.CharacterTimeLoop());
        }

        void Update()
        {
            _characterUIController?.UpdateUIValues();

            if (characterData.IsReadyForAction)
            {
                if (characterData.characterTeam == CharacterTeam.Friendly && characterData.CanAttackTarget && Input.GetKeyDown(KeyCode.Space))
                {
                    characterData.Attack();
                }
            }
        }
        
        void InitializeFriendlyCharacterUI()
        {
            if (characterData.characterTeam == CharacterTeam.Friendly)
                _characterUIController = new CharacterUIController(characterData, characterStatsGameObject, characterNameGameObject);
        }

        void InitializeCharacterData()
        {
            characterData.characterState = CharacterState.Loading;
            characterData.Init();
            characterData.target = targetController.characterData;
        }
    }
}
