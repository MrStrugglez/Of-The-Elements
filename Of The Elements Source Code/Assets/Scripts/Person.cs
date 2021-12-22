using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Person
{
    private int personId;    
    private string name;
    private string surname;

    public Person()
    {

    }

    protected Person(int personId, string name, string surname)
    {
        this.personId = personId;
        this.name = name;
        this.surname = surname;
    }

    public int PersonId
    {
        get { return personId; }
        set { personId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }
}
