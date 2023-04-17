using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform StartPos;
    [SerializeField] GameObject deathEffect;
    [HideInInspector]
    public int waypointIndex = 0;
    public bool shouldMove = false;
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
            GiftGenerator();
        }
        else if (collision.gameObject.tag == "Booster")
        {

        }
        else if (collision.gameObject.tag == "Die")
        {
            Debug.Log("on die");
            shouldMove = false;
           deathEffect.SetActive(true);
         //  Rebirth();
        }
    }
    void Rebirth()
    {
        deathEffect.SetActive(false);
        shouldMove = true;
        transform.position = StartPos.position;
    }
    void GiftGenerator()
    {

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
