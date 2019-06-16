package com.oksi;
import static java.lang.Math.*;
import java.lang.*;

public class Level3 {

    static double f(double x, double y, double y1) {
        return 3 * x - 2 * y + 5;
    }

    public void Method_Runga_Kute_2(double x, double y, double y1, double xn, int n) {
        int i;
        double h;
        h = (xn - x) / n;
        for (i = 1; i <= n; i++) {

            y = y + h * (y1 + 2 * (y1 + 0.5 * h * y1) + 2 * (y1 + 0.5 * h * (y1 + 0.5 * h * y1)) + (y1 + h * (y1 + 0.5 * h * (y1 + 0.5 * h * y1)))) / 6;
            y1 = y1 + h * (f(x, y, y1) + 2 * f(x + 0.5 * h, y + 0.5 * h * f(x, y, y1), y1 + 0.5 * h * y1) + 2 * f(x + 0.5 * h, y + 0.5 * h * f(x + 0.5 * h, y + 0.5 * h * f(x, y, y1), y1 + 0.5 * h * y1), y1 + 0.5 * h * (y1 + 0.5 * h * y1)) + f(x + h, y + h * f(x + 0.5 * h, y + 0.5 * h * f(x + 0.5 * h, y + 0.5 * h * f(x, y, y1), y1 + 0.5 * h * y1), y1 + 0.5 * h * (y1 + 0.5 * h * y1)), y1 + h * (y1 + 0.5 * h * y1 + 0.5 * h * y1))) / 6;
            x = x + h;

        }
        System.out.printf("\n\nОтвет: Y = %f", y);
    }
}