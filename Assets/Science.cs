using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Science
{
    private Question[] questions;
    private List<Question> unansweredQuestions;


    public List<Question> InitialiseScienceQuestion(int levelReached)
    {
        List<Question> scienceQuestions;

        switch (levelReached)
        {
            case 1:
                Debug.Log("Science Level 1 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("Water can exist in three states: solid, liquid, and gas.", false),
                    new Question("The sun rises in the west", false),
                    new Question("Fish can breathe underwater.", false),
                    new Question("Ice is a type of gas.", false),
                    new Question("Rocks can float in water.", false)

                };
                scienceQuestions = questions.ToList<Question>();
                break;

            case 2:
                Debug.Log("Science level 2 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The Earth is the third planet from the sun.", true),
                    new Question("Plants get their energy from the sun through a process called photosynthesis.", true),
                    new Question("Sound travels faster than light.", false),
                    new Question("All insects have six legs.", true),
                    new Question("Oxygen is necessary for combustion to occur.", true),
                    new Question("Evaporation is the process of turning from solid to liquid.", false)

                };

                scienceQuestions = questions.ToList<Question>();
                break;

            case 3:
                Debug.Log("Science level 3 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The atomic number of an element represents the number of protons in its nucleus.", true),
                    new Question("Chemical reactions can change the mass of the substances involved.", false),
                    new Question("The Earth's atmosphere is mostly composed of nitrogen.", true),
                    new Question("Viruses are considered living organisms.", false),
                    new Question("The process of turning a gas into a liquid is called condensation.", true),
                    new Question("The Earth's atmosphere is mostly composed of nitrogen.", true),
                    new Question("Honey never spoils.", true)

                };

                scienceQuestions = questions.ToList<Question>();
                break;

            case 4:
                Debug.Log("Science level 4 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("Newton's third law of motion states that for every action, there is an equal and opposite reaction.", true),
                    new Question("Electrons have a positive charge.", false),
                    new Question("The human body has 206 bones at birth.", false),
                    new Question("A convex lens always converges light rays.", true),
                    new Question("Mitochondria are responsible for photosynthesis in plant cells.", false),
                    new Question("A day on Mars is approximately 24 hours and 39 minutes.", false),
                    new Question("Diamonds are made of compressed coals.", false),
                    new Question("A light-year is a measure of time.", false)

                };
                scienceQuestions = questions.ToList<Question>();
                break;

            case 5:
                Debug.Log("Science level 5 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("DNA is made up of four nucleotide bases: adenine, cytosine, guanine, and thymine.", true),
                    new Question("A supernova is an explosion that marks the death of a star.", true),
                    new Question("Boyle's Law describes the relationship between pressure and volume in a gas at constant temperature.", true),
                    new Question("Radioactive decay is a reversible process.", false),
                    new Question("The pH scale measures the concentration of hydrogen ions in a solution.", true),
                    new Question("The Great Wall of China is visible from space.", false),
                    new Question("Lightning never strikes the same place twice.", false), 
                    new Question("The largest bone in the human body is the femur.", true),
                    new Question("The Earth's core is made of solid gold.", false)

                };
                scienceQuestions = questions.ToList<Question>();
                break;

            default:
                return unansweredQuestions;
        }

        return scienceQuestions;



    }
}
