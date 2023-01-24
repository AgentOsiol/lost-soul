using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupText : MonoBehaviour
{
    public GameObject textBox;
    public Text itemText;
    

    public string pickup1Text;
    public string pickup2Text;
    public string pickup3Text;
     

    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup 1")
        {
            textBox.SetActive(true);
            itemText.text = pickup1Text;
            StartCoroutine(WaitForSec());
        }
        if (other.tag == "pickup 2")
        {
            textBox.SetActive(true);
            itemText.text = pickup2Text;
            StartCoroutine(WaitForSec());
        }
        if (other.tag == "pickup 3")
        {
            textBox.SetActive(true);
            itemText.text = pickup3Text;
            StartCoroutine(WaitForSec());
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(7);
        textBox.SetActive(false);
    }

}
