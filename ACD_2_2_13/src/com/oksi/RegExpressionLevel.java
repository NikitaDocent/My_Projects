package com.oksi;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class RegExpressionLevel {

    static String path = "C:\\Users\\power-user\\Desktop\\ACD_2_2_13\\text1.txt";
    private String regex = "\\^[A-Z]+\\^\\*\\^[A-Z]+\\^";
    private Matcher matcher;
    ArrayList<String> arrText = new ArrayList<String>();
    Pattern pattern = Pattern.compile(regex);

    void MathText2REgexs() {
        try (BufferedReader fin = new BufferedReader(new FileReader(path))) {
            String line;
            while ((line = fin.readLine()) != null) {

                matcher = pattern.matcher(line);
                System.out.println("Line: " + line);
                if (matcher.matches()) {
                    arrText.add(line);
                    System.out.println("\tMatch in word: " + line + "\n");
                }
//                else
//                    System.out.println("\t\t\t\t\tNo matches");
            }
        } catch (IOException e) {
            System.out.println("IO Exception occurred!");
        }

    }
}
