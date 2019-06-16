package com.oksi;

import java.io.Serializable;
import java.util.Scanner;


public class Service implements Serializable {
    private transient static final long serialVersionUID = 1L;
    //List<NoteBook> notebooks = new List<> () ;
    public Person CreateProducts(){
        Scanner scan = new Scanner(System.in);
        System.out.println ( "Input name:" );
        String name = scan.nextLine ();
        System.out.println ( "Input surname:" );
        String surname = scan.nextLine ();
        System.out.println ( "Input fathername:" );
        String fathername = scan.nextLine ();
        System.out.println ( "Input address:" );
        String address = scan.nextLine ();

        System.out.println ( "Input mobile phone:" );
        int phone = scan.nextInt ();
        System.out.println ( "Input some information:" );
        String information = scan.nextLine ();

        Person newsubscriber = new Person( name,surname,fathername,address,phone, information );

        return  newsubscriber;

    }
}
