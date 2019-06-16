package com.oksi;

import java.io.IOException;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) throws IOException {

        Scanner sc = new Scanner(System.in);
        BookShelf bookShelf = new BookShelf();

        System.out.println("Enter number of books: ");
        int books = sc.nextInt();

        System.out.println("Enter number of books of same author: ");
        int same_author = sc.nextInt();
        System.out.println("Result:" + bookShelf.ShelfCombimations(books, same_author));
//2nd Level
/*
        System.out.println("Enter number of odd digits: ");
        int digits = sc.nextInt();

        System.out.println("Enter size of array: ");
        int size = sc.nextInt();
        OddDecimal oddDecimal = new OddDecimal();
        System.out.println("Result:" + oddDecimal.DigitsCombimatictons(digits, size));
//3d Level
*/

bookShelf.getCombinations(books,same_author);
    }
}


