package com.nik;


import java.util.Scanner;

public class FirstLevel {
    Scanner sc = new Scanner(System.in);
    private double[][] AMatrix;
    private double[] BMatrix;
    double[][] mat;
    int n;
    double[][] l;
    double[][] u;
    int[] pivot;
    double maxMod; //biggest number by abs
    int maxIndex; // index of a bigest number row
    int curFisrt; // current first row
    int higherRowINDX; //row index with the highest value
    double curFirstRow[];
    double higherRow[];

    public FirstLevel() {
        maxMod = 0; //biggest number by abs
        maxIndex = 0; // index of a bigest number row
        curFisrt = 0; // current first row
        higherRowINDX = 0; //row index with the highest value
        curFirstRow = null;
        higherRow = null;

    }

    public double[][] getL() {
        return l;
    }

    public double[][] getU() {
        return u;
    }

    public double[] getB() {
        return BMatrix;
    }


    public void Decompose() {
      //  System.out.println("Enter the dimension of the matrix:");
      //  n = sc.nextInt();
        n=4;
        mat = new double[n][n];
        l = new double[n][n];
        u = new double[n][n];
        AMatrix = new double[n][n];
        BMatrix = new double[n];
        pivot = new int[n];
        for (int j = 0; j < n; j++) {
            pivot[j] = j;
        }
        System.out.println("Enter the coefficients of the matrix:");
        for (int i = 0; i < n; i++) {
            System.out.println(i + 1 + " Row");
            for (int j = 0; j < n; j++) {
                double val = sc.nextDouble();
                mat[i][j] = val;
                AMatrix[i][j] = val;
            }
        }
        System.out.println("Matrix, you enter: ");
        ShowMatrix(mat);
       /* System.out.println("Enter the B-coefficients of the matrix:");
        for (int i = 0; i < n; i++) {
            BMatrix[i] = sc.nextDouble();
        }*/
       BMatrix[0] = 6;
       BMatrix[1] = -12;
       BMatrix[2] = -64;
       BMatrix[3] = 72;
        System.out.println("Matrix b-coeficients: ");
        for (double a:
             BMatrix) {
        System.out.println(a);
        }

        System.out.println("Finding matrix A'");
        FindAMatrix();
        CalculateLU();
        System.out.println("Matrix A': ");
        ShowMatrix(AMatrix);
        System.out.println("Matrix L: ");
        ShowMatrix(l);
        System.out.println("Matrix U: ");
        ShowMatrix(u);
        System.out.println("Matrix P: ");
        ShowPivotMatrix();

    }


    private void FindAMatrix() {
        for (int k = 0; k < n - 1; k++) {//k - as columns
            maxMod = 0;
            // searching the biggest abs of a column k
            FindMaxAbs(k);
            //Updating indexes k and maIndex
            UpdateIndexes(k);
            //changing rows
            ChangeRows(k);

            System.out.println(" Changed rows: ");
            ShowMatrix(AMatrix);
            // calculating decomposing elements
            CalculateCoef(k);

            System.out.println(k + 1 + " Step ");
            ShowMatrix(AMatrix);
        }
    }

    private void FindMaxAbs(int k) {
        for (int i = k; i < n; i++) {
            if (Math.abs(AMatrix[i][k]) > maxMod) {
                maxMod = Math.abs(AMatrix[i][k]);
                maxIndex = i;
            }
        }
        if (maxMod == 0) {
            throw new RuntimeException("Matrix is singular.");
        }
    }

    private void UpdateIndexes(int k) {
        curFisrt = pivot[k]; // current first index
        higherRowINDX = pivot[maxIndex]; // row index with the highest value
        pivot[k] = higherRowINDX;
        pivot[maxIndex] = curFisrt;
    }

    private void ChangeRows(int k) {
        curFirstRow = AMatrix[k];  // current first row
        higherRow = AMatrix[maxIndex]; // row with the highest value
        AMatrix[k] = higherRow;
        AMatrix[maxIndex] = curFirstRow;

        double bFisrt = BMatrix[k];
        double bHigher = BMatrix[maxIndex];
        BMatrix[k] = bHigher;
        BMatrix[maxIndex] = bFisrt;
    }

    private void CalculateCoef(int k) {
        for (int i = k + 1; i < n; i++) //leave the first row unchanged by i=k+1
        {
            AMatrix[i][k] = AMatrix[i][k] / AMatrix[k][k]; // divide left column on leading element
            for (int j = k + 1; j < n; j++) ////leave the first column by j=k+1
            {
                AMatrix[i][j] = AMatrix[i][j] - AMatrix[i][k] * AMatrix[k][j]; // elem = elem - leftmost*rightmost
            }
        }
    }

    private void CalculateLU() {
        l[0][0] = l[1][1] = l[2][2] = 1;
        l[0][1] = l[0][2] = l[1][2] = 0;
        u[1][0] = u[2][0] = u[2][1] = 0;

        u[0][0] = AMatrix[0][0];
        u[0][1] = AMatrix[0][1];
        u[0][2] = AMatrix[0][2];

        l[1][0] = AMatrix[1][0];
        u[1][1] = AMatrix[1][1];
        u[1][2] = AMatrix[1][2];

        l[2][0] = AMatrix[2][0];
        l[2][1] = AMatrix[2][1];
        u[2][2] = AMatrix[2][2];
    }

    private void ShowPivotMatrix() {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < pivot[i]; j++) {
                System.out.format(" 0");
            }
            System.out.print(" 1");
            for (int k = pivot[i] + 1; k < pivot.length; k++) {
                System.out.format(" 0");
            }
            System.out.println();
        }
    }

    private void ShowMatrix(double mat[][]) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] >= 0) {
                    System.out.print(" ");
                }
                System.out.format(" %.2f", mat[i][j]);
            }
            System.out.println();
        }
    }
}
