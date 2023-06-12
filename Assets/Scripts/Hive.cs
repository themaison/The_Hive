using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hive : StaticObject
{
    [SerializeField] private HiveData _hiveData;

    [SerializeField] private GameObject _hiveOptionsUIPanel;
    [SerializeField] private ExitPanelController _exitPanel;
    [SerializeField] private Slider _integrityPointsSlider;
    [SerializeField] private AudioClip[] _backgroundAudioClips;
    private SpriteRenderer _spriteRenderer;

    public static int MaxIntegrityPoints;
    public static int BeeCapacity;
    public static int NectarCapacity;
    public static int HoneyCapacity;

    public static int CurrentIntegrityPoints;
    public static int NectarOccupancy;
    public static int HoneyOccupancy;
    public static int BeeOccupancy;

    private Animator _takeDamage;
    private AudioSource _punch;
    public AudioSource _backgroundAudioSource;
    private int _currentBackgroundAudioIndex;

    private void Start()
    {
        LoadData(_hiveData);
        _punch = GetComponent<AudioSource>();
        _takeDamage = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _hintPanel.SetActive(false);

        CurrentIntegrityPoints = MaxIntegrityPoints;
        NectarOccupancy = 0;
        HoneyOccupancy = 0;
        BeeOccupancy = 0;

        _backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        _backgroundAudioSource.loop = true;
        _backgroundAudioSource.volume = 0.3f;

        if (_backgroundAudioClips.Length > 0)
        {
            _backgroundAudioSource.clip = _backgroundAudioClips[0];
            _backgroundAudioSource.Play();
            _currentBackgroundAudioIndex = 0;
        }
    }

    private void Update()
    {
        BeeOccupancy = Bee.beeAmount;
    }

    public virtual void TakeDamage(int damage)
    {
        _punch.Play();
        _takeDamage.SetBool("TakeDamage", true);
        CurrentIntegrityPoints -= damage;
        CurrentIntegrityPoints = Mathf.Clamp(CurrentIntegrityPoints, 0, MaxIntegrityPoints);
        UpdateHealthPointsSlider();

        if (CurrentIntegrityPoints <= 0)
        {
            _backgroundAudioSource.volume = 0;
            _exitPanel.ShowResultPanel("ÏÎÐÀÆÅÍÈÅ!");
        }
        _takeDamage.SetBool("TakeDamage", false);
    }

    protected virtual void SetHintPanelSettings()
    {
        _nameText.text = _name;
        _hintPanel.SetActive(false);
        UpdateHealthPointsSlider();
    }

    protected void UpdateHealthPointsSlider()
    {
        _integrityPointsSlider.value = (float)CurrentIntegrityPoints / MaxIntegrityPoints;
    }

    public void AddNectar(int amount)
    {
        NectarOccupancy += amount;
        if (NectarOccupancy > NectarCapacity)
        {
            NectarOccupancy = NectarCapacity;
        }
    }

    public void AddHoney(int amount)
    {
        HoneyOccupancy += amount;
        if (HoneyOccupancy > HoneyCapacity)
        {
            HoneyOccupancy = HoneyCapacity;
        }
    }

    public int GetNectar(int amount)
    {
        if (amount > NectarOccupancy)
        {
            amount = NectarOccupancy;
        }

        NectarOccupancy -= amount;
        return amount;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        SetHiveMenu();
        _borderHint.SetActive(true);
        _hintPanel.SetActive(true);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _borderHint.SetActive(true);
        _hintPanel.SetActive(true);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _borderHint.SetActive(false);
        _hintPanel.SetActive(false);
    }

    public void SetHiveMenu()
    {
        TimePause();
        _hiveOptionsUIPanel.SetActive(true);
    }

    public void TimePause()
    {
        _backgroundAudioSource.Pause();
        Time.timeScale = 0;
    }

    public void ContinueTime()
    {
        _backgroundAudioSource.UnPause();
        Time.timeScale = 1;
    }

    public void PlayNextBackgroundAudio()
    {
        if (_backgroundAudioClips.Length > 1)
        {
            _currentBackgroundAudioIndex++;
            if (_currentBackgroundAudioIndex >= _backgroundAudioClips.Length)
            {
                _currentBackgroundAudioIndex = 0;
            }

            _backgroundAudioSource.clip = _backgroundAudioClips[_currentBackgroundAudioIndex];
            _backgroundAudioSource.Play();
        }
    }

    private void LoadData(HiveData data)
    {
        _name = data.name;
        MaxIntegrityPoints = data.maxIntegrityPoints;
        BeeCapacity = data.beeCapacity;
        HoneyCapacity = data.honeyCapacity;
        NectarCapacity = data.nectarCapacity;
    }
}
