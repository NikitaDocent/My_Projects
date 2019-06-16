package com.nik;

public class FindAnswers {
    int n;
    double[][] l;
    double[][] u;
    double[] BMatrix;
    double[] YMatrix;
    double[] XMatrix;

    public FindAnswers(double[][] l, double[][] u, double[] B) {
        this.l = l;
        this.u = u;
        BMatrix = B;
        n = l.length;
    }

    public void GetAnswers() {
        System.out.println();
        System.out.println("L*Y = B");
        ShowSystem(l, "y", BMatrix);
        System.out.println();
        System.out.println("Y =");
        YMatrix = SolveSystemY(l, BMatrix);

        System.out.println();
        System.out.println("U*X = Y");
        ShowSystem(u, "x", YMatrix);
        System.out.println();
        System.out.println("X =");
        XMatrix = SolveSystemX(u, YMatrix);


    }

    private void ShowSystem(double[][] coef, String var, double[] B) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (coef[i][j] > 0 && j != 0) {
                    System.out.print(" + ");
                }
                if (coef[i][j] > 0) {
                    System.out.print(" ");
                }
                if (coef[i][j] != 0 && coef[i][j] != 1) {
                    System.out.format("%.1f", coef[i][j]);
                    System.out.print(var + (j + 1));
                } else if (coef[i][j] == 1 && j != 0) {
                    System.out.format(var + (j + 1));
                } else if (coef[i][j] == 1 && j == 0) {
                    System.out.format("\t" + var + (j + 1));
                }
            }
            System.out.format(" = %.0f%n", B[i]);
        }
    }

    private double[] SolveSystemY(double[][] matrix, double[] B) {
        double[] res = new double[matrix.length];
        for (int i = 0; i < matrix.length; i++) {
            if (i == 0) res[i] = B[i];
            else if (i == 1) {
                res[i] = B[i] - matrix[i][0] * res[0];
            } else if (i == 2) {
                res[i] = B[i] - matrix[i][0] * res[0] - matrix[i][1] * res[1];
            }
            System.out.print("y" + (i + 1));
            System.out.format(" %.1f%n", res[i]);
        }
        return res;
    }

    private double[] SolveSystemX(double[][] matrix, double[] Y) {
        double[] res = new double[matrix.length];
        double sum;
        for (int i = 2; i > -1; i--) {
            if (i == 2) res[i] = Y[i] / matrix[i][i];
            else if (i == 1) {
                res[i] = (Y[i] - matrix[i][2] * res[2]) / matrix[i][i];
            } else if (i == 0) {
                res[i] = (Y[i] - matrix[i][2] * res[2] - matrix[i][1] * res[1]) / matrix[i][i];
            }
        }
        for (int k = 0; k < matrix.length; k++) {
            if (res[k] == 0) {
                System.out.print("x" + (k + 1));
                System.out.println(" 0" + res[k]);
            } else {
                System.out.print("x" + (k + 1));
                System.out.format(" %.0f%n", res[k]);
            }
        }
        return res;
    }
}
