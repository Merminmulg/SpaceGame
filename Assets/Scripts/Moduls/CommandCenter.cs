using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipObj : MonoBehaviour
{
    public int price;
    public int hp;
    public abstract void LvlOne();
    public abstract void LvlTwo();
    public abstract void LvlThree();
}
public class CommandCenter : ShipObj
{
    public List<Frame> frames = new List<Frame>();
    public int frameLimit;
    public int modulsLimit;
    public List<ShipObj> moduls = new List<ShipObj>();
    private void Start()
    {
        frameLimit = 0;
        hp = 0;
        price = 100;
    }
    public void AddFrame()
    {
        if (frames.Count<frameLimit) {
            Frame temp = new Frame();
            hp += temp.hp;
            frames.Add(temp);
        }
    }
    public override void LvlOne()
    {
        frameLimit = 4;
        hp = 10;
        price = 300;
    }
    public override void LvlTwo()
    {
        frameLimit = 8;
        hp = 20;
        price = 900;
    }
    public override void LvlThree()
    {
        frameLimit = 12;
        hp = 30;
        
    }
}
public class Frame : ShipObj
{
    public List<ShipObj> shipObjs = new List<ShipObj>();
    public List<Engine> engines = new List<Engine>();
    public List<Battery> batteries = new List<Battery>();
    public List<Storage> storage = new List<Storage>();
    public List<Gun> guns = new List<Gun>();
    public List<Collector> collectors = new List<Collector>();
    public List<Converter> converters = new List<Converter>();
    public List<Generator> generators = new List<Generator>();
    public List<Rapairer> rapairers = new List<Rapairer>();

    private void Start()
    {
        price = 100;
    }
    public override void LvlOne()
    {
        hp = 100;
        price = 250;
    }
    public override void LvlTwo()
    {
        hp += 100;
        price = 625;
    }
    public override void LvlThree()
    {
        hp += 100;
    }
}
public class Engine : ShipObj
{
    public float energyLostForMoving;
    public float energyLostForBattle;
    private void Start()
    {
        price = 200;
    }
    public override void LvlOne()
    {
        hp = -10;
        price = 300;
        energyLostForMoving = (float)0.01;
        energyLostForBattle = (float)0.5;
}
    public override void LvlTwo()
    {
        hp = -8;
        price = 450;
        energyLostForMoving = (float)0.08;
        energyLostForBattle = (float)0.48;
    }
    public override void LvlThree()
    {
        hp = -5;
        energyLostForMoving = (float)0.06;
        energyLostForBattle = (float)0.45;
    }

}
public class Battery : ShipObj
{
    public int energyLimit;
    public override void LvlOne()
    {
        hp = 10;
        price = 150;
        energyLimit = 1000;
}
    public override void LvlTwo()
    {
        hp = 15;
        price = 300;
        energyLimit = 2000;
    }
    public override void LvlThree()
    {
        hp = 20;
        price = 450;
        energyLimit = 3000;
    }
}

public class Storage : ShipObj
{
    public int resourcesLimit;
    public override void LvlOne()
    {
        hp = 10;
        price = 50;
        resourcesLimit = 2000;
    }
    public override void LvlTwo()
    {
        hp = 15;
        price = 65;
        resourcesLimit = 3000;
    }
    public override void LvlThree()
    {
        hp = 20;
        price = 85;
        resourcesLimit = 4000;
    }
}
public class Gun : ShipObj
{
    public int damage;
    public float energyForShoot;
    private void Start()
    {
        energyForShoot = (float)0.05;
    }
    public override void LvlOne()
    {
        hp = -5;
        price = 150;
        damage = 50;
}
    public override void LvlTwo()
    {
        hp = -3;
        price = 270;
        damage = 60;
    }
    public override void LvlThree()
    {
        hp = -1;
        price = 486;
        damage = 75;
    }
}
public class Collector : ShipObj
{
    public float energyLost;
    public int resourcesForOneTime;
    private void Start()
    {
        energyLost = (float)0.01;
    }
    public override void LvlOne()
    {
        hp = 10;
        price = 75;
        resourcesForOneTime = 20;
    }
    public override void LvlTwo()
    {
        hp = 12;
        price = 131;
        resourcesForOneTime = 30;
    }
    public override void LvlThree()
    {
        hp = 15;
        price = 230;
        resourcesForOneTime = 40;
    }
}
public class Converter : ShipObj
{
    public int cpd;
    public override void LvlOne()
    {
        hp = -5;
        price = 200;
        cpd = 5;
    }
    public override void LvlTwo()
    {
        hp = -3;
        price = 270;
        cpd = 4;
    }
    public override void LvlThree()
    {
        hp = 0;
        price = 365;
        cpd = 3;
    }
}
public class Generator : ShipObj
{
    public float cpd;
    public override void LvlOne()
    {
        hp = 5;
        price = 250;
        cpd = (float)0.02;
    }
    public override void LvlTwo()
    {
        hp = 8;
        price = 388;
        cpd = (float)0.04;
    }
    public override void LvlThree()
    {
        hp = 10;
        price = 601;
        cpd = (float)0.06;
    }
}
public class Rapairer : ShipObj
{
    public int cpd;
    public override void LvlOne()
    {
        hp = 10;
        price = 350;
        cpd = 20;
    }
    public override void LvlTwo()
    {
        hp = 15;
        price = 438;
        cpd = 25;
    }
    public override void LvlThree()
    {
        hp = 30;
        price = 547;
        cpd = 30;
    }
}
