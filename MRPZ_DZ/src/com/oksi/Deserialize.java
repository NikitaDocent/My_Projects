package com.oksi;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.List;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

public class Deserialize implements Runnable
{
    private List<Person> my_data;
    private  String file;
    private transient static final long serialVersionUID = 1L;
    public Deserialize(List<Person> data , String filename) {
        this.my_data = data;
        this.file = filename;
    }
    Lock l = new ReentrantLock();
    @Override
    public void run()  {
        try {
            l.lockInterruptibly ();
            try {
                FileInputStream fileInputStream = new FileInputStream(file+".ser");
                ObjectInputStream objectInputStream = new ObjectInputStream(fileInputStream);

                my_data = (List<Person>) objectInputStream.readObject ();
            }
            finally {
                l.lock ();
            }

        }
        catch (FileNotFoundException e){System.out.println ( e.getMessage () );}
        catch (IOException e){System.out.println ( e.getMessage () );}
        catch(InterruptedException e){System.out.println ( e.getMessage () );}
        catch(ClassNotFoundException e){System.out.println ( e.getMessage () );}
    }

    public List<Person> GetData(){
        return my_data;
    }
}