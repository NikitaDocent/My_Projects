package com.oksi;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.util.List;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Serialize implements Runnable
{
    private List<Person> my_data;
    private String filename;
    private transient static final long serialVersionUID = 1L;
    public Serialize(List<Person> data, String filename) {
        this.my_data = data;
        this.filename = filename;
    }
    Lock l = new ReentrantLock();
    @Override
    public void run() {
        try {
            l.lockInterruptibly ();
            try {
                FileOutputStream fileOutputStream = new FileOutputStream ( filename+".ser" );
                ObjectOutputStream objectOutputStream = new ObjectOutputStream ( fileOutputStream );
                objectOutputStream.writeObject ( my_data );
                objectOutputStream.close ();

            }
            finally {
                l.lock ();
            }
        }
        catch (FileNotFoundException e){System.out.println ( e.getMessage () );}
        catch (IOException e){System.out.println ( e.getMessage () );}
        catch(InterruptedException e){System.out.println ( e.getMessage () );}
    }


}
