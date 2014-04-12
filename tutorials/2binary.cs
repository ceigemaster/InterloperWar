//============================Top==========================================

/* 
The binary number system is a base-2 numeral system
This number system uses number "places" much like the decimal number system (base-10) we are used to
We read "10" as the number ten because we know there is a 0 in the "ones place" and a 1 in the "tens place"
Much like the decimal number system, the places of the binary number system are read from right to left
Note that numbers in binary look like numbers in the base-10 number system
10 is ten in base-10, but in binary it is two
To clarify this confusion, binary numbers often have a prefix or suffix to indicate their base

100101 binary (explicit statement of format)
100101b (a suffix indicating binary format)
100101B (a suffix indicating binary format)
bin 100101 (a prefix indicating binary format)
1001012\/2 (a subscript indicating base-2 (binary) notation) I don't know how to enter subscript in VisualStudio, bear with me
%100101 (a prefix indicating binary format)
0b100101 (a prefix indicating binary format, common in programming languages)
6b100101 (a prefix indicating number of bits in binary format, common in programming languages)

In TorqueScript, we will use the suffix b
100101b

Note that binary digits should be read explicitly as one-zero-zero-one-zero-one (100101)
This way when spoken, 10b is not confused to either be ten or two
Even though it technically is four, one-zero explicitly tells us that it is two in binary, not base-10
Also note that binary is calculated from right to left, but read from left to right

Binary - Decimal Comparison

0b = 0
1b = 1
10b = 2
11b = 3
100b = 4
101b = 5
110b = 6
111b = 7
1000b = 8
1001b = 9
1010b = 10

You get the point, it goes on like that
Note that just like the base-10 number system, adding zeros to the left side of the number has no effect on its value
1b = 1
01b = 1
001b = 1
0001b = 1

==============================Converting Binary to Decimal================= 

Just as each place in the base-10 number system represents in increasing power of 10 (10=10^1, 100=10^2, 1000=10^3)
Each place in the binary number system represents an increasing power of 2
0000b = 2^0 = 0
0010b = 2^1 = 2
0100b = 2^2 = 4
1000b = 2^3 = 8

This can make it easy to calculate binary
100101b = [ ( 1 ) × 2^5 ] + [ ( 0 ) × 2^4 ] + [ ( 0 ) × 2^3 ] + [ ( 1 ) × 2^2 ] + [ ( 0 ) × 2^1 ] + [ ( 1 ) × 2^0 ]
100101b = [ 1 × 32 ] + [ 0 × 16 ] + [ 0 × 8 ] + [ 1 × 4 ] + [ 0 × 2 ] + [ 1 × 1 ]
100101b = [ 32 ] + [ 0 ] + [ 0 ] + [ 4 ] + [ 0 ] + [ 1 ]
100101b = 37

==============================Binary Arithmetic============================

Binary arithmetic is pretty simple
Because of the multitude of places that are common in the binary number system, it is perhaps most effective to use the "long forms" of arithmetic with "carrying"

==============================Binary Addition==============================

Addition rules for Binary
0 + 0 = 0
0 + 1 = 1
1 + 0 = 1
1 + 1 = 0, carry 1 (since 1 + 1 = 2 = 0 + (1 × 21) )

4 + 8 would be:

   0100
+  1000
-------
   1100

1100b = [ ( 1 ) * 2^3 ] + [ ( 1 ) * 2^2 ] + [ ( 0 ) * 2^1 ] + [ ( 0 ) * 2^0 ]
1100b = [ 1 * 8 ] + [ 1 * 4 ] + [ 0 * 2 ] + [ 0 + 0 ]
1100b = 8 + 4 + 0 + 0
1100b = 12
 
==============================Binary Subtraction===========================

Binary subtraction is just as simple

0 − 0 = 0
0 − 1 = 1, borrow 1
1 − 0 = 1
1 − 1 = 0

8 - 4 would be:

   1000
-  0100
-------
   0100 = 4

==============================Binary Multiplication========================

Binary multiplication is even simpler

0 * 0 = 0
1 * 0 = 0
0 * 1 = 0
1 * 1 = 1

4 * 4 would be:

    0100
x   0100
--------
    0000
   0000
  0100
+0000
--------
 0010000 or 10000 = 16

==============================Binary Division==============================

Binary division is slightly more complicated
Binary division is done similarly to decimal long division

4/14 would be:

     11 R 10
    ------
100 )1110
   - 100
   -----
     0110
    - 100
    -----
    R 010

11 R 10 = 3 R 2

==============================Binary Algebra===============================

Squaring, raising a binary number to a power or exponent, is simple too
Since the following equation uses variables, denoting that the numbers are binary will get confusing
If you come across this situation in your coding (say in bitwise operations)
Put a comment above the equation explicitly stating that it is in binary
Remembering your order of operations is ESPECIALLY IMPORTANT in coding
A mathematical mistake could be the difference between a script running smoothly or failing horribly
If you need to, work out your equations in decimal on paper to make sure you're getting the desired result

Let's solve an algebraic equation in binary

10x^10 + 100x - 110

We're going to solve for x
So set the equation equal to 0

10x^10 + 100x - 110 = 0

There are many different ways to do this (quadratic formula, factor-by-grouping, etc..)
First, we need to take out the greatest common denominator (GCD) which is 10

10(x^10 + 10x - 11) = 0

The number we factored out will not be necessary to help us find x, so we can ignore it from here on out
Now we can factor the equation

(x + 11) (x - 1) = 0

Since it is a quadratic equation, we know it should have two solutions
Set each factor equal to zero and solve for x

x + 11 = 0
x = -11

x - 1 = 0
x = 1

Our solutions are x = -11,1

==============================Binary Square Root===========================

Square root equations in binary are pretty complicated to solve without converting to decimal
We will use an algorithm similar to long division to help us solve
Let's do √625
 __________
√1001110001

We will separate the number every two places
 ______________
√10|01|11|00|01

Now let us imagine an empty space for a digit next to the radical
  ______________
_√10|01|11|00|01

We need to find a number that when multiplied by itself will not be greater than 10, the leftmost piece of 1001110001
1 Should work, similar to long division, we should put our number above the radical
   1|
1√10|01|11|00|01

Now multiply the number left of the radical (1) by the number we just put above the radical (1) and bring it below the leftmost piece of 1001110001 and subtract
The extra dividers and zeros should help give us a visual guide to keep our place

   1|
1√10|01|11|00|01
 -01
----
  01

Now we need add 1 to the number to the left of the radical (1 + 1 = 10), add a new space, and drop the next piece of 1001110001

     1|
10_√10|01|11|00|01
   -01
  ----
    0101

Now we need to see if we can fit a 1 in the new space, if we can, we will also put another 1 above the radical

     1| 1|
101√10|01|11|00|01
   -01
  ----
    0101
  - 0101
  ------
       0

Note that if we add the 1, and multiply the whole new number to the left of the radical (101) by 1 and bring it down we can safely subtract it

Again, we will add 1 to the number to the left of the radical
The new number will be 110, and we will add another new space, and bring down the next piece of 1001110001

      1| 1|
110_√10|01|11|00|01
    -01
   ----
     0101
   - 0101
   ------
        011

In this next step, if we were to add 1 to our new space, it would not work
The new number would be 1101 and we would multiply it by 1 and bring it down
However, we can not subtract 1101 from 11
This would give us a negative number, which we can not have in this problem
Therefore, we will instead add a 0

      1| 1| 0|
1100√10|01|11|00|01
    -01
   ----
     0101
   - 0101
   ------
        011
       -  0
       ----
         11

Because we used 0 instead of 1, we do not add 1 to the number left of the radical
However, we will still add a new space and bring down the next piece of 1001110001

       1| 1| 0|
1100_√10|01|11|00|01
     -01
    ----
      0101
    - 0101
    ------
         011
        -  0
        ----
          1100

Because the number we brought down is less than the number left of the radical, we know we have to put 0 in our new space as we can't have a negative number

       1| 1| 0| 0|
11000√10|01|11|00|01
     -01
    ----
      0101
    - 0101
    ------
         011
        -  0
        ----
          1100
          -  0
          ----
             0

Again, we used 0 instead of 1, nothing will be added to the number left of the radical
We will add a new space and bring down the next piece of 1001110001 for our last step

        1| 1| 0| 0|
11000_√10|01|11|00|01
      -01
     ----
       0101
     - 0101
     ------
          011
         -  0
         ----
           1100
           -  0
           ----
           110001

We can put safely put 1 in our new space


        1| 1| 0| 0| 1
110001√10|01|11|00|01
      -01
     ----
       0101
     - 0101
     ------
          011
         -  0
         ----
           1100
           -  0
           ----
           110001
         - 110001
         --------
                0

We have no other pieces of 1001110001 to bring down and our remainder is zero
The answer is the number above the radical
Therefore √1001110001 = 11001

That covers the basics of the binary number system
This should be sufficient should you need to use binary in your coding for the game engine
*/

//============================End==========================================