using System.Threading;
using System.Collections.Generic;

public class CheatThread  {
    public delegate void   playerCreated(VisualTraits v);
    static public event playerCreated k_playerCreatedEvent;

    static public bool CANCREATE = true;
    List<VisualTraits> mList;
    int numberSent;

    public CheatThread()
    {
        numberSent = 0;
        mList = new List<VisualTraits>();
    }
    public void createObject()
    {
        Thread thread1 = new Thread(createObjects);
        thread1.Start();
    }

    private void createObjects()
    {
        
        VisualAlibiFactory _factory;
        _factory = VisualAlibiFactory.getInstance();
        if (_factory.CanCreateNewCharacter())
        {
            VisualTraits v = _factory.CreateVisualTrait();
            mList.Add(v);
        }
        else
        {
            CANCREATE = false;
        }
    }
    public void Update()
    {
        if(mList.Count > numberSent)
        {
            sendCreation(mList[numberSent]);
            numberSent++;
        }
    }
    void sendCreation(VisualTraits v)
    {
        k_playerCreatedEvent(v);
    }
}
