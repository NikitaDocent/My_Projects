package com.oksi;

enum Event { pressANY, EOS, pressPTICHKA, pressLETTER, pressZIRKA, pressDIGIT, pressAZ}
enum State { SUCCESS, ERROR, INITIAL, ZIRKA, LETTER, PTICHKA1, PTICHKA2, PTICHKA3, SYMBOL,  letterAZ }

public class Level2_FSM {

    String word;
    State currentState;
    Event event;
    int counter = 0;

    public Level2_FSM(String word) {
        this.word = word;
        currentState = State.INITIAL;
    }

    public boolean scanner() {
        char[] Word = word.toCharArray();
        int count = 0;

        do {
            if (count < Word.length)
                event = determineEvent(Word[count]); //Преобразование текущего символа в событие
            else
                event = Event.EOS;
            handleEvent(Word, count, event);
            count++;
        }
        while ((currentState != State.SUCCESS) && (currentState != State.ERROR));
        if (currentState == State.SUCCESS)
            return Boolean.TRUE;
        else
            return Boolean.FALSE;
    }

    protected Event determineEvent(char sym) {
        switch (sym) {
            case 'B': case 'C': case 'D': case 'E':
            case 'F': case 'G': case 'H': case 'I':
            case 'J': case 'K': case 'L': case 'M':
            case 'N': case 'O': case 'P': case 'Q':
            case 'R': case 'S': case 'T': case 'U':
            case 'V': case 'W': case 'X': case 'Y':
                event = Event.pressLETTER;
                break;
            case '0': case '1': case '2': case '3': case '4':
            case '5': case '6': case '7': case '8': case '9':
                event = Event.pressDIGIT;
                break;
            case '^':
                event = Event.pressPTICHKA;
                break;
            case '*':
                event = Event.pressZIRKA;
                break;
            case 'Z':case 'A':
                event = Event.pressAZ;
                break;
            default:
                event = Event.pressANY;
        }
        return event;
    }

    protected void handleEvent(char[] arr, int index, Event curEvent) {
        switch (currentState) {
            case INITIAL:
                switch (curEvent) {
                    case pressPTICHKA:
                        currentState = State.PTICHKA1;
                        break;
                    default:
                        currentState = State.ERROR;
                        break;
                }
                break;
            case PTICHKA1:
                switch (curEvent) {
                    case pressLETTER: case pressAZ:
                        currentState= State.LETTER;
                        break;
                    default:
                        currentState = State.ERROR;
                        break;
                }
                break;
            case LETTER:
                switch (curEvent) {
                    case pressLETTER: case pressAZ:
                        break;
                    case pressPTICHKA:
                        currentState = State.PTICHKA2;
                        break;
                    default:
                        currentState = State.ERROR;
                }
                break;
            case PTICHKA2:
                switch (curEvent) {
                    case pressZIRKA:
                        currentState = State.ZIRKA;
                        break;
                    default:
                        currentState = State.ERROR;
                        break;
                }
                break;
            case ZIRKA:
                switch (curEvent) {
                    case pressPTICHKA:
                        currentState = State.PTICHKA3;
                        break;
                    default:
                        currentState = State.ERROR;
                        break;
                }
                break;
            case PTICHKA3:
                switch (curEvent) {
                    case pressAZ: case pressDIGIT:
                        currentState = State.ERROR;
                        break;
                    default:
                        currentState = State.SYMBOL;
                        break;
                }
                break;
            case SYMBOL:
                switch (curEvent) {
                    case pressAZ: case pressDIGIT:
                        currentState = State.SUCCESS;
                        break;
                    case pressPTICHKA:
                       currentState = State.ERROR;
                    default:
                        break;
                }
                break;
        }
    }
}
