using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerDialogue : MonoBehaviour
{

    public TextMeshProUGUI text;
    [SerializeField] private string[] lines;
    public float textSpeed;
    private int i;
    public GameObject player;
    [SerializeField] private GameObject canvas;
    public PlayerInput playerInput;
    private GameObject hitboxDialogo;
    public bool dialogueStart = false;
    private int gamb;

    void Start(){
        playerInput = player.GetComponent<PlayerInput>();
        text.text = string.Empty;
    }

    public void desabilitaControles(){
        Debug.Log("Teste ui");
        playerInput.SwitchCurrentActionMap("UI");
    }

    public void StartDialogue(){
        text.text = string.Empty;
        i = 0;
        desabilitaControles();
        StartCoroutine(ShowLine());
    }

    void Update()
    {
        // Debug.Log("Amado pelé");
        if(Input.GetKeyDown(KeyCode.E) && text.text == lines[i]){
            nextLine();
        }
        else if(Input.GetKeyDown(KeyCode.E) && text.text != lines[i]){
            StopAllCoroutines();
            text.text = lines[i];
        }
    }
    
    public void OnTriggerEnter2D(Collider2D teste){
        if(teste.gameObject.CompareTag("Player") && dialogueStart == false){
            canvas.SetActive(true);
            dialogueStart = true;
            StartDialogue();
        }
    }

    public void OnTriggerExit2D(Collider2D teste){
        if(dialogueStart){
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            dialogueStart = false;
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
        else if(dialogueStart){
            Debug.Log("Teste ui2");
            playerInput.SwitchCurrentActionMap("Player");
            canvas.SetActive(false);
        }

    }

}
