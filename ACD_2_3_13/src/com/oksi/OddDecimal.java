package com.oksi;
import java.math.BigInteger;

public class OddDecimal {
    private long Factorial(int variable) {
        BigInteger product = BigInteger.ONE;
        int size = variable;
        for (int i = 0; i < size; i++) {
            product = product.multiply(BigInteger.valueOf(variable));
            variable--;
        }
        return product.longValue();
    }
    public long DigitsCombimatictons(int m, int k) {
        long res = 0;
        if (m < 0 || k < 0) {
            System.out.println("Values cannot be negative!");
            return res;
        }
        res = (Factorial(m + k - 1) / (Factorial(k) * Factorial(m - 1)));
        return res;
    }
}


