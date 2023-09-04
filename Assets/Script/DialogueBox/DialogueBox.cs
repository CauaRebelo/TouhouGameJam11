using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueBox : MonoBehaviour
{

    public TextMeshProUGUI text;
    [SerializeField] private string[] lines;
    public float textSpeed;
    private int i;
    public GameObject player;
    public PlayerInput playerInput;

    void Start(){
        playerInput = player.GetComponent<PlayerInput>();
        text.text = string.Empty;
    }

    public void desabilitaControles(){
        playerInput.SwitchCurrentActionMap("UI");
    }

    public void StartDialogue(){
        i = 0;
        desabilitaControles();
        StartCoroutine(ShowLine());
    }

    public void OnPressAction(InputAction.CallbackContext context)
    {
        if(context.performed && text.text == lines[i]){
            nextLine();
        }
        else if(context.performed && text.text != lines[i]){
            StopAllCoroutines();
            text.text = lines[i];
        }
    }

    IEnumerator ShowLine(){
        foreach (char c in lines[i].ToCharArray()){
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine(){
        if(i < lines.Length -1){
            i++;
            text.text = string.Empty;
            StartCoroutine(ShowLine());
        }
        else{
            playerInput.SwitchCurrentActionMap("Player");
            gameObject.SetActive(false);

        }

    }

}
