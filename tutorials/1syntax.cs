//============================Top==========================================

// This file will show basic examples of TorqueScript in use
// TorqueScript is a high level scripting language based on C++
// Actually executing this script is not recommended, there are intentional syntax errors within
// Using find (ctrl+f) you can search this page to quickly find a topic you're interested in
// Note that all the headers are surrounded with =
// Using this I can search for "=variables=" if I want to see the topic that introduces variables

/* 
 * The three rules of syntax obeyed in the below example are:
 * -Ending a line with a semi-colon (;)
 * -Proper use of white space
 * -Commenting
*/

// Create test variable with a temporary variable
%testVariable = 3;

//============================Semi-colons==================================

// The following line shows an incorrect use of semi-colons
%testVariable = 3
%anotherVariable = 4;

// While it looks properly formatted, because of the lack of a semi-colon the engine will actually read it like this:
%testVariable = 3%anotherVariable = 4;
// This would obviously not work as intended

// An exemption to this rule would look something like this:
if(%testVariable == 4)
  echo("Variable equals 4");
// This basically says "read the first line, do the second line if we meet the requirements"

//============================Whitespace===================================

// The following code shows an incorrect use of whitespace:
%testVariable=3;
// While this will technically run without error, it is not good practice
// To keep the code easy to read, it should be rewritten as such:
%testVariable = 3;
//This clearly separates the variable from the value it is assigned to

// The following is another example of an incorrect use of whitespace:
if(%testVariable == 4) echo("Variable equals 4");
// While whitespace is used correctly with the variable and its corresponding value, note that this is an if-then function
// since the "echo" command is considered a function of "if" here, it should be formatted as such:
if(%testVariable == 4) 
    echo("Variable equals 4");

//============================Comments=====================================

// Any line starting with "//" is considered a comment
// Comments are ignored by the engine, they are only here for your benefit
// It is good practice to place comments above commands, or at the beginning of scripts
// Use comments well to explain lines of code so it is easy to see at a glance what you're intending to do

// Long comments can be denominated like this:
/* 
 * The long comment is denominated with an opening and closing tag
 * the opening tag is shown at the beginning and the closing tag is at the end
 * every other line is denominated with an asterisk (*) to show that it is also commented out
 * the (//) is typically used for single-line comments
 * use the long comment opening and closing tag for detailed comments that span multiple lines 
 */

// Comments can also be used to "comment out" unwanted lines of code temporarily

//============================Variables====================================

//  A variable is a letter, word, or phrase linked to a value stored in your game's memory and used during operations
// The following code creates a variable by naming it and assigning a value:
%localVariable = 3;

// You can assign any type value to the variable you want
// Below are all acceptable examples of assigning a variable:
%localVariable = 27;
%localVariable = "Heather";
%localVariable = "7 7 7";

// An important practice is proper variable naming 
// The following code will make a lot more sense, considering how the variables are named:
%userName = "Heather";
%userAge = 27;
%userScores = "7 7 7";

// With variables, TorqueScript is not case sensitive
%userName = "Heather";
echo(%Username);
// In the first line, we assign the value of the local variable userName to the string Heather
// In the second line, we tell the engine to "echo" or "print" the value of userName
// Even though it is typed in an incorrect case in the second line, the engine will accept it
// However, it is considered good practice to keep your capitalization consistent
// Problems may arise with the engine if your capitalization is not consistent
// Always double-check your grammar/syntax in your code!!
// This CAN NOT be stressed enough

// There are two types of variables: local and global
// Local variables are temporary and exist only in a specific block of code
// Global variables remain in memory during the entire program's execution

//============================Local Variables==============================

// This is an example of a local variable:
%localVariable = 1;
// Note that it is denominated by the (%)

// Here is another example:
function test()
{
   %userName = "Heather";
   echo(%userName);
}
// In this case, userName will only exist while the function test is being executed
// If we were to try and access the userName variable outside of this function, it would not be found

//============================Global Variables=============================

// This is an example of a global variable:
$globalVariable = 2;

// For the most part, you can declare global variables wherever you want
$PlayerName = "Heather";

function printPlayerName()
{
   echo($PlayerName);
}

function setPlayerName()
{
   $PlayerName = "Nikki";
}
// The first command is outside of any functions and declares the value of PlayerName to be Heather
// The first function prints PlayerName, note that we could also just do "echo($PlayerName);" outside of any functions
// The second function changes the value of PlayerName from Heather to Nikki, note this could just as easily be done outside of a function

//============================Data Types===================================

// TorqueScript implicitly supports several variable data-types: numbers, strings, booleans, and arrays and vectors

//============================Numeric Variables============================

/* 
 * TorqueScript handles standard numeric types
 * 123     (Integer)
 * 1.234   (floating point)
 * 1234e-3 (scientific notation)
 * 0xc001  (hexadecimal)
*/

// An example of a numeric variable:
%numberVariable = 1;

//============================String Variables=============================

// Raw text of almost any kind can be contained in strings
// A string is typically denominated by ("")
%stringVariable = "123";
%stringVariable = "poop";
%stringVariable = "$%&*(";

//============================Tagged Strings===============================

// Tagged strings are special in that they contain string data, but also have a special numeric tag associated with them
// Tagged strings are used for sending string data across a network
// The value of a tagged string is only sent once, regardless of how many times you actually do the sending
// On subsequent sends, only the tag value is sent. Tagged values must be de-tagged when printing. 
// You will not need to use a tagged string often unless you are in need of sending strings across a network often, like a chat system
// This is an example of a tagged string:
%taggedVariable = 'Apes';
// Note that a tagged string is denoted with (' ')
// Think of it like this, the tagged string has the value of "Apes" but also has a tag value, sort of like an ID for the tag

// This sets the global variable a equal to 'This is a tagged string'
$a = 'This is a tagged string';
// This will print " Tagged string: " and the tag value of the string
// Because it has not been detagged, only the tag value (ID number) will be printed
echo("  Tagged string: ", $a);
// This will print "Detagged string: " and the string value of $a
// However, since this has not be sent to you over a network, it will bring a blank value
echo("Detagged string: ", detag('$a'));

//============================String Operators=============================

// There are also string operations that you can use on strings and string variables
// They are used similarly to mathematical operators

//The @ symbol concetenates (or adds) the two strings together
%newString = "Hello" @ "World";
//It would come out like this:
HelloWorld
// Note that there is no space between the words of the new string
// You will have to add spaces yourself with this operator

// The SPC symbol adds a space automatically and concetenates the strings
%newString = "Hello" SPC "World";
// It comes out like this:
Hello World
// Note that SPC strings can be decomposed with getWord() which will be covered later

// The TAB symbol adds a tab between the strings
%newString = "Hello" TAB "World";
Hello       World

// The NL symbols puts a new-line in betwen the strings
%newString = "Hello" NL "World";
Hello
World

// String variables can also be used in place of explicit string values
%helloString = "Hello";
%worldString = "World";

echo(%helloString @ %worldString);

HelloWorld

//============================Boolean Variables============================

// TorqueScript also supports booleans
// Booleans only have true or false values, represented numerically as 1 or 0 respectively
// So true = 1 and false = 0, however all non-zero values are considered to be true
// Think of booleans as "on/off" switches, often used in conditional (if-then) statements
$lightsOn = true;

if($lightsOn)
  echo("Lights are turned on");
// The first command sets lightsOn equal to true, or 1
// The function then says "if lightsOn is equal to 1, then echo "Lights are turned on"
// Note that in the function it is not explicitly stated that lightsOn needs to be equal to 1
// This is an inherent function of the if-then function, it does not need to be expliclity stated

//============================Array Variables==============================

// Arrays are data structures used to store consecutive values of the same data type
// Therefore there are numerical arrays, string arrays, and boolean arrays
// A string value can not be in a numerical array, and so on and so forth
// Arrays are denominated as such:
%arrayData[0] = "a";
%arrayData[1] = "b";
%arrayData[2] = "c";
// Note that the same variable is used to store all three numbers
// The position in the array is denominated by the numbers within the []
// All arrays start at position 0, and many more spaces can be filled onward to your heart's content
// If we were to print the whole array, it would look something like this:
[0] [1] [2]
// And with the data assigned to the array earlier, it would look like this:
[a] [b] [c]

// Arrays are useful if you want to store similar variables
// They are faster and create cleaner code
// Here is an example of how an array would be more useful than assigning multiple global variables
$firstUser = "Heather";
$secondUser = "Nikki";
$thirdUser = "Mich";

