package com.oksi;
import com.sun.xml.internal.ws.api.addressing.AddressingVersion;

import java.util.Scanner;
import java.lang.*;
import java.util.*;

import static java.lang.Math.*;

/**
 * Created by Yana on 4/11/2017.
 */
public class Level2 {
    Scanner scanner = new Scanner(System.in);
    double EPS = 0.0001;

    static double function(double x) {
        return 3 - pow(x, 3) + sin((PI * 2) / 2);
    }

    static double derivative1(double x) {
        return (1 / 2) * PI * cos((PI * x) / 2) - 3 * pow(x, 2);
    }

    double Bisection_Method() {
        double A, B, root;
        System.out.println("Enter the interval: ");
        System.out.println("From :");
        A = Double.parseDouble(scanner.nextLine());
        System.out.println("To :");
        B = Double.parseDouble(scanner.nextLine());

        if (function(A) * function(B) >= 0) {
            System.out.println("!F(a) and f(b) should have opposite signs!");
            System.out.println("\tEnter new values:");
            Bisection_Method();
        }

        root = bisect(A, B);
        System.out.format("Root: %.5f%n", root);
        return root;
    }

    double bisect(double a, double b) {
        double c = 0;
        int iterationMax = 0;
        do {
            c = (a + b) / 2;
            if (function(a) * function(c) < 0) {
                b = c;
            } else {
                a = c;
            }
            if (Math.abs(function(c)) < EPS || (b - a) <= EPS || iterationMax == 10000) {
                break;
            }
            iterationMax++;
        }
        while (true);

        return c;
    }

    public double Newton_Kasatelnaya() {
        System.out.println("Enter the x-coordinate: ");
        double x = Double.parseDouble(scanner.nextLine());
        int t = 0;
        double x1, y;
        do {
            t++;
            x1 = x - function(x) / derivative1(x);
            x = x1;
            y = function(x);
        }
        while (Math.abs(y) >= EPS);
        System.out.format("Root: %.5f%n", x);
        return x;
    }

    public double Secant_Method() {
        double A, B, xlast, x = 0;
        int iterator = 0;
        System.out.println("Enter the interval: ");
        System.out.println("From :");
        A = Double.parseDouble(scanner.nextLine());
        System.out.println("To :");
        B = Double.parseDouble(scanner.nextLine());

        if (function(A) * function(B) >= 0) {
            System.out.println("!F(a) and f(b) should have opposite signs! \n Enter new values:");
            Secant_Method();
        }

        do {
            xlast = x;
            x = B - (function(B) * (B - A)) / (function(B) - function(A));
            if (function(x) * function(A) > 0) {
                A = x;
            } else {
                B = x;
            }
            iterator++;

            if (Math.abs(function(x)) < EPS || Math.abs(x - xlast) > EPS || (B - A) < EPS || iterator == 10000) {
                break;
            }
        } while (true);

        System.out.format("Root: %.5f%n", x);
        return x;
    }


    public double SecantMethod() {
        System.out.println("Enter the interval: ");
        System.out.println("From :");
        double x0 = Double.parseDouble(scanner.nextLine());
        System.out.println("To :");
        double x1 = Double.parseDouble(scanner.nextLine());

        if (function(x0) * function(x1) >= 0) {
            System.out.println("!F(a) and f(b) should have opposite signs! \n Enter new values:");
            Secant_Method();
        }
// Local variables
        double x, // Calculated value of x at each iteration
                f0, // Function value at x0
                f1, // Function value at x1
                fx, // Function value at calculated value of x
                root; // Root, if within desired tolerance
// Set initial function values
        f0 = function(x0);
        f1 = function(x1);
// Loop for finding root using Secant Method
        for (int i = 0; i < 1000; i++) {
            x = x1 - f1 * ((x1 - x0) / (f1 - f0));
            fx = function(x);
            x0 = x1;
            x1 = x;
            f0 = f1;
            f1 = fx;
// Check whether calculated value is within tolerance
            if (Math.abs(x1 - x0) < EPS) {
                root = x1;
                System.out.format("Root: %.5f%n", root);
                return root;
            } // end if
        } // end for

        System.out.format("Root: %.5f%n", x1);
        return x1;
    }
}

