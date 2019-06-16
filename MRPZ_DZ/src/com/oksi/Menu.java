package com.oksi;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;



public class Menu implements Serializable {
    List<Person> products = new ArrayList<>();
    public void MenuShow() throws IOException {
        Service s = new Service ();

        System.out.println ( "Name for serialization:" );
        Scanner scan1 = new Scanner ( System.in );
        String file = scan1.nextLine ();

        Serialize serialize = new Serialize (products,file );
        Deserialize deSerialize = new Deserialize (products,file );
        BufferedReader br = new BufferedReader ( new InputStreamReader( System.in ) );

        while (true) {

            System.out.println ( "1. Create objects (person)" );
            System.out.println ( "2. Serialize" );
            System.out.println ( "3. Deserialize" );
            System.out.println ( "4. Information" );

            Scanner scan = new Scanner ( System.in );
            int _choose = scan.nextInt ();

            switch (_choose) {

                case 1:
                    products.add ( s.CreateProducts() );
                    System.out.println ( "Done!" );
                    br.read ();
                    break;
                case 2:
                    serialize.run ();
                    System.out.println ( "Done!" );
                    br.read ();
                    break;
                case 3:
                    deSerialize.run ();
                    products = deSerialize.GetData ();
                    System.out.println ( "Done!" );
                    br.read ();
                    break;
                case 4:
                    for (int i = 0; i< products.size (); i++){
                        System.out.println (  products.get ( i ).toString ());
                    }
                    System.out.println ( "Done!" );
                    br.read ();
                    break;
            }
        }
    }
}

