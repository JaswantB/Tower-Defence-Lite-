using UnityEngine;

public class TowerSpots : MonoBehaviour
{
    public bool isOccupied = false;
    public void OccupySpot(bool occupied)
    {
        isOccupied = occupied;
    }
}
    