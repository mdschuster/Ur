using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStone : MonoBehaviour {

	DiceRoller theDiceRoller;
	public Tile startingTile;
	Tile currentTile=null;
    Vector3 targetPosition;
    Vector3 velocity = Vector3.zero;
    float smoothTime = 0.2f;
    float smoothDistance = 0.1f;
    float smoothTimeVert = 0.1f;
    float smoothHeight = 0.5f;
    Tile[] moveQueue;  //stores tiles that the stone will move through to it's final destination
    int moveQueueIndex;
    bool scoreMe = false;

	// Use this for initialization
	void Start () {
		theDiceRoller = GameObject.FindObjectOfType<DiceRoller> ();
        targetPosition = this.transform.position;
	}

    // Update is called once per frame
    void Update() {
        //smoothdamp takes two poistions, and smoothes the time
        //it takes to go from one to another
        //lookup smoothdamp for more info about what is going on here
        if (Mathf.Abs(targetPosition.x-this.transform.position.x) < smoothDistance && Mathf.Abs(targetPosition.z - this.transform.position.z) < smoothDistance) {  //look for small value (were are there if we are close)
            //we've reached the target, how's our height?
            if (moveQueue!=null && moveQueueIndex == moveQueue.Length && this.transform.position.y > smoothDistance) {
                this.transform.position = Vector3.SmoothDamp(this.transform.position, 
                                                            new Vector3(this.transform.position.x, 0, this.transform.position.z),
                                                            ref velocity, 
                                                            smoothTimeVert);
            } else {
                //right position, right height, lets advance the queue
                advanceMoveQueue();
            }

        }
        //we want to rise up before we move sideways
        else if (this.transform.position.y < (smoothHeight-smoothDistance)) {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, 
                                                        new Vector3(this.transform.position.x,smoothHeight,this.transform.position.z), 
                                                        ref velocity, 
                                                        smoothTimeVert);
        }
        else {
            this.transform.position = Vector3.SmoothDamp(this.transform.position,
                                                        new Vector3(targetPosition.x, smoothHeight, targetPosition.z), 
                                                        ref velocity, 
                                                        smoothTime);
        }
	}

    void advanceMoveQueue() {
        //we have reached our last desired position, do we have another move queued up?
        if (moveQueue != null && moveQueueIndex < moveQueue.Length) {
            Tile nextTile = moveQueue[moveQueueIndex];
            if (nextTile == null && scoreMe == true) {
                //we are being scored
                //TODO: move to scored pile 
                setNewTargetPosition(this.transform.position + Vector3.right * 10f);
            }
            else {
                setNewTargetPosition(nextTile.transform.position);
                moveQueueIndex++;
            }

        }
    }

    void setNewTargetPosition(Vector3 pos) {
        targetPosition = pos;
        velocity = Vector3.zero;
    }

	void OnMouseUp(){
		//TODO: is the mouse over a UI element? Ignore click if so
		//Debug.Log ("Click");

        //TODO is it our turn

        //Have we rolled the dice;
        if (theDiceRoller.isDoneRolling==false){
			//you can't move!
			return;
		}
		int spacesToMove = theDiceRoller.diceTotal;

        //where should we end up?
        if (spacesToMove==0){
			return;
		}

		Tile finalTile = currentTile;
        moveQueue = new Tile[spacesToMove];

		for (int i = 0; i < spacesToMove; i++) {
            if (finalTile == null && scoreMe == false) { //on starting space
				finalTile = startingTile;
			} else {
				if (finalTile.nextTiles == null || finalTile.nextTiles.Length == 0) {
                    //We have reaced the end and should score
                    Debug.Log ("Score!");
                    finalTile = null;
                    scoreMe = true;
				} else if (finalTile.nextTiles.Length > 1) {
					//branch based to player ID
					finalTile = finalTile.nextTiles [0];
				} else {
					finalTile = finalTile.nextTiles [0];
				}
			}
            moveQueue[i] = finalTile;
		}

        //now move to final 
        //this.transform.position=finalTile.transform.position;
        //TODO: Animate
        moveQueueIndex = 0;
        currentTile = finalTile;


    }
}
