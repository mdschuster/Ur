using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStorage : MonoBehaviour {

    public GameObject stonePrefab;
    public Tile startingTile;

	// Use this for initialization
	void Awake () {

        for (int i = 0; i < this.transform.childCount; i++) {
            //instantiage a new copy of the stone prefab
            //we can send a child to get a little performance benefit
            addStoneToStorage(Instantiate(stonePrefab), this.transform.GetChild(i));
        }

    }


    void addStoneToStorage(GameObject theStone, Transform thePlaceholder = null){
        //find the first empty Placeholder
        if(thePlaceholder==null){
            for (int i = 0; i < this.transform.childCount; i++) {
                Transform p = this.transform.GetChild(i);
                if(p.childCount==0){
                    //this placeholder is empty
                    thePlaceholder = p;
                    break;
                }
            }
        }
        if(thePlaceholder==null){
            Debug.LogError("No empty placeholders available!");
            return;
        }

        //partent the stone to the placeholder
        theStone.transform.SetParent(thePlaceholder);

        //reset the stone's local pos to 0,0,0
        theStone.transform.localPosition = Vector3.zero;

        //set starting tile
        theStone.GetComponent<PlayerStone>().startingTile = this.startingTile;


    }
}
