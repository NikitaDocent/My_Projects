package com.nik;

import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {

    public static void main(String[] args) {
        // write your code here
        String str = "fhfjj@jfjf 9099@jj 67@";
        String[] strs = str.split("\\s");
        ArrayList<String> validStr = new ArrayList<>();
        Pattern pattern = Pattern.compile(".+@.+");
        Matcher matcher;
        for(int i = 0; i < strs.length;++i){
            matcher = pattern.matcher(strs[i]);
            if(matcher.matches()){
                validStr.add(strs[i]);
            }
        }
        for(int i = 0; i < validStr.size(); ++i)
            System.out.println(validStr.get(i));
    }
}