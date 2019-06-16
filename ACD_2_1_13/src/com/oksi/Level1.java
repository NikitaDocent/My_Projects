package com.oksi;

import java.util.Deque;

import static java.lang.Math.*;

/**
 * Created by Yana on 4/11/2017.
 */
public class Level1 {
    static double function(double x) {
        return sqrt(1 - 1 / 4 * pow(sin(x), 2));
    }

    static double rectangleMeth(double a, double b, double h)
    {
        int i, n;
        double result = 0;
        n = (int) ((b - a) / h);
        for (i = 0; i < n; i++) {
            result += function(a + h * (i + 0.5));
        }
        DeviationRect(a,b,n);
        return result * h;
    }

    static double rectangleMethLeft(double a, double b, double h) {
        int i, n;
        double result = 0;
        n = (int) ((b - a) / h);
        for (i = 0; i < n; i++) {
            result += function(a);
            a+=h;
        }
        DeviationRect(a,b,n);
        return result * h;
    }

    static double rectangleMethRight(double a, double b, double h) {
        int i, n;
        double result = 0;
        n = (int) ((b - a) / h);
        for (i = 0; i <= n; i++) {
            a+=h;
            result += function(a);
        }
        DeviationRect(a,b,n);
        return result * h;
    }


    static double DeviationRect(double a, double b, double h) {
        int n = (int) ((b - a) / h);
        double ratio = (pow((b - a), 3)) / (24 * pow(n,2));
        return ratio * Derivative2(a);
    }
    static double Derivative2(double x){
        return 1/4*(pow(sin(x),2)/sqrt(1- 1/ 4 * pow(sin(x),2))) - 1/4*(pow(cos(x),2)/sqrt(1- 1/ 4 * pow(sin(x),2))) - pow(sin(x),2)*pow(cos(x),2)/16*pow(1 - 1 / 4 * pow(sin(x), 2),(3/2));
    }

    static double trapeziumMeth(double a, double b, double h) {
        int n = (int) ((b - a) / h);
        double sum = 0, step;
        if (0 == n) return sum;
        step = (b - a) / (1.0 * n);
        for (int i = 1; i < n; ++i) {
            sum += function(a + i * step);
        }
        sum += (function(a) + function(b)) / 2;
        sum *= step;
        return sum;
    }
    static double DeriviationTparez(double a, double b, double h) {
        int n = (int) ((b - a) / h);
        double ratio =(pow((b - a), 3)) / (12 * pow(n,2));
        return ratio*Derivative2(a);
    }



    static double simpsonMeth(double a, double b, double h) {
        int n = (int) ((b - a) / h);
        double s = (function(a) + function(b)) * 0.5;
        for (int i = 1; i <= (n - 1); i++) {
            double xk = a + h * i;
            double xn = a + h * (i - 1);
            s += function(xk) + 2 * function((xn + xk) / 2);
        }
        double x = a + h * n;
        double x1 = a + h * (n - 1);
        s += 2 * function((x1 + x) / 2);
        return s * (h / 3.0);
    }

    static double DeviationSimpson(double a, double b, double h) {
        int n = (int) ((b - a) / h);
        double ratio =(pow((b - a), 5)) / (180 * pow(n,4));
        return ratio*Derivative4(a);
    }

    static double Derivative4(double x){
        return (21896*cos(2*x)-740*cos(4*x)+56*cos(6*x)+cos(8*x)+5411)/16*sqrt(2)*pow(cos(2*x)+7,7/2);
    }

}

