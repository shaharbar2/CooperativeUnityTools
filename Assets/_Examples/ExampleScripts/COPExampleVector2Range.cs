using  Cooperative.Attributes;
using UnityEngine;

namespace Cooperative.Examples
{
    public class COPExampleVector2Range : MonoBehaviour
    {
        [COPVector2Range(-10f, 10f), SerializeField]
        private Vector2 _exampleRange;
    }
}