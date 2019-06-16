package com.oksi;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        ///First Level
        RegExpressionLevel regExpressionLevel = new RegExpressionLevel();
        regExpressionLevel.MathText2REgexs();
        System.out.println(regExpressionLevel.arrText.get(0));
        ///Second level
        Level2_FSM level2_fsm = new Level2_FSM("Lokomotiv");
        System.out.println(level2_fsm.scanner());
        level2_fsm.word = "^HG^*^\nAZ\n8^";
        System.out.println(level2_fsm.scanner());
    }
}

