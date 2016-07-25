using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OSUnit_Spearman : OrderSpectrumUnit {

    public override void Initialize()
    {
        base.Initialize();
        _buffSpawner = new BuffSpawner();
        _specialAbilityButton = GetComponentInChildren<Button>();
        _specialAbilityButton.gameObject.SetActive(false);
        _specialAbilityButton.onClick.AddListener(TriggerSpecialAbility);

        iconParticle = transform.FindChild("Canvas").GetComponent<Transform>().FindChild("SkillIconParticle").GetComponent<ParticleSystem>();
        skillParticle = transform.FindChild("SkillActive").GetComponent<ParticleSystem>();


        iconParticle.Stop();
        skillParticle.Stop();
    }

    public override void OnTurnEnd()
    {
        //_buffSpawner.SpawnBuff(new HealingBuff(1, 10), Cell, this, 1, true);
        //_buffSpawner.SpawnBuff(new DefenceBuff(1, 1), Cell, this, 1, false);//Hero has the ability to heal and raise defence od adjacent units.
        base.OnTurnEnd();
        if(Buffs.Count == 0){
            skillParticle.Stop();
        }

        UpdateStatus();
    }

    private void TriggerSpecialAbility()
    {
        //Hero has specail ability that allows him to raise his attack by 2 for duration of 3 turns.
        //This ability can be triggered once a game.
        Debug.Log("Pressed");

        if (!_abilityUsed)
        {
            _abilityUsed = true;
            var buff = new AttackBuff(2, 4);
            var buff2 = new DefenceBuff(2, 2);

            MovementPoints += 1;

            buff.Apply(this);
            buff2.Apply(this);
            
            Buffs.Add(buff);
            Buffs.Add(buff2);

            _specialAbilityButton.gameObject.SetActive(false);
            iconParticle.Stop();
            skillParticle.Play();

            UpdateStatus();

            this.OnUnitDeselected();
            this.OnUnitSelected();
        }
    }
}
