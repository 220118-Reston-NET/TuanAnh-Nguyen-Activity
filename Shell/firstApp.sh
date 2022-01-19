# TUAN ANH NGUYEN
clear # To clear the terminal

# START PROGRAM
repeat="true"

while [ "$repeat" == true ]
do
echo "Welcome to my calculator!"
echo "Please enter the number to choose the program below that you want to do:"
echo "1. Sum the 3 input numbers"
echo "2. Solve the Quadratic Formula"
echo "0. Exit"
read ans

# 1. Sum of 3 numbers
if [ "$ans" == 1 ]
then
echo "Please enter your number"
read num1
read num2
read num3
echo "This is your sum of 3 numbers: $(($num1+$num2+$num3))"
echo "Press Enter to continue"
read returnBack

# 2. Solve the Quadratic Formula
elif [ "$ans" == 2 ]
then
echo "Here is the Quadratic Formula format: ax^2 + bx + c = 0"
echo "Please enter a,b,c:"
read numA
# 2.1 Check if number a is equal 0
if [ "$numA" == 0 ]
then
repeat2="true"
else
repeat2="false"
fi

while [ "$repeat2" == true ]
do
if [ "$numA" -ne 0 ]
then
repeat2="false"
else
echo "Number a must not be 0, please enter another a:"
read numA
fi
done

read numB
read numC
delta=$(($numA**2-4*$numB*numC))
# square_root=`echo "scale=4; sqrt($numA)" | bc`
# echo $square_root
if [ "$delta" == 0 ]
then
echo "x is: $((-$numB/(2*$numA)))"
elif [ "$delta" -gt 0 ]
then
echo "There are 2 of x in this case:"
square_root=`echo "(sqrt($delta))/1" | bc`
# echo $square_root
echo "x1: $(((-$numB+square_root)/($numA*2)))"
echo "x2: $(((-$numB-square_root)/($numA*2)))"
else
echo "There is no x in this case!"
echo "Press Enter to continue"
read returnBack
fi

# 0. Exitting the program
elif [ "$ans" == 0 ]
then
echo "Thank you."
repeat="false"

# Exception
else
echo "Please try another number showed in the menu.\n"
fi

done
# END PROGRAM