using UnityEngine;

public abstract class Hive : StaticObject
{
    private int _integrityPoints; // целостность улья
    private int _beeCapacity; // вместимость пчел
    private int _nectarСapacity; // вместимость нектара
    private int _honeyСapacity; // вместимость меда
    private int _hiveLevel;

    public void Fix()
    {
        // РЕАЛИЗОВАТЬ СУЧКИ
    }

    // Start is called before the first frame update
    void Start()
    {
        //_hiveLevel = PlayerPrefs.GetInt("Hive level");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
