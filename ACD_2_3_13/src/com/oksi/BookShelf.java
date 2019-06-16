package com.oksi;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.LinkedList;
import java.util.List;

public class BookShelf {
    File file =  new File("C:\\Users\\power-user\\Desktop\\ACD_2_3_13","text.txt");
    FileWriter wr = new FileWriter(file);

    LinkedList mass = new LinkedList();

    public BookShelf() throws IOException {
    }

    private long Factorial(int variable) {
        long product = 1;
        int size = variable;
        for (int i = 0; i < size; i++) {
            product *= variable;
            variable--;
            mass.add(product);
        }
        return product;
    }

    public long ShelfCombimations(int m, int k) {
        return (Factorial(m - k + 1) * Factorial(k));
    }

    public void getCombinations(int m, int k) throws IOException {
        ShelfCombimations(m,k);
        for (Object a:
             mass) {
            wr.write(a.toString());
            System.out.println(a);
        }
        wr.flush();
        wr.close();
    }
}