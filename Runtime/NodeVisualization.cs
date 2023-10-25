using UnityEngine;

public class NodeVisualization : MonoBehaviour
{
    private const float SphereRadius = 0.5f;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawSphere(transform.position, SphereRadius);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, SphereRadius);
    }
}
