using UnityEngine;
using System.Collections;

public class NodePathPlayer : MonoBehaviour
{
    // The speed at which the player will move along the path
    [SerializeField] private float speed;

    // The transform location of the start space.
    public Transform[] startSpace;

    // The array of nodes that make up the current path
    public Transform[] nodes;

    // The array of nodes that make up the path1
    public Transform[] nodes1;

    // The array of nodes that make up the path2
    public Transform[] nodes2;

    // The array of nodes that make up the path2
    public Transform[] nodes3;

    // The array of nodes that make up the path2
    public Transform[] nodes4;

    // The current node that the player is moving towards
    private int currentNode = 0;

    // The current node that the player is moving towards
    public int currentPath = 0;

    // Boolean value for if dice has been rolled
    public bool rolled;

    // Boolean value for if waiting for player input
    public bool canMove;

    // Boolean value for if waiting for player input
    public bool waitForInput;

    // Boolean value for text has been displayed
    public bool displayedText;

    // Boolean value for text has been displayed
    private bool gameStartRoll;

    // The integer value of the amount rolled on dice
    public int rollAmount;




    void Start()
    {
        canMove = true;
        nodes = startSpace;
        gameStartRoll = true;
    }

    void Update()
    {
        if (!rolled)
        {
            rollDice();
        }


        if (waitForInput)
        {
            StartCoroutine(ChoosePath());
        }
    }

    private void FixedUpdate()
    {
        if (rolled)
        {
            StartCoroutine(movePlayer());
        }
    }

    IEnumerator movePlayer()
    {
        while (rollAmount > 0)
        {
            if (canMove)
            { 
            // Move the player towards the current node
            transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, speed * Time.deltaTime);

            }
            // If the player has reached the current node, move on to the next one
            if (transform.position == nodes[currentNode].position)
            {
                currentNode++;
                rollAmount--;

                // If the player has reached the end of the current path, ask for input to choose the next one
                if (currentNode >= nodes.Length)
                {
                    currentPath++;
                    currentNode = 0;

                    switch (currentPath) 
                    {
                        case 0:
                            //Do nothing we should never hit this case
                            Debug.Log("UH OH THIS NOT SUPPOSED TO HAPPEN");
                            break;
                        case 1:
                            canMove = false;
                            waitForInput = true;
                            yield return ChoosePath();
                            break;
                        case 2:
                            nodes = nodes4;
                            break;
                        case 3:
                            currentPath = 0;
                            nodes = nodes1;
                            break;

                    }
                }
            }
            yield return new WaitForSeconds(speed / Time.deltaTime);
        }
        rolled = false;
    }

    void rollDice()
    {
        if (gameStartRoll)
        {
            nodes = nodes1;
            gameStartRoll = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rollAmount = (Random.Range(1, 10) + 1);
            rolled = true;
            Debug.Log("Rolled a " + rollAmount + ".");
        }
    }

    // Asks the player to choose the next path to follow
    IEnumerator ChoosePath()
    {
        if (!displayedText)
        {
            Debug.Log("Choose a path: Left arrow key for path 2, Right arrow key for path 3");
            displayedText = true;
        }

        waitForInput = true;

        while (waitForInput)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                nodes = nodes2;
                waitForInput = false;
                canMove = true;
                displayedText = false;
                break;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                nodes = nodes3;
                waitForInput = false;
                canMove = true;
                displayedText = false;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
