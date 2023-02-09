using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PickupText : MonoBehaviour
{
    public GameObject textBox;
    public Text itemText;
    

    public string pickup1Text;
    public string pickup2Text;
    public string pickup3Text;
    public string pickup4Text;
    public string pickup5Text;
    public string pickup6Text;




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
        if (other.tag == "pickup 4")
        {
            textBox.SetActive(true);
            itemText.text = pickup4Text;
            StartCoroutine(WaitForSec());
        }
        if (other.tag == "pickup 5")
        {
            textBox.SetActive(true);
            itemText.text = pickup5Text;
            StartCoroutine(WaitForSec());
        }
        if (other.tag == "pickup 6")
        {
            textBox.SetActive(true);
            itemText.text = pickup6Text;
            StartCoroutine(WaitForSec());
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(7);
        textBox.SetActive(false);
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
