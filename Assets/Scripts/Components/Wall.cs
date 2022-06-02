using UnityEngine;

namespace FallingDamage
{
    public class Wall : MonoBehaviour 
    {
        public void SetSize(Vector2 size)
        {
            transform.localScale = new Vector3(size.x, 0.5f, size.y);
        }
    }
}
