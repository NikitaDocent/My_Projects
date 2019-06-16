package com.nik;

public class SecondLevel {

    static double f(double x) {
        return 3 * x - 2 * Math.pow(x,3) + 5;
    }

    static double y0(double x,double h){
        return f(x*h);
    }
    static double y1(double x,double h){
        return y0(x*h,h);
    }
    static double y2(double x, double h)
    {
        return 2*y1(x,h) + 3*x -2*Math.pow(x,3) + 5;
    }

    public void Method_Runga_Kute_4(double x, double xn, int n) {
        int i;
        double h;
        double y = 0;
        h = (xn - x) / n;

        for (i = 1; i <= n; i++)
        {
            double k1 = f(y0(x,h));
            double k2 = h*f(y1(x,h));
            double k3 = h*f(y2(x,h));
            double k4 = h*f(y2(x,h));
            y = k1 + 2*k2 + 2*k3 +k4;
            System.out.printf("\n\nОтвет: X = %f", x);
            System.out.printf("\n\nОтвет: Y = %f", y);
            x+=h;
        }
        System.out.printf("\n\nОтвет: Y = %f", y);
    }
}