using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Circle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticleSystem;
    [SerializeField] private float _decreaseSpeed;

    [SerializeField] private int _explodeReward;
    
    private SpriteRenderer _circleRenderer;
    private bool _isExploded;

    private bool _isAlreadyUsed;
    public float Radius => _circleRenderer.bounds.size.x / 2;
    
    public event Action<int> OnExploded;
    
    public bool IsAlreadyUsed => _isAlreadyUsed;
    
    private void Awake()
    {
        _circleRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        DecreaseSize();
    }

    private void OnMouseDown()
    {
        if (!_isExploded)
        {
            Explode();
        }
    }

    private void OnEnable()
    {
        _circleRenderer.enabled = false;
        _isExploded = false;
        _circleRenderer.transform.localScale = Vector3.one;
    }

    public void SetStyle(Color color, Vector2 size)
    {
        SetColor(color);
        SetSize(size);
        
        _circleRenderer.enabled = true;
        _isAlreadyUsed = true;
    }
    
    private void SetColor(Color color)
    {
        _circleRenderer.color = color;
    }

    private void SetSize(Vector2 size)
    {
        _circleRenderer.transform.localScale = size;
        _explosionParticleSystem.transform.localScale *= _circleRenderer.transform.localScale.x;
    }

    private void Explode()
    {
        _isExploded = true;
        _circleRenderer.enabled = false;
        _explosionParticleSystem.Play();
        
        float delay = _explosionParticleSystem.main.duration;
        StartCoroutine(ExplodeAfterDelayRoutine(delay));
    }

    private IEnumerator ExplodeAfterDelayRoutine(float delay)
    {
        OnExploded?.Invoke(_explodeReward);
        
        yield return new WaitForSeconds(delay);
        
        gameObject.SetActive(false);
    }

    private void DecreaseSize()
    {
        transform.localScale -= Vector3.one * _decreaseSpeed * Time.deltaTime;
        if(transform.localScale.x < 0)
            gameObject.SetActive(false);
    }
}