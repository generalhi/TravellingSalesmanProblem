using UnityEngine.Serialization;

namespace Entities
{
    public struct Connection
    {
        //public bool Enable;
        [FormerlySerializedAs("Length")]
        public float Distance;
    }
}
