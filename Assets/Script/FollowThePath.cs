using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform StartPos;
    [SerializeField] GameObject deathEffect;
    [SerializeField] Image gifImage;
    [HideInInspector]
    public int waypointIndex = 0;
    public bool shouldMove = false;
    DiceRoll roll;
	private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
	}
	private void Update () {
        if (shouldMove)
            Move();
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Skip")
        {

        }
        else if(collision.gameObject.tag == "Gift")
        {
           StartCoroutine(GiftGenerator());
        }
        else if (collision.gameObject.tag == "Booster")
        {
            Debug.Log("on booster");
           // roll.whosTurn = 1;
        }
        else if (collision.gameObject.tag == "Die")
        {
            Debug.Log("on die");
            shouldMove = false;
            deathEffect.SetActive(true);
            Destroy(gameObject, 1f);
         //  Rebirth();
        }
    }
    void Rebirth()
    {
        deathEffect.SetActive(false);
        shouldMove = true;
        transform.position = StartPos.position;
    }
    IEnumerator GiftGenerator()
    {
        gifImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        gifImage.gameObject.SetActive(false);
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
