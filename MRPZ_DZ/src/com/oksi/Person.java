package com.oksi;

import java.io.Serializable;

public class Person implements Serializable
{
    private transient static final long serialVersionUID = 1L;

    public String name;
    public String surname;
    public String fathersname;
    public String address;
    public int phone;
    public String information;
    public Person(){}
    public Person(String name, String surname, String fathersname, String address, int phone, String information ){
        this.name= name;
        this.surname= surname;
        this.fathersname = fathersname;
        this.address = address;
        this.phone = phone;
        this.information = information;
    }

    @Override
    public  String toString(){
        return name+" "+surname+" "+fathersname+ " Address: "+address+" Mobile Phone: "+ phone+
                "Addition Information "+information;
    }
}