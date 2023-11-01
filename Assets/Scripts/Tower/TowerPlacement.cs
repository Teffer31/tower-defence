using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;    
    [SerializeField] private TowerSlot[] towerSlots;    

    void Update()
    {
        // Check for player input to place towers
        if (Input.GetMouseButtonDown(0))
        {
            // Convert mouse position to world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Cast a ray from the mouse position and check for collisions
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Check if the hit object is a tower slot
                int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.GetComponent<TowerSlot>());
                if (towerSlotIndex != -1)
                {
                    // Check if the tower slot is empty. If not, return
                    if (towerSlots[towerSlotIndex].tower != null)
                    {
                        return;
                    }

                    // Place the tower on the selected tower slot
                    PlaceTower(towerSlotIndex);
                }
            }
        }
    }

    // Place a tower on the specified tower slot
    void PlaceTower(int towerSlotIndex)
    {
        // Instantiate a new tower from the tower prefab
        Tower tower = Instantiate(towerPrefab);

        // Set the tower in the tower slot.
        towerSlots[towerSlotIndex].tower = tower;

        // Set the tower's position to match the tower slot's position
        tower.transform.position = towerSlots[towerSlotIndex].transform.position;
    }
}