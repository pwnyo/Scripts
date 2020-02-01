using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public string tool;
    public Collider2D collider;
    public List<Collider2D> interactables;
    public ContactFilter2D contactFilter;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)) {
            this.transform.position = this.transform.position + this.transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A)) {
            this.transform.position = this.transform.position - this.transform.right * speed * Time.deltaTime;
        }

        collider.OverlapCollider(contactFilter, interactables);

        if(interactables.Count >= 1) {
            if(Input.GetKeyDown(KeyCode.E)) {
                interactables[0].gameObject.GetComponent<Interactables>().Interact(tool);
            }
        }
    }
}
