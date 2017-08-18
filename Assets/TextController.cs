using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
                          corridor_0, stairs_0, floor, closet_door, stairs_1, corridor_1,
                          in_closet, stairs_2, corridor_2, corridor_3, courtyard
                        };
    private States myState;

    // Use this for initialization
    void Start() {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update() {
        print(myState);
        if (myState == States.cell)             { state_cell(); }
        else if (myState == States.sheets_0)    { state_sheets_0(); }
        else if (myState == States.lock_0)      { state_lock_0(); }
        else if (myState == States.mirror)      { state_mirror(); }
        else if (myState == States.cell_mirror) { state_cell_mirror(); }
        else if (myState == States.sheets_1)    { state_sheets_1(); }
        else if (myState == States.lock_1)      { state_lock_1(); }
        else if (myState == States.corridor_0)  { state_corridor_0(); }
        else if (myState == States.stairs_0)    { state_stairs_0(); }
        else if (myState == States.floor)       { state_floor(); }
        else if (myState == States.closet_door) { state_closet_door(); }
        else if (myState == States.stairs_1)    { state_stairs_1(); }
        else if (myState == States.corridor_1)  { state_corridor_1(); }
        else if (myState == States.in_closet)   { state_in_closet(); }
        else if (myState == States.stairs_2)    { state_stairs_2(); }
        else if (myState == States.corridor_2)  { state_corridor_2(); }
        else if (myState == States.corridor_3)  { state_corridor_3(); }
        else if (myState == States.courtyard)   { state_courtyard(); }
        

    }

    void state_cell() {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside.\n\n" +
                    "Press S to view sheets, M to view mirror, L to view the lock";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.M))       { myState = States.mirror; }
        else if (Input.GetKeyDown(KeyCode.L))       { myState = States.lock_0; }
    }

    void state_sheets_0() {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time somebody changed them. The pleasures of prison life " +
                    "I guess!\n\n" +
                    "Press R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))            { myState = States.cell; }
    }

    void state_lock_0() {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))            { myState = States.cell; }
    }

    void state_mirror() {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to take the mirror, or R to return to roaming your cell.";
        if (Input.GetKeyDown(KeyCode.T))            { myState = States.cell_mirror; }
        else if (Input.GetKeyDown(KeyCode.R))       { myState = States.cell; }
    }

    void state_cell_mirror() {
        text.text = "You pace the rough floor impatiently, grasping the mirror " +
                    "so tightly it digs into your flesh. Your eyes cast around " +
                    "wildly searching for a way out.\n\n" +
                    "Press S to examine the sheets, or L to examine the lock.";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L))       { myState = States.lock_1; }
    }

    void state_sheets_1() {
        text.text = "Holding a mirror in you hand doesn't make the sheets look " +
                    "any better\n\n" +
                    "Press R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))            { myState = States.cell_mirror; }
    }

    void state_lock_1() {
        text.text = "You carefully put the mirror through the bars, and turn it around " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons. You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to open the door, or R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.O)) { myState = States.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.R))       { myState = States.cell_mirror; }
    }

    void state_corridor_0() {
        text.text = "The door swings open surprisingly easy and quiet as night. You " +
                    "creep forward cautiously only to find a stone corridor, cold but " +
                    "deserted. There are stairs to your left and an old oaken door " +
                    "to your right that stands out against textured floor.\n\n" +
                    "Press S to examine the stairway, F to look at the floor, or "+
                    "C to examine the closet.";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.stairs_0; }
        else if (Input.GetKeyDown(KeyCode.F))       { myState = States.floor; }
        else if (Input.GetKeyDown(KeyCode.C))       { myState = States.closet_door; }
    }

    void state_stairs_0() {
        text.text = "The stairs appear to be unguarded but you can hear the sounds " +
                    "of celebration coming from above. It would not be safe to go up " +
                    "with how you are dressed. You would stick out immediately\n\n" +
                    "press R to return to roaming the corridor.";
        if (Input.GetKeyDown(KeyCode.R))            { myState = States.corridor_0; }
    }

    void state_floor() {
        text.text = "The floor is hard and worn, showing the years of stomped and " +
                    "dragged feet. Something catches your eye on the stone floor " +
                    "by the staircase. A shiny piece of metal. A hairpin!\n\n" +
                    "press H to grab the hair pin, R to return to roaming the corridor";
        if (Input.GetKeyDown(KeyCode.H))            { myState = States.corridor_1; }
        else if (Input.GetKeyDown(KeyCode.R))       { myState = States.corridor_0; }
    }

    void state_closet_door() {
        text.text = "The heavy oaken doorshows signs of regular use but as you grip " +
                    "the handle you realize it is locked at the base with an old " +
                    "Victorian-style lock. Perhaps best to keep searching.\n\n" +
                    "press R to return to roaming the corridor";
        if (Input.GetKeyDown(KeyCode.R))            { myState = States.corridor_0; }
    }
    void state_stairs_1() {
        text.text = "You cling to the wall of the stairwell, hairpin in hand, your " +
                    "heart beating wildly. You can still make out the sounds of a party " +
                    "above and even catch a glimpse a servant in formal tails pass by. " +
                    "You know the hairpin will not help you blend in.\n\n" +
                    "press R to return to roaming the corridor";
        if (Input.GetKeyDown(KeyCode.R))            { myState = States.corridor_1; }
    }

    void state_corridor_1() {
        text.text = "The corridor is still deserted, sounds of a party above but now " +
                    "you have a hairpin! The stairs to the left spiral upwards and the " +
                    "hard wooden door to the left looks resolute. Might be able to pick it\n\n" +
                    "press S to examine the stairs, P to pick the resolute lock ";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.stairs_1; }
        else if (Input.GetKeyDown(KeyCode.P))       { myState = States.in_closet; }
    }

    void state_in_closet() {
        text.text = "The old lock was no match for your practiced fingers and fell " +
                    "away easily. The door opens to a maids closet with cleansers, towels " +
                    "and even spare servants uniforms.\n\n" +
                    "press D to dress up, R to return roaming the corridor";
        if (Input.GetKeyDown(KeyCode.D))            { myState = States.corridor_3; }
        else if (Input.GetKeyDown(KeyCode.R))       { myState = States.corridor_2; }
    }

    void state_stairs_2() {
        text.text = "The party continues above and you are almost spotted by a servant. " +
                    "This would not be a good time to go upstairs.\n\n" +
                    "press R to return to roaming the corridor";
        if (Input.GetKeyDown(KeyCode.R))            { myState = States.corridor_2; }
    }

    void state_corridor_2() {
        text.text = "The corridor remains lonely and distant from the happpy sounds " +
                    "coming from above. The stairs are to your left and the resolute " +
                    "door stands ajar to your right\n\n" +
                    "press S to examine the stairwell, D to open the door";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.stairs_2; }
        else if (Input.GetKeyDown(KeyCode.D))       { myState = States.in_closet; }
    }

    void state_corridor_3() {
        text.text = "You don the fresh servants formal wear and hope your unshaven " +
                    "face isn't a dead give-away. You look towards the stairs and hear " +
                    "the pitch of the party intensifying. It's now or never...\n\n" +
                    "press S to go ups the stairs";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.courtyard; }
    }

    void state_courtyard() {
        text.text = "You peek out into of the stairwell at the party. It's expansive, " +
                    "expensive, straight up lewd. It all comes rushing back to you." +
                    "You had been attending the orgiastic feast when a beautiful woman " +
                    "decided to make you her pet. She banged you 10 ways from Sundays " +
                    "and locked you up in her \"pit\" until you recovered from the " +
                    "mind melting orgasm that made you pass out. You start to smile " +
                    "and then you see her across the room looking back at you...\n\n" +
                    "You smile wider.";
    }



}
