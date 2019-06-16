package com.oksi;

import java.io.*;

enum Event { pressANY, EOS, pressPTICHKA, pressLETTER, pressZIRKA, pressDIGIT, pressAZ}

public class Level3 {
    public Level3() throws IOException {}
    File file = new File("C:\\Users\\power-user\\Desktop\\ACD_2_2_13\\text2.txt");
    BufferedReader fin = new BufferedReader(new FileReader(file));
    Level2_FSM level2_fsm = new Level2_FSM(fin.readLine());
}

interface press
{
    void even(char symb);
}

 class pressLetter implements press
{
    @Override
    public void even(char symb) {

    }
}

 class pressZirka implements press
{
    @Override
    public void even(char symb) {

    }
}

 class pressPtichka implements press
{
    @Override
    public void even(char symb) {

    }
}
 class pressDigit implements press
{
    @Override
    public void even(char symb) {

    }
}

 class pressAZ implements press
{
    @Override
    public void even(char symb) {

    }
}