echo($firstUser);
echo($secondUser);
echo($thirdUser);
// Instead of doing that, you could do this:
$userNames[0] = "Heather";
$userNames[1] = "Nikki";
$userNames[2] = "Mich";

echo($userNames[0]);
echo($userNames[1]);
echo($userNames[2]);

// Using looping structures can make using arrays even easier
// This will be covered later

// You can also create multidimensional arrays:
$testArray[0,0] = "a";
$testArray[0,1] = "b";
$testArray[0,2] = "c";

$testArray[1,0] = "d";
$testArray[1,1] = "e";
$testArray[1,2] = "f";

$testArray[2,0] = "g";
$testArray[2,1] = "h";
$testArray[2,2] = "i";
// The array would be represented like this:
[0,0] [0,1] [0,2]
[1,0] [1,1] [1,2]
[2,0] [2,1] [2,2]
// And the data would look like this:
[a] [b] [c]
[d] [e] [f]
[g] [h] [i]

//============================Vector Variables=============================

// TorqueScript also uses vectors
// Vectors are strings that store numerical values in sets of 2 or 3
// They are typically used to represent world position
// An objects position would be stored as (X Y)
%position = "25  34"
// Since the variable is assigned as a string (""), but contains a set of 2 numerical values, it is interpreted as a vector
// The coordinates would be (25, 34)
// This is considered a 2 element vector
// You can separate the values using spaces or tabs, both are acceptable whitespace
// To make vectors easily distinguished from other strings, we will consider it good practice to put 2 spaces in between each value

// Another example is storing color data in a four element vector
// The values that make up a color are "Red Blue Green Alpha," which are all numbers
%firstColor = "100  100  100  1.0"
// Color values range from 0 to 255, and alpha values range from 0.0 to 1.0
// Alpha values control the density of the represented color where 0.0 is transparent and 1.0 is opaque
// Color can get much more complicated, but here we are learning about vectors, not colors

// You can also create a vector using numeric variables
%red = 128;
%blue = 255;
%green = 64;
%alpha = 1.0;

%secondColor = %red SPC %blue SPC %green SPC %alpha;
// Note that string operations can be used for vectors too, as vectors are stored as strings

//============================Mathematical Operators=======================

// TorqueScript can also use mathematical operators
// These are largely the same as the operators you learned in math class, with some small syntactical changes
// Note that with all operators, numerical variables can be used in the places of the explicit numeric values

// The * sign is used for muliplication
echo(4 * 8);
32

// The / sign is used for division
echo(4 / 2);
2

// The % (modulo) sign is used to give the remainder of a division problem
echo(5 % 2);
1

// The + sign is used for addition
echo(2 + 2);
4

// The - sign is used for subtraction
echo(2 - 2);
0

// The ++ sign auto-increments the variable by 1
$a = 1;
echo($a++);
2
// In order of operations, the variable will always be incremented before any other operations are calculated

// The -- sign auto-decrements the variable by 1
$a = 2;
echo($a--);
1
// In order of operations, the variable will always be decremented before any other operations are calculated

//============================Rational Operators===========================

// Rational operators are used in comparing values and variables against each other
// Rational operators always return in 1 or 0 (true or false)
// There are three kinds of rational operators: arithmetic, logical, and string

// The arithmetic rational operators are:

// < (less than) returns 1 if $a is less than % (the remainder of) b (0 otherwise)
$a = 1;
$b = 2;

echo($a < $b);
1

// > (greater than) returns 1 if $a is greater than % (the remainder of) b (0 otherwise)
$a = 2;
$b = 1;

echo($a > $b);
1

// <= (less than or equal to) returns 1 if $a is less than or equal to % (the remainder of) b (0 otherwise)
$a = 1;
$b = 2;

echo($a <= $b);
1

// >= (greater than or equal to) returns 1 if $a is greater than or equal to % (the remainder of) b (0 otherwise)
$a = 2;
$b = 1;

echo($a >= $b);
1

// == (equal to) returns 1 if $a is equal to % (the remainder of) b (0 otherwise)
$a = 2;
$b = 2;

echo($a == $b);
1

// != (not equal to) returns 1 if $a is not equal to % (the remainder of) b (0 otherwise)
$a = 1;
$b = 2;

echo($a != $b);
1

// The logical rational operators are:

// ! (NOT) returns 1 if $a is 0 (otherwise 0)
$a = 1

echo(!$a);
0

// && (logical AND) returns 1 if both $a and $b are not 0 (otherwise 0)
$a = 1;
$b = 3;

echo($a && $b);
1

// || (logical OR) returns 1 if either $a or $b are not 0 (otherwise 0)
$a = 0;
$b = 1;

echo($a || $b);
1

// The string rational operators are:

// $= (string equal to) returns 1 if $a is equal to $b (otherwise 0)
$a = "poop";
$b = "PooP";

echo($a $= $b);
0

// !$= (string not equal to) returns 1 if $a is not equal to $b (otherwise 0)
$a = "poop";
$b = "483";

echo($a !$= $b);
1

//============================Bitwise Operators============================

// Bitwise Operators are used for comparing and shifting bits
// They use boolean logic for evaluation
// At this point you are not expected to understand the significance of doing so
// However, it belongs here with syntax, for reference when you do need it
// Bitwise operations are considered much faster ways to perform mathematical operations
// This is because they are directly supported by the processor and use less resources
// However, you will almost never have to use bitwise operators in Torque, unless you are dealing with raycasts and type masks
// Bitwise operations use the binary number system, and as such you are expected to know binary in order to use them
// The suffix b is added to the numbers to represent that they are in binary
// A separate guide will cover the binary number system in detail
// It is complicated to pass values to the console through TorqueScript explicitly in binary
// That will be covered later, for now we will just show the basic function of the operators

// ~ (bitwise NOT or complement) flips bits 1 to 0 and 0 to 1

~10b == 01b

// & (bitwise AND) compares two bit values and if the value is 1 in the same place in both values, the output will be one

1 & 1 = 1
1 & 0 = 0
0 & 1 = 0
0 & 0 = 0

1100b & 1010b == 1000b

// Think of it like this:

1|1|0|0 b
1|0|1|0 b

// In the first place the value is 1 in both the first value AND the second value, so the output will be 1

1|

// In the next place the first value is 1 but the second value is 0, so the output will be 0

1|0|

// In the third place the first value is 0 and the second value is 1, so the output will be 0

1|0|0|

// In the final place neither value is 1, so the output will be 0

1|0|0|0
1000b

// | (bitwise OR) compares two binary values and returns 1 for each place where either number has a 1

1 | 1 = 1
1 | 0 = 1
0 | 1 = 1
0 | 0 = 0

1100b | 1010b = 1110b

// ^ (bitwise XOR or NOT OR) compares two binary values and returns 1 for each place that is the opposite of the other

1 ^ 1 = 0
1 ^ 0 = 1
0 ^ 1 = 1
0 ^ 0 = 0

1100b ^ 1010b = 0110b

// << (left shift) element is shifted N (in this case 3) places to the left and padded with zeros

11b << 3 = 11000b

// >> (right shift) element is shifted N (in this case 3)places to the right and padded with zeros

11b >> 3 = 00011b

//============================Assignment Operators=========================

// Assignment operators are used for setting the value of variables

$a = 1;
$b = 2;
$a = $b;

echo($a);
2

// First we set $a equal to 1 and $b equal to 2, then we set $a equal to $b
// This changes the value of $a from 1 to 2
// Note that $a = $b = $c would also be legal
// The value would be passed from the right to the left, and would be the same as saying $a = $c and $b = $c

// *= (mulitplication assignment) sets $a equal to the value of $a * $b

$a = 3;
$b = 2;

echo($a *= $b);
6

// /= (division assignment) sets $a equal to the value of $a / $b

$a = 6;
$b = 3;

echo($a /= $b);
2

// %= (modulo assignment) sets $a equal to the value of $a % $b

$a = 3;
$b = 2;

echo($a %= $b);
1

// += (addition assignment) sets $a equal to the value of $a + $b

$a = 1;
$b = 1;

echo($a += $b);
2

// -= (subtraction assignment) sets $a equal to the value of $a - $b

$a = 3;
$b = 2;

echo($a -= $b);
1

// &= (bitwise AND assignment) sets $a equal the the value of $a & $b
// Note that this is a bitwise assignment, so the calculations are performed on binary numbers
// You can't actually assign variables to binary numbers in this way (it will save it as 1,011 not one-zero-one-one)
// The operations below are just performed to demonstrate how they work
// Assigning a binary number to a variable is too complicated to demonstrate in a syntax tutorial

$a = 1011b;
$b = 1101b;

echo($a &= $b);
1001b

// ^ (bitwise XOR assignment) sets $a equal to the value of $a ^ $b
// Note that this is a bitwise assignment, so the calculations are performed on binary numbers

$a = 1010b;
$b = 1100b;

echo($a ^= $b);
0110b

// << (left shift assignment) shifts $a N places to the left, pads it with zeros, and sets $a equal to the result
// Note that this is a bitwise assignment, so the calculations are performed on binary numbers

$a = 1;

echo($a <<= 3);
1000b

// >>(right shift assignment) shifts $a N places to the right, pads it with zeros, and sets $a equal to the result

$a = 1;

echo($a >>= 3);
0001

//============================Structures===================================

// TorqueScript provides basic branching structures to help control the flow of work and logic in your coding

//============================If, Then, Else Structure=====================

// The if, then, else structure is a type of structure used to test a condition, then perform certain actions if the condition passes or fails
// It basically says "if this is true, then do this, otherwise do this"

// Inside the <boolean expression> parentheses, you would put a boolean variable
if(<boolean expression>) 
{
   // If it evaluates to true, this will be done
   pass logic
}
else 
{
   // If it evaluates to false, this will be done
   alternative logic
}
// Note that, you do not always have to provide the else portion of the structure
// The engine will assume "if this, then this, otherwise, do nothing" if this is the case

// Here is an example of how an if,then,else structure would be useful:

// Global variable that controls lighting
$lightsShouldBeOn = true;

// Check to see if lights should be on or off
if($lightsShouldBeOn)
{
   // True. Call turn on lights function
   turnOnLights();

   echo("Lights have been turned on");
}
else
{
   // False. Turn off the lights
   turnOffLights();

   echo("Lights have been turned off");
}

// Brackets for single line statements are optional
// If you think you are going to add additional logic to the code, then you should use brackets anyway
// However, if you know you will only use one logic statement, you can use the following syntax:

// Global variable that controls lighting
$lightsShouldBeOn = true;

// Check to see if lights should be on or off
if($lightsShouldBeOn)
  turnOnLights();   // True. Call turn on lights function
else
  turnOffLights(); // False. Turn off the lights

//============================Switch Structures============================

// If you end up using multiple cascading if,then,else structures in your code, it would be wiser to use a switch structure instead
// Switch structures are easier to manage and read
// The syntax of a switch statement is as follows:

switch(<numeric expression>) 
{
   case value0:
       statements;
   case value1:
       statements;
   case value3:
       statements;
   default:
       statements;
}

// It is a good idea to always use the default case in your structures
// This anticipates any rogue values (values you do not expect to be passed into the code)
// You can use this to help you debug (have default print a message to the console if it catches a rogue value)
// Or simply use it to tell the structure to do nothing if it encounters rogue values, safely ending your script without errors

// There are two types of switch structures: numerical and string

// Numerical switch structures only properly evaluate numerical expressions

switch($ammoCount)
{
   case 0:
      echo("Out of ammo, time to reload");
      reloadWeapon();
   case 1:
      echo("Almost out of ammo, warn user");
      lowAmmoWarning();
   case 100:
      echo("Full ammo count");
      playFullAmmoSound();
   default:
      doNothing();
}

// String switch structures can evaluate string expressions
// The syntax is similar to that of the numerical switch structure

switch$ (<string expression>) 
{
   case "string value 0":
       statements;

   case "string value 1":
       statements;
...
   case "string value N":
       statements;

   default:
       statements;
}

// The $ sign appended to the switch command will automatically cause the expression to be parsed (evaluated) as a string
// This insinuates that you can also put in numeric or boolean values and it will simply evaluate them as strings

// Here is an example of how a string switch structure would be useful:

// Print out specialties
switch($userName)
{
   case "Heather":
      echo("Sniper");
   case "Nikki":
      echo("Demolition");
   case "Mich":
      echo("Meat shield");
   default:
      echo("Unknown user");
}

//============================Loop Structures==============================

// Loop structures are used to repeat logic in a loop based on an expression
// This is usually used on a set of variables that increase by count or a constant that changes once the loop reaches a certain point
// There are two types of loops: the for loop and the while loop

// Three parameters are passed into the for loop, and the logic is then run based on the value of those parameters

for(startExpression; testExpression; countExpression) 
{
    statement(s);
}

// Here, %count is assigned to 0, and the structure is told to execute until %count is no longer less than 3
// Then the structure is told to increment %count by 1 continually
// The logic says that as long as %count is less than three, it will print the value of %count to the console

for(%count = 0; %count < 3; %count++) 
{
    echo(%count);
}

OUTPUT:
0
1
2

// A while loop is a much simpler structure than a for loop

while(expression) 
{
    statements;
}

// As soon as the expression is met, the loop will terminate

%countLimit = 0;

while(%countLimit <= 5)
{
   echo("Still in loop");
   %countLimit++;
}
echo("Loop was terminated");

// First, %countLimit is set to 0, then the while loop runs as long as %countLimit is less than or equal to 5
// The  while loop says to print to the console every time it runs that it is still in the loop, then increment %countLimit
// A message will print to the console when the loop terminates

//============================Functions====================================

// Much of your TorqueScript experience will come down to calling existing functions and writing your own
// Functions are a blocks of code that only execute when you call them by name. Basic functions in TorqueScript are defined as follows:

// function - Is a keyword telling TorqueScript we are defining a new function.
// function_name - Is the name of the function we are creating.
// ... - Is any number of additional arguments.
// statements - Your custom logic executed when function is called
// return val - The value the function will give back after it has completed. Optional.

function function_name([arg0],...,[argn]) 
{
    statements;
    [return val;]
}

// Return values can be useful for debugging
// For example, you can tell a function to return the value 1 after completion, 
// If it does, you will know that the return value of 1 means the function executed successfully

// TorqueScript can take any number of arguments, as long as they are comma separated 
// If you call a function and pass fewer parameters than the function's definition specifies 
// The un-passed parameters will be given an empty string as their default value

// This creates the function echoRepeat and defines the variables that will be its parameters
function echoRepeat (%echoString, %repeatCount) 
{
   // The function is a for loop that creates the variable %count, states that the loop will be run as long
   // as %count is less than %repeatCount, and states that %count will be incremented each time the loop is run
   for (%count = 0; %count < %repeatCount; %count++)
   {
      // when the loop is run, it will print %echoString to the console
      echo(%echoString);
   }
}

// You can cause this function to execute by calling it in the console, or in another function
// Now that we have made our function, we can execute it 
// We call the function echoRepeat, set %echoString equal to "hello!", and set %repeatCount equal to 5
// This will cause the function to print "hello!" 5 times
echoRepeat("hello!", 5);

OUTPUT:
"hello!"
"hello!"
"hello!"
"hello!"
"hello!"
// Note that all the variables defined in this function are local (%)
// This means that if we try to ask for the value of %echoString, %repeatCount, or %count
// Outside of this function, we will not get a value in return, because they do not exist outside of echoRepeat
// However, functions are globally defined
// This means we can call echoRepeat anywhere in this script file or (if we specify the pathname) in any other script
// Functions are incredibly useful, they keep us from having to repeat coding and are extremely flexible
// If we were to define a new function also named echoRepeat, the old one would be forgotten
// Whichever echoRepeat is executed last will be the one that is retained globally in memory

// Console functions are functions that are already written in C++ and are inherent to the Torque engine
// You can call these at any time during your scripts
// The echo function is an example of a console function
// It is written in C++ and has been compiled into the Torque engine to be used in TorqueScript coding
// This is the echo function as it is written in C++

ConsoleFunction(echo, void, 2, 0, "echo(text [, ... ])")
{
   U32 len = 0;
   S32 i;
   for(i = 1; i < argc; i++)
      len += dStrlen(argv[i]);

   char *ret = Con::getReturnBuffer(len + 1);
   ret[0] = 0;
   for(i = 1; i < argc; i++)
      dStrcat(ret, argv[i]);

   Con::printf("%s", ret);
   ret[0] = 0;
}

// Most of this should look like nonsense to us
// Without this function, we would have to write this in C++ every time we wanted to print something to the console
// Console Functions save us from having to write C++ functions ourselves or attempt to create a TorqueScript equivalent

