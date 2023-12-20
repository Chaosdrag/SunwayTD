using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class English
{
    private Question[] questions;
    private List<Question> unansweredQuestions;

    public List<Question> InitialiseEnglishQuestion(int levelReached) 
    {
        List<Question> englishQuestions;

        switch (levelReached)
        {
            case 1:
                Debug.Log("English Level 1 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The sun is blue.", false),
                    new Question("Cats can fly.", false),
                    new Question("Apples come from trees.", true),
                    new Question("We read books with our noses.", false),
                    new Question("The letter 'A' is a number.", false)

                };
                englishQuestions = questions.ToList<Question>();
                break;

            case 2:
                Debug.Log("English level 2 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The word 'cat' has three letters.", true),
                    new Question("Birds can swim underwater.", false),
                    new Question("The opposite of 'big' is 'small'.", true),
                    new Question("The sky is usually green.", false),
                    new Question("Ice cream is a type of vegetable.", false),
                    new Question("The plural form of 'child' is 'childs'.", false)

                };

                englishQuestions = questions.ToList<Question>();
                break;

            case 3:
                Debug.Log("English level 3 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("A verb is a type of fruit.", false),
                    new Question("'Run' is an example of an adverb.", false),
                    new Question("Shakespeare was a famous playwright.", true),
                    new Question("The Amazon River is the longest river in the world.", false),
                    new Question("An octagon has six sides.", false),
                    new Question("The correct form of the plural for 'cactus' is 'cactuses'.", true),
                    new Question("'Its' is a contraction of 'it is.'.", false)

                };

                englishQuestions = questions.ToList<Question>();
                break;

            case 4:
                Debug.Log("English level 4 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("Alliteration is a figure of speech.", true),
                    new Question("'To be or not to be' is a famous line from Macbeth.", false),
                    new Question("A simile uses 'like' or 'as' to compare things.", true),
                    new Question("The prefix 'anti-' means 'before'.", false),
                    new Question("The Great Wall of China is the longest wall in the world.", true),
                    new Question("'Neither nor' is an example of a correlative conjunction.", true),
                    new Question("'Among' and 'between' can be used interchangeably.", false),
                    new Question("'The team are winning' is grammatically correct.", false)

                };
                englishQuestions = questions.ToList<Question>();
                break;

            case 5:
                Debug.Log("English level 5 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The Oxford comma is used before the conjunction in a list.", true),
                    new Question("The novel 'To Kill a Mockingbird' was written by Jane Austen.", false),
                    new Question("A palindrome is a word that reads the same backward as forward.", true),
                    new Question("The United Nations was established after World War I.", false),
                    new Question("In a debate, the affirmative side always supports the topic.", true),
                    new Question("The correct way to say 'I am' in short is 'I'mn't'.", false),
                    new Question("The opposite of 'brave' is .scared.'.", true),
                    new Question("'Jumped' is the past tense of 'jump'.", true),
                    new Question("A sentence always ends with a period.", false)

                };
                englishQuestions = questions.ToList<Question>();
                break;

            default:
                return unansweredQuestions;
        }

        return englishQuestions;

        

    }
}
