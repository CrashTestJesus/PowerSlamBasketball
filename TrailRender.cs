using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRender : MonoBehaviour {

    TrailRenderer tr;
	void Start () {
        tr = GetComponent<TrailRenderer>();
        tr.sortingLayerName = "Trail";
	}

}
