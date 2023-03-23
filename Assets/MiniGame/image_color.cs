using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class image_color : MonoBehaviour
{

    public Image [] BTN_color = new Image      [4];
    public Color [] part1 = new Color          [3];
    public Color [] part2 = new Color          [3];
    public Color [] part3 = new Color          [3];
    public Color [] part4 = new Color          [3];
    
    public SpriteRenderer [] part;
    void Start()
    {
        partication();
        
    }

    // Update is called once per frame
    //dakeopfjflowpf0lpojf'p, jockvopjpkffsdzdjvekdjcwehfidfveoirjpfoakgp[ogjgdfopgjaeoifvfgregpoergkpofpjgpepergdfgkd;fk;df]
    void Update()
    {
        
    }
    public void partication()
    {
        try
        {
            int colorseleted = Random.Range(0,3);
            part[0].color =BTN_color[0].color = part1[colorseleted];
            part[1].color =BTN_color[1].color = part2[colorseleted];
            part[2].color =BTN_color[2].color = part3[colorseleted];
            BTN_color[3].color = part4[colorseleted];

        }
        catch
        {

        }
    }

}
