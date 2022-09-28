using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    // [SerializeField] private float jumpTime;
    // private bool jumping;
    // private float timer;

    [SerializeField] private int score;
    [SerializeField] private int combo;
    private BeatController controller;

    void Start()
    {
        // timer = 0f;
        // jumping = false;
        score = 0;
        combo = 0;
        controller = GameObject.Find("Audio Source").GetComponent<BeatController>();
    }

    public void OnPress(InputValue value)
    {
        float curBeat = controller.songPositionInBeats;
        Note nearestNote;
        if (controller.getCurrentlyLiveNotes().Count > 0) {
            nearestNote = controller.getCurrentlyLiveNotes().Peek();
            float diff = Mathf.Abs(curBeat - nearestNote.beat);
            // Implement handle to avoid spam press
            if (diff < Note.LEEWAY) {
                // jumping = true;
                score += 1;
                combo += 1;
                Destroy(nearestNote.gameObject);
            }
            if (nearestNote.destroyBeat <= curBeat) {
                combo = 0;
            }
        }
        Debug.Log($"Score: {score}, Combo: {combo}");
    }

    public int getScore() { return score; }
    public void resetPlayerCombo() { combo = 0; }
}
