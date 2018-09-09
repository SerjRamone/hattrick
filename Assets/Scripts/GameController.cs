using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject ball;
    public float timeLeft;

    private float maxWidth;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
            Vector3 upperCorner = new Vector3(Screen.width, Screen.height, .0f);
            Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
            float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
            maxWidth = targetWidth.x - ballWidth;
            StartCoroutine(Spawn());
        }
    }

    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (timeLeft > 0)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                .0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
    }
}
