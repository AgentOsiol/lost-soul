using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController PlayerHeight;
    public float normalHeight, crouchHeight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            PlayerHeight.height = crouchHeight;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            PlayerHeight.height = normalHeight;
        }
    }
}
