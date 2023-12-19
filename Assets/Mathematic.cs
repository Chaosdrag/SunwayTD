using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mathematic
{
    private Question[] questions;
    private List<Question> unansweredQuestions;


    public List<Question> InitialiseMathQuestion(int levelReached)
    {
        List<Question> mathQuestions;

        switch (levelReached)
        {
            case 1:
                Debug.Log("Math Level 1 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("Adding two positive numbers always results in a smaller number.", false),
                    new Question("3 + 4 = 7", true),
                    new Question("A triangle has 4 sides.", false),
                    new Question("Counting numbers start with the number 0.", false),
                    new Question("Shapes can have different sizes.", true)

                };
                mathQuestions = questions.ToList<Question>();
                break;

            case 2:
                Debug.Log("Math level 2 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("8 multiplied by 2 is less than 20.", false),
                    new Question("A prime number has only 2 factors.", true),
                    new Question("Subtraction is the same as addition, but in reverse.", true),
                    new Question("A right-angle measures 90 degrees.", true),
                    new Question("Fractions always represent a whole number.", false),
                    new Question("6 ÷ 3 = 2", true)

                };

                mathQuestions = questions.ToList<Question>();
                break;

            case 3:
                Debug.Log("Math level 3 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The square root of 16 is 5t.", false),
                    new Question("Pi is a rational number.", false),
                    new Question("Multiplying 2 negative numbers results in a positive number.", true),
                    new Question("The sum of the angles in a triangle is always 180 degrees.", true),
                    new Question("The equation 2x - 5 = 10 has no solution.", false),
                    new Question("9 is a prime number.", true),
                    new Question("14 - 8 = 6", false)

                };

                mathQuestions = questions.ToList<Question>();
                break;

            case 4:
                Debug.Log("Math level 4 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("In a right-angled triangle, the hypotenuse is the longest side.", true),
                    new Question("The commutative property states that the order of numbers does not affect addition.", false),
                    new Question("The decimal form of 1/4 is 0.25.", true),
                    new Question("The equation 2x + 3 = x has a unique solution.", false),
                    new Question("The mean is always greater than the median in a set of numbers.", false),
                    new Question("The product of 9 and 7 is 63.", true),
                    new Question("A hexagon has eight sides.", false),
                    new Question("The square root of 25 is 6.", false)

                };
                mathQuestions = questions.ToList<Question>();
                break;

            case 5:
                Debug.Log("Math level 5 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The range of a set of numbers is the difference between the smallest and largest values.", true),
                    new Question("The formula for the volume of a cone is V = (1/3)πr²h.", true),
                    new Question("The quadratic formula can be used to solve any quadratic equation.", true),
                    new Question("The sum of the interior angles of a hexagon is 540 degrees.", true),
                    new Question("The probability of rolling an even number on a six-sided die is 1/3.", false),
                    new Question("0.25 is equal to 1/4.", true),
                    new Question("10 squared is equal to 100.", true), 
                    new Question("The LCM of 6 and 8 is 48.", false),
                    new Question("The formula for the area of a circle is 2πr.", false)

                };
                mathQuestions = questions.ToList<Question>();
                break;

            default:
                return unansweredQuestions;
        }

        return mathQuestions;



    }
}
