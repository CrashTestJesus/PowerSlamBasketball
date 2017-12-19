using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItRain : MonoBehaviour {

    public float speed;
    public float limit;
    public float startY;

	void Update () {
        transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * speed;
        if(transform.position.y < limit)
        {
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
	}
}
