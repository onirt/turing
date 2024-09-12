using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing
{
    [CreateAssetMenu(fileName = "CharacterModel", menuName = "Turing/Models/Character")]
    public class CharacterModel : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Life { get; private set; }
    }
}
