using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  public Rigidbody rb;

  public float speed = 1000f;
  private int score = 0;
  public int health = 5;

  void Update()
  {
    if (health <= 0)
    {
      SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (Input.GetKey("a")) rb.AddForce(-speed * Time.deltaTime, 0, 0);
    if (Input.GetKey("w")) rb.AddForce(0, 0, speed * Time.deltaTime);
    if (Input.GetKey("s")) rb.AddForce(0, 0, -speed * Time.deltaTime);
    if (Input.GetKey("d")) rb.AddForce(speed * Time.deltaTime, 0, 0);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Pickup"))
    {
      score++;
      Debug.Log($"Score: {score}");
      Destroy(other.gameObject);
    }

    if (other.CompareTag("Trap"))
    {
      health--;
      Debug.Log($"Health: {health}");
    }

    if (other.CompareTag("Goal"))
    {
      Debug.Log("You win!");
    }
  }

}
