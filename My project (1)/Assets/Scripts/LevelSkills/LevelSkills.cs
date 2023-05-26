using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSkills : MonoBehaviour
{
    public static LevelSkills lvlskill;
    public GameObject levelSkillPanel;
    public Slider sliderAS;
    public Slider sliderMS;
    public Slider sliderD;
    public Slider sliderMH;
    public int countSliderAS;
    public int countSliderMS;
    public int countSliderD;
    public int countSliderMH;

    public int plus_skillAS;
    public int plus_skillMS;
    public int plus_skillD;
    public int plus_skillMH;
    

    
    void Start()
    {
        lvlskill = this;
    }

   
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!levelSkillPanel.activeSelf)
            {
                levelSkillPanel.SetActive(true);             
            }
            else
            {
                levelSkillPanel.SetActive(false);  
            }
        }
        sliderAS.value = countSliderAS;
        sliderMS.value = countSliderMS;
        sliderD.value = countSliderD;
        sliderMH.value = countSliderMH;
    }
    private void FixedUpdate()
    {
        
    }

    public void UpSkillAS()
    {
        if (PlayerController.instance.plF.skillPoint > 0)
        {
            if (countSliderAS >= 10)
            {
                countSliderAS += 0;
            }
            else
            {
                PlayerUI.plUI.plus_AS.SetActive(true);
                countSliderAS++;
                plus_skillAS++;
                PlayerController.instance.plF.attackSpeed += 1;
                PlayerController.instance.plF.skillPoint--;
            }
        }           
    }
    public void UpSkillMS()
    {      
        if (PlayerController.instance.plF.skillPoint > 0)
        {
            if (countSliderMS >= 10)
            {
                countSliderMS += 0;
            }
            else
            {
                PlayerUI.plUI.plus_MS.SetActive(true);
                countSliderMS++;
                plus_skillMS++;
                PlayerController.instance.plF.moveSpeed += 1;
                PlayerController.instance.plF.skillPoint--;
            }
        }
    }

    public void UpSkillD()
    {    
        if (PlayerController.instance.plF.skillPoint > 0)
        {
            if (countSliderD >= 10)
            {
                countSliderD += 0;
            }
            else
            {
                PlayerUI.plUI.plus_D.SetActive(true);
                countSliderD++;
                plus_skillD += 10;
                PlayerController.instance.plF.maxDamage += 10;
                PlayerController.instance.plF.skillPoint--;
            }
        }
    }

    public void UpSkillMH()
    {   
        if (PlayerController.instance.plF.skillPoint > 0)
        {
            if (countSliderMH >= 10)
            {
                countSliderMH += 0;
            }
            else
            {
                PlayerUI.plUI.plus_MH.SetActive(true);
                countSliderMH++;
                plus_skillMH += 25;
                PlayerController.instance.plF.maxHp += 25;
                PlayerController.instance.hBarPlayerSlider.maxValue = PlayerController.instance.plF.maxHp;
                PlayerController.instance.plF.skillPoint--;
            }
        }
    }
}