//============================Objects======================================

// The most complex aspect of TorqueScript involves dealing with game objects. One thing to remember is that everything in TorqueScript is a string 
// However, when accessing a sprite, sceneObject, or any other object, a string is converted to an object ID under the hood
// Simply put, every object has a handle (ID) and a name
// The handle is the ID of the object, this is generated whenever an object is created
// The name is the way the user will know the object, this is stored with the variable

// This is the syntax of an object definition:

// We set a variable called %objectID, we use the keyword "new" to tell the engine to create a new object
// ObjectType is the class that the object will be defined as
// Classes are defined in the engine (some object classes have already been defined for us in C++) or in script (we can create our own classes)
// Name is where we put the handle for the object
// This is optional, we could choose to not name it
%objectID = new ObjectType(Name) 
{   
   // Here is where we define class members (referred to as fields), think of this as defining the qualities of the object
   // We can define existing qualities (those that already exist in C++)
   [existing_field0 = InitialValue0;]
   ...
   [existing_fieldN = InitialValueN;]
   // We can also define qualities that are unique specifically to our object
   [dynamic_field0 = InitialValue0;]
   ...
   [dynamic_fieldN = InitialValueN;]
};

// Here is an example of an object being created in TorqueScript:

// In this example, Truck is the name of the object
new SceneObject(Truck) 
{
   // These are existing qualities, note that they are vectors
   position = "0  0";
   size = "5  5";
};

//============================Methods======================================

// ConsoleMethods can also be used in conjunction with functions to allow us to get specific data about our objects
// ConsoleMethods are in C++ and inherent to the engine
// The syntax is:

objHandle.function_name();

objName.function_name();
// The method is called using a .
// The object can either be referred to by its handle (ID) or its name (if one was given)
// Note that methods are simply functions attached to objects

// Below is an example of how methods can be used to help us deal with objects:

// We create the SceneObject Truck, as before
new SceneObject(Truck) 
{
   // Give it the same qualities
   position = "0 0";
   size = "5 5";
};

// .dump() prints all possible methods we can use with this objects to the console
// Note that the object is referred to by name here
Truck.dump();

// We create $objID and set it equal to the value of the handle (ID) of Truck
// .getID() will give us the numerical ID (handle) of the object
$objID = Truck.getID();

// Print the ID to the console
echo("Object ID: ", $objID);

// We create %position and set it equal to the value of the object's position
// .getPosition() gives us the object's position, using the object's handle
%position = $objID.getPosition();

// Print the position to the console
echo("Object Position: ", %position);

// We can also create our own methods that have no C++ counterpart
// In TorqueScript methods are created with ::, but still called with .
// Remember that methods are simply functions that we attach to objects that fall under a certain class
// Therefore, creating a method is very similar to creating a function
// This is the correct syntax to create a method:

// We start using the keyword function to tell the engine that we are creating a function
// We use Classname to define the class of objects that this is supposed to work with
// func_name gives a name to the method
// %this is the variable that will contain the handle (ID) of the calling object (in Truck.getID() Truck is the calling object)
// Any number of other arguments can be passed into the function ([arg0],...,[argn])
function Classname::func_name(%this, [arg0],...,[argn]) 
{
   // Here is where we will put our logic statements
   // Remember these are the statements that run when we call the method
   statements;
   // We can ask it to give a return value as well for debugging
   [return val;]
}

// Here is an example of creating a method:

// The classname is Samurai, so any object that falls into the Samurai class can use this method
// The function name is sheatheSword, this is how we call the method
// %this stores the handle of the calling object
function Samurai::sheatheSword(%this)
{
    echo("Katana sheathed");
}

// Let's say we created an object in the Samurai class, and we wanted to use this method
// Let's imagine the handle (ID) for this object is 1042

1042.sheatheSword();

OUTPUT: "Katana sheathed"
// Note that we did not pass the %this parameter
// This is inherent to the method we created
// We passed no other parameters because we only defined one parameter (%this) for the method

// That covers pretty much everything as far as the basics of syntax and scripting in Torque
// The next guide (2binary) is optional, you will most likely not need to use the bitwise operators or binary mathematics in TorqueScript
// They are there for reference regardless
// You can move on to 3engine to continue familiarizing yourself with the Torque engine and TorqueScript

//============================End==========================================