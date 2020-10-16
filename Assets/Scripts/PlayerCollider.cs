
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private int collisionCounter;
    //make a vector and every time wipe it clean and initiate how many items its contacting at that specific instance.
    //every collision i think is treated as a unique collision, and every time it collides it runs this code, so from one
    //go of the code you can only see one output not two.
    void OnCollisionEnter ( Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Pyramid")
        {
          Debug.Log("We are being seen by one camera");
        }

        if (collisionInfo.collider.name == "Camera2")
        {
          Debug.Log("We are being seen by two cameras");
        }
        //maybe try something where i create a vector of the amount of seconds it spent with each thing and find out some way to count how many it contacted
        //maybe i could hard code it with the number of cameras its contacting right now
    }

    // Update is called once per frame
    void Update()
    {

    }
}
