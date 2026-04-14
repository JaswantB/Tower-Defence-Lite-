using UnityEngine;

public class EnemyWayPoint : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvents;
    private Transform[] _waypoints;
    private float _speed;
    private int currentIndex;

    private bool hasReachedBase = false;

    public void WayPoint(Transform[] waypoints, float speed)
    {
        _waypoints = waypoints;
        _speed = speed;
        currentIndex = 0;
    }

    private void Update()
    {
        if (_waypoints == null || currentIndex >= _waypoints.Length)
        {
            return;
        }

        Transform target = _waypoints[currentIndex];
        Debug.Log(target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.1f)
        {
            Debug.Log($"currentIndex: {currentIndex}");
            currentIndex++;
        }
        if (_waypoints == null || hasReachedBase)
            return;

        if (currentIndex >= _waypoints.Length)
        {
            hasReachedBase = true;

            Debug.Log("Enemy Reached the base");
            gameEvents.RaiseOnEnemyReached();

            Destroy(gameObject);
            return;
        }

    }

}
