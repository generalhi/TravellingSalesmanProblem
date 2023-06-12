using UnityEngine;

public class Main : MonoBehaviour
{
    private Tables _tables;

    private void Start()
    {
        var pointsObject = FindObjectOfType<Points>();
        if (pointsObject != null)
        {
            _tables = new Tables();
            _tables.Run(pointsObject.GetPoints());
        }
    }

    private void OnDrawGizmos()
    {
        if (_tables == null)
        {
            return;
        }

        _tables.GizmosDrawAllConnections();
        _tables.GizmosDrawPath();
    }
}
