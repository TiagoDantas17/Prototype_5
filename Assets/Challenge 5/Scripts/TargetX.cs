using System.Collections;
using UnityEngine;

public class TargetX : MonoBehaviour
{
    private GameManagerX gameManager;

    public int pointValue;

    private float timeOnScreen = 1.0f;

    private float minValueX = -3.75f;
    private float minValueY = -3.75f;
    private float spaceBetweenSquares = 2.5f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition();

        StartCoroutine(RemoveObjectRoutine());
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }

    IEnumerator RemoveObjectRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);

        if (gameManager.isGameActive)
        {
            Destroy(gameObject);

            if (!gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(
            Random.Range(0, 4) * spaceBetweenSquares + minValueX,
            Random.Range(0, 4) * spaceBetweenSquares + minValueY,
            0
        );
    }
}