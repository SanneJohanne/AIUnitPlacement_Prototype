using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;
    public AudioClip coinsound;

    private void OnMouseDown()
    {
        CoinManager.instance.Addcoins(coinValue);
        AudioClip coinsound = GetComponent<AudioSource>().clip;
        GetComponent<AudioSource>().PlayOneShot(coinsound);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1.5f);
    }
}
