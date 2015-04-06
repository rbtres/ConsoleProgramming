using System.Threading;
using System.Collections.Generic;

public class CheatThread  {
    public delegate void   playerCreated(VisualTraits v);
    static public event playerCreated k_playerCreatedEvent;
    public void createObject()
    {
        Thread thread1 = new Thread(createObjects);
        thread1.Start();
    }

    private void createObjects()
    {
        VisualAlibiFactory _factory;
        _factory = VisualAlibiFactory.getInstance();
        VisualTraits v = _factory.CreateVisualTrait();
        k_playerCreatedEvent(v);
    }
}
