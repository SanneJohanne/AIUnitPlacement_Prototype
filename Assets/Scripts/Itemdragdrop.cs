using UnityEngine;

public class Itemdragdrop : MonoBehaviour
{
    private Collider2D col;
    public Vector3 startDragPosition;

    public AudioClip placeItemSound;

    void Start()
    {
        col = GetComponent<Collider2D>();
        startDragPosition = transform.position;
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);

        if (hitCollider != null && hitCollider.TryGetComponent(out Tile tile))
        {
            bool canPlaceItem = false;

            // Check if the player has enough coins to place the item
            if (CompareTag("Basil"))
            {
                if (CoinManager.instance.coins >= 10)
                {
                    tile.BasilOnTileDrop(this);  // Coin spending happens here
                    canPlaceItem = true;
                }
            }
            else if (CompareTag("Mushroom"))
            {
                if (CoinManager.instance.coins >= 20)
                {
                    tile.MushroomOnTileDrop(this);
                    canPlaceItem = true;
                }
            }
            else if (CompareTag("Cheese"))
            {
                if (CoinManager.instance.coins >= 40)
                {
                    tile.CheeseOnTileDrop(this);
                    canPlaceItem = true;
                }
            }

            if (canPlaceItem)
            {
                transform.position = startDragPosition;
            }
            else
            {
                transform.position = startDragPosition;  // Return item to its original position
            }
        }
        else
        {
            transform.position = startDragPosition;  // If not placed on tile, return item to original position
        }

        col.enabled = true;

        AudioClip placeItemSound = GetComponent<AudioSource>().clip;
        GetComponent<AudioSource>().PlayOneShot(placeItemSound);
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }
}