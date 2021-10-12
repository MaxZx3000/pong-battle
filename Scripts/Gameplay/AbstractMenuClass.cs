using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbstractMenuClass
{
    private PaddleCharacters[] paddleCharacters;
    private GameObject firstPlayerWindow;
    public PaddleCharacters[] PaddleCharacters { get => paddleCharacters; }
    public GameObject FirstPlayerWindow { get => firstPlayerWindow; }
    public AbstractMenuClass(GameObject firstPlayerWindow)
    {
        paddleCharacters = new PaddleCharacters[3] { new BluePaddle(), new GreenPaddle(), new PinkPaddle()};
        this.firstPlayerWindow = firstPlayerWindow;
    }
    public abstract void ShowMenus();
    public abstract void displayCharacterInformation(int playerIndex, int imageIndex, ComponentStats[] ComponentStats);
    public abstract PaddleCharacters executeInformation(int imageIndex);
}
public class ComponentStats
{
    private Image image;
    private Text movementSpeedText;
    private Text forceText;
    public ComponentStats(Image image, Text movementSpeedText, Text forceText)
    {
        this.image = image;
        this.movementSpeedText = movementSpeedText;
        this.forceText = forceText;
    }
    public Image Image { get => image; set => image = value; }
    public Text MovementSpeedText { get => movementSpeedText; set => movementSpeedText = value; }
    public Text ForceText { get => forceText; set => movementSpeedText = value; }
}
class OnePlayerMenu : AbstractMenuClass
{
    public OnePlayerMenu(GameObject firstPlayerWindow) : base(firstPlayerWindow) { }
    public override void displayCharacterInformation(int playerIndex, int imageIndex, ComponentStats[] ComponentStats)
    {
        ComponentStats[playerIndex].MovementSpeedText.text = "Movement Speed: " + PaddleCharacters[imageIndex].MovementSpeed + "";
        ComponentStats[playerIndex].Image.sprite = PaddleCharacters[imageIndex].PaddleImage;
        ComponentStats[playerIndex].ForceText.text = "Force: " + PaddleCharacters[imageIndex].Force + "";
    }

    public override PaddleCharacters executeInformation(int imageIndex)
    {
        return PaddleCharacters[imageIndex];
    }

    public override void ShowMenus()
    {
        FirstPlayerWindow.SetActive(true);
    }
}