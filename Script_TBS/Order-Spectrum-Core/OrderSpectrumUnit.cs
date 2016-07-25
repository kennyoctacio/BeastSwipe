using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrderSpectrumUnit : Unit
{
    Coroutine PulseCoroutine;

    protected BuffSpawner _buffSpawner;
    protected Button _specialAbilityButton;
    protected ParticleSystem iconParticle;
    protected ParticleSystem skillParticle;
    protected bool _abilityUsed;

    public override void Initialize()
    {
        base.Initialize();
        transform.position += new Vector3(0, 0, -1);
        UpdateStatus();
    }

    public override void OnUnitSelected()
    {
        base.OnUnitSelected();
        if (!_abilityUsed && ActionPoints > 0)
        {
            //Invoke("EnableSpecialAbilityButton",0.1f);
            iconParticle.Play(true);
            EnableSpecialAbilityButton();
        }
    }

    public override void OnUnitDeselected()
    {
        base.OnUnitDeselected();
        HideHighlighter();

        _specialAbilityButton.gameObject.SetActive(false);
        iconParticle.Stop();
    }

    public override void MarkAsAttacking(Unit other)
    {
        StartCoroutine(Jerk(other, 0.25f));
        UpdateStatus();
    }
    
    public override void MarkAsDefending(Unit other)
    {
        StartCoroutine(Glow(new Color(1, 0.5f, 0.5f), 1));
        UpdateStatus();
    }

    protected override void Defend(Unit other, int damage)
    {
        base.Defend(other, damage);
        UpdateStatus();
    }

    public override void MarkAsDestroyed()
    {
        
    }

    protected void UpdateStatus()
    {
        string hitpoints;
        string attacks;
        string defences;
        if (HitPoints < 10)
        {
            hitpoints = "0" + HitPoints.ToString();
        }
        else {
            hitpoints = HitPoints.ToString();
        }

        if (AttackFactor < 10)
        {
            attacks = "0" + AttackFactor.ToString();
        }
        else
        {
            attacks = AttackFactor.ToString();
        }

        if (DefenceFactor < 10)
        {
            defences = "0" + DefenceFactor.ToString();
        }
        else
        {
            defences = DefenceFactor.ToString();
        }

        var health = transform.FindChild("HealthStat").GetComponent<Transform>().FindChild("Health").GetComponent<TextMesh>().text = hitpoints;
        var atk = transform.FindChild("AttackStat").GetComponent<Transform>().FindChild("Attack").GetComponent<TextMesh>().text = attacks;
        var def = transform.FindChild("DefStatus").GetComponent<Transform>().FindChild("Def").GetComponent<TextMesh>().text = defences;
    }

    private IEnumerator Jerk(Unit other, float movementTime)
    {
        var heading = other.transform.position - transform.position;
        var direction = heading / heading.magnitude;
        float startTime = Time.time;

        while (true)
        {
            var currentTime = Time.time;
            if (startTime + movementTime < currentTime)
                break;
            transform.position = Vector3.Lerp(transform.position, transform.position + (direction / 2.5f), ((startTime + movementTime) - currentTime));
            yield return 0;
        }
        startTime = Time.time;
        while (true)
        {
            var currentTime = Time.time;
            if (startTime + movementTime < currentTime)
                break;
            transform.position = Vector3.Lerp(transform.position, transform.position - (direction / 2.5f), ((startTime + movementTime) - currentTime));
            yield return 0;
        }
        transform.position = Cell.transform.position + new Vector3(0, 0, -1);
    }

    private IEnumerator Glow(Color color, float cooloutTime)
    {
        var _renderer = GetComponent<SpriteRenderer>();
        float startTime = Time.time;

        while (true)
        {
            var currentTime = Time.time;
            if (startTime + cooloutTime < currentTime)
                break;

            _renderer.color = Color.Lerp(Color.white, color, (startTime + cooloutTime) - currentTime);
            yield return 0;
        }

        _renderer.color = Color.white;
    }

    private IEnumerator HighlighterGlow(Color color, float cooloutTime)
    {
        var _renderer = transform.FindChild("Highlighter").GetComponent<SpriteRenderer>();
        float startTime = Time.time;

        while (true)
        {
            var currentTime = Time.time;
            if (startTime + cooloutTime < currentTime)
                break;

            _renderer.color = Color.Lerp(Color.white, color, (startTime + cooloutTime) - currentTime);
            yield return 0;
        }

        _renderer.color = Color.white;
    }

    private IEnumerator Pulse(float breakTime, float delay, float scaleFactor)
    {
        var baseScale = transform.localScale;
        while (true)
        {
            float time1 = Time.time;
            while (time1 + delay > Time.time)
            {
                transform.localScale = Vector3.Lerp(baseScale * scaleFactor, baseScale, (time1 + delay) - Time.time);
                yield return 0;
            }

            float time2 = Time.time;
            while (time2 + delay > Time.time)
            {
                transform.localScale = Vector3.Lerp(baseScale, baseScale * scaleFactor, (time2 + delay) - Time.time);
                yield return 0;
            }

            yield return new WaitForSeconds(breakTime);
        }
    }

    public override void MarkAsFriendly()
    {
        SetHighlighterColor(new Color(1, 1, 1, 1f));
    }

    public override void MarkAsReachableEnemy()
    {
        ShowHighlighter();
        SetHighlighterColor(new Color(1, 0, 0, 1.0f));
    }

    public override void MarkAsSelected()
    {
        ShowHighlighter();
        SetHighlighterColor(new Color(1, 1, 1, 1f));
    }

    public override void MarkAsFinished()
    {
        HideHighlighter();
        SetUnitColor(new Color(0.6f, 0.6f, 0.6f, 1f));

        _specialAbilityButton.gameObject.SetActive(false);
        iconParticle.Stop();
    }

    public override void UnMark()
    {
        HideHighlighter();
        SetUnitColor(Color.white);
    }

    protected void EnableSpecialAbilityButton()
    {
        _specialAbilityButton.gameObject.SetActive(true);
        iconParticle.Play();
        _specialAbilityButton.interactable = true;
    }

    private void SetUnitColor(Color color)
    {
        var unitSpriteRenderer = GetComponent<SpriteRenderer>();
        unitSpriteRenderer.color = color;
    }


    private void SetHighlighterColor(Color color)
    {
        var highlighter = transform.FindChild("Highlighter").GetComponent<SpriteRenderer>();
        highlighter.color = color;
    }

    private void HideHighlighter()
    {
        transform.FindChild("Highlighter").GetComponent<SpriteRenderer>().enabled = false;
    }

    private void ShowHighlighter()
    {
        transform.FindChild("Highlighter").GetComponent<SpriteRenderer>().enabled = true;
    }
}