package com.oksi;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        //LEVEL 1
        System.out.print("\tLevel\t1\n");
        System.out.println("enter a,b");

        System.out.println("a:");
        double a = Double.parseDouble(scanner.nextLine());
        System.out.println("b:");
        double b = Double.parseDouble(scanner.nextLine());
        double h = 0.2;

        System.out.format("\tRectangle medium = %.5f%n", Level1.rectangleMeth(a, b, h));
        System.out.format("\tRectangle left = %.5f%n", Level1.rectangleMethLeft(a, b, h));
        System.out.format("\tRectangle right = %.5f%n", Level1.rectangleMethRight(a, b, h));
        System.out.format("Deviation: %.5f%n", Level1.DeviationRect(a, b, h));

        System.out.format("\tTrapezium = %.5f%n", Level1.trapeziumMeth(a, b, h));
        System.out.format("Deviation: %.5f%n", Level1.DeriviationTparez(a, b, h));

        System.out.format("\tSimpson = %.5f%n", Level1.simpsonMeth(a, b, h));
        System.out.format("Deviation: %.5f%n", Level1.DeviationSimpson(a, b, h));


        // LEVEL 2
        System.out.print("\tLevel\t2\n");
        Level2 level2 = new Level2();

        System.out.println("\tBisection Method");
        level2.Bisection_Method();

        System.out.println("\tNewton Method");
        level2.Newton_Kasatelnaya();

        System.out.println("\tSecant  Method");
        level2.SecantMethod();

        // LEVEL 3
        Level3 level3 = new Level3();
        level3.Method_Runga_Kute_2(6.5,2.2,5.0,11.2,1);

    }
}

