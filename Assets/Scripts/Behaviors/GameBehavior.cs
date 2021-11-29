using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, Imanager
{
    //Misc
    public string labelText = "Collect all 4 items and win your freedom!";
    //Item counts
    public int maxItems = 5;
    private int _itemsCollected = 0;
    //EndScreen utilities
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    bool hasWon;
    //OOP redux - Interfaces
    private string _state;
    public string State
    { get { return _state; }
        set { _state = value; }
    }
    //stack experimenting
    public Stack<string> lootStack = new Stack<string>();

    //delegating experimenting
    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;
    void Start()
    {
       

    }
    //Prints blahs
    public void Initialize()
    {

        //creating a generic class
        InventoryList<string> inventoryList = new InventoryList<string>();
        //
        inventoryList.SetItem("Potion");
        Debug.Log(inventoryList.item);
        //blahs
        _state = "Manager initialized..";
        _state.FancyDebug();
        Debug.Log(_state);
        //stack loot wizardry
        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");
        //delegating debugging
        debug(_state);
        //delegate as parameter
        LogWithDelegate(debug);
        //Event subscription
        GameObject player = GameObject.Find("Player");
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;

        //method to subscribe to the actual jump event
        void HandlePlayerJump()
        {
            debug("Player has jumped");
        }
    }

    //method with same signature as delegate made to be delegated
    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void LogWithDelegate(DebugDelegate del)
    {
        del("delegatin the debug task...");
    }
    //Loot List
   
    //shows lose screen and stops scene time
    void EndScreen()
    {
        
        if (hasWon == true)
        {
            showWinScreen = true;
            Time.timeScale = 0f;
        }
        else if (hasWon == false) 
        {
            showLossScreen = true;
            Time.timeScale = 0;
        }
        
    }

    //counts items
    public int Items
    {
        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                hasWon = true;
                EndScreen();
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }

        }
    }

    private int _playerHP = 3;

    public int HP
    {
        get { return _playerHP; }
        set { _playerHP = value;
            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                hasWon = false;
                    EndScreen();
                    }
            else
            {
                labelText = "Ouch... that`s gotta hurt";

            }
            }
        }   
    // GUI

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2 - 50, 200, 100), "You WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }

        if(showLossScreen)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lost..."))
            {
                Utilities.RestartLevel();
            }
        }

    }

    public void PrintLootReport()
    {
        if (lootStack.Count > 0)
        {
            var currentItem = lootStack.Pop();
            var nextItem = lootStack.Peek();
            Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        }
            
    }



}   
