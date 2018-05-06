using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemBox : MonoBehaviour {

    public string item1;
    public string item2;
    public Image image1;
    public Image image2;
    public Sprite speedBoost;
    public Sprite bumper;
    public Sprite size;
    public Sprite push;
    public Sprite pike;


    // Update is called once per frame
    void Update() {

        if (ItemController.p1Item == null)
        {
            image1.sprite = null;
        }
        if (ItemController.p2Item == null)
        {
            image2.sprite = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player1")
        {
            item1 = ItemGenerator.GetRandomItem();
            ItemController.p1Item = item1;
            switch (item1)
            {
                case "Speed Boost":
                    image1.sprite = speedBoost;
                    break;

                case "Bumper":
                    image1.sprite = bumper;
                    break;

                case "Size":
                    image1.sprite = size;
                    break;

                case "Push":
                    image1.sprite = push;
                    break;

                case "Pike":
                    image1.sprite = pike;
                    break;
            }

            Destroy(gameObject);
        }

        if (other.tag == "Player2")
        {
            item2 = ItemGenerator.GetRandomItem();
            switch (item2)
            {
                case "Speed Boost":
                    image2.sprite = speedBoost;
                    break;

                case "Bumper":
                    image2.sprite = bumper;
                    break;

                case "Size":
                    image2.sprite = size;
                    break;

                case "Push":
                    image2.sprite = push;
                    break;

                case "Pike":
                    image2.sprite = pike;
                    break;
            }

            Destroy(gameObject);
        }

    }
}

