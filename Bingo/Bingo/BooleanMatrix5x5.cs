using System;
using System.Collections.Generic;
using System.Text;

namespace Bingo
{
    public class BooleanMatrix5x5
    {
        public int matrix = 0;

        /* LR
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1000001000001000001000001b 
         * 0111110111110111110111110b
         * RL
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 
         * 0000100010001000100010000b
         * 1111011101110111011101111b
         */
        public bool CheckDiagonal(Diagonal diagonal)
        {
            int mask = 0;
            if (diagonal == Diagonal.LR)
                mask = 0xFBEFBE;
            if (diagonal == Diagonal.RL)
                mask = 0x1EEEEEF;
            return (matrix | mask) == 0xFFFFFF;
        }
// 1111110000000000000000000000000
        public bool CheckRow(Row row)
        {
            int mask = 0;
            switch (row)
            {
                case Row.First:
                    mask = 0x1F;
                    break;
                case Row.Second:
                    mask = 0x1F << 5;
                    break;
                case Row.Third:
                    mask = 0x1F << 10;
                    break;
                case Row.Fourth:
                    mask = 0x1F << 15;
                    break;
                case Row.Fifth:
                    mask = 0x1F << 20;
                    break;
            }
            mask = mask | 0x7E000000;
            mask = ~mask;
            return (matrix | mask) == 0xFFFFFF;
        }
        /*
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * 1 1 1 1 1
         * First
         * 0000100001000010000100001
         * 1111011110111101111011110
         * Second
         * 0001000010000100001000010
         * 1110111101111011110111101
         * Third
         * 0010000100001000010000100
         * 1101111011110111101111011
         * Fourth
         * 0100001000010000100001000
         * 1011110111101111011110111
         * Fifth
         * 1000010000100001000010000
         * 0111101111011110111101111
         * */
        public bool CheckColumn(Column column)
        {
            int mask = 0;
            switch (column)
            {
                case Column.First:
                    mask = 0x1EF7BDE;
                    break;
                case Column.Second:
                    mask = 0x1DEF7BD;
                    break;
                case Column.Third:
                    mask = 0x1BDEF7B;
                    break;
                case Column.Fourth:
                    mask = 0x17BDEF7;
                    break;
                case Column.Fifth:
                    mask = 0xF7BDEF;
                    break;
            }
            return (matrix | mask) == 0xFFFFFF;

        }
    }

    public enum Diagonal
    {
        LR,
        RL
    }
    public enum Column
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
    public enum Row
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
}
