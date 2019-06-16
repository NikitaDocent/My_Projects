package com.nik;

public class Main {

    public static void main(String[] args)
    {
	    // FirsLevel
        FirstLevel firstLevel = new FirstLevel();
        firstLevel.Decompose();
        FindAnswers findAnswers = new FindAnswers(firstLevel.getL(),firstLevel.getU(),firstLevel.getB());
        findAnswers.GetAnswers();
        //SecondLevel
        SecondLevel secondLevel = new SecondLevel();
        secondLevel.Method_Runga_Kute_4(1.22,5.54,1);
    }
}

