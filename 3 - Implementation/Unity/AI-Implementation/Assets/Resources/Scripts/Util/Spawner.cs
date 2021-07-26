using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    private Game game;
    protected GameObject[] spawnables;
    protected int spawnIndex = 0;
    [SerializeField] protected Transform spawnPos;
    [SerializeField] protected Image objSprite;
    protected CreatePreview preview;

    [Header("UI Stuff")]
    public Text objectName;


    private void Awake()
    {
        game = GameObject.FindObjectOfType<Game>();
        spawnables = Resources.LoadAll<GameObject>("Prefab/Spawnables");
        preview = GetComponent<CreatePreview>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        objectName.text = GetCurrentSpawnable().name;
        if (preview.spawnedObject)
            preview.Clear();

        preview.CreateObjectPreviewSprite(GetCurrentSpawnable().GetComponentInChildren<SpriteRenderer>(), objSprite);
    }

    private void Update()
    {
        // Spawn GameObjects
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);


            if (hit.collider && hit.collider.CompareTag("GridComp"))
            {



                Vector2 pos = hit.collider.transform.position;
                // We left clicked so try place start spot
                PathNode node = game.Grid.GetNode((int)pos.x, (int)pos.y);
                if (node.IsWalkable)

                    SpawnObject(new Vector2(node.GetXPosition(), node.GetYPosition()));





            }
            else if (hit.collider && !hit.collider.CompareTag("Player") && hit.collider.gameObject.TryGetComponent<Agent>(out Agent ag))
            {
                Destroy(hit.collider.gameObject);
            }
        }



        // Spawn Wall
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TrySpawnWall();
        }
    }

    public void SpawnObject(Vector2 pos)
    {
        if (spawnables[spawnIndex] != null) Instantiate(spawnables[spawnIndex], pos, Quaternion.identity);
    }
    private void TrySpawnWall()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("GridComp"))
        {


            Debug.Log(hit.collider.transform.position);
            Vector2 pos = hit.collider.transform.position;
            // We left clicked so try place start spot
            PathNode node = game.Grid.GetNode((int)pos.x, (int)pos.y);
            node.IsWalkable = !node.IsWalkable; // either set or remove wall
            game.UpdateVisuals();





        }
    }

    public void IncrementIndex()
    {
        spawnIndex++;
        if (spawnIndex >= spawnables.Length)
        {
            spawnIndex = 0;
        }

    }

    public void DecrementIndex()
    {
        spawnIndex--;
        if (spawnIndex < 0)
        {
            spawnIndex = spawnables.Length - 1;
        }
    }

    public GameObject GetCurrentSpawnable()
    {
        return spawnables[spawnIndex];
    }

    // Was originally going to have the object sit on the mouse pos
    public void CreateMousePreview()
    {
        preview.CreateObjectPreview(GetCurrentSpawnable());
    }
}
