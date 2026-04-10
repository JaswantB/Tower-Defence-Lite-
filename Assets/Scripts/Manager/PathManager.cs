using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager instance { get; private set; }

    public List<Transform> wayPoints = new List<Transform>();

      private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        WayPoints();
    }

    void WayPoints()
    {
        foreach (Transform child in transform)
        {
            wayPoints.Add(child);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Transform current = transform.GetChild(i);
            Transform next = transform.GetChild(i + 1);

            Gizmos.DrawLine(current.position, next.position);
        }
    }
}
