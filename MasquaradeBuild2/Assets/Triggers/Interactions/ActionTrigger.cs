using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField] private SceneAction sceneAction = null;

    private Collider2D hitbox;
    private Vector2 hitpoint;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sceneAction.GetActionIcon();

        hitbox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            hitpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (hitbox.OverlapPoint(hitpoint))
            {
                sceneAction.Interact();

                this.gameObject.SetActive(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.E) && this.gameObject.activeInHierarchy == true)
        {
            sceneAction.Interact();

            this.gameObject.SetActive(false);
        }
    }
}
