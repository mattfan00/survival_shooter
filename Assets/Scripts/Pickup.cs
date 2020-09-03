using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemUI;
    void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collisionInfo) {
        if (collisionInfo.gameObject.name == "Player") {
            if (CheckSlotsContainsItem(itemUI.name) > -1) {
                Debug.Log("has the item");
            } else {
                // find the first slot open and add to it
                for (int i = 0; i < inventory.slots.Length; i++) {
                    if (!inventory.isFull[i]) {
                        inventory.isFull[i] = true;

                        inventory.slotContents[i] = itemUI.name;

                        Instantiate(itemUI, inventory.slots[i].transform, false);
                        Destroy(gameObject);

                        break;
                    }
                }
            }
        }
    }

    int CheckSlotsContainsItem(string itemName) {
        for (int i = 0; i < inventory.slots.Length; i++) {
            if (inventory.slotContents[i] == itemName) {
                return i;
            }
        }
        return -1;
    }
}
