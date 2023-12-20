using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Geography
{
    private Question[] questions;
    private List<Question> unansweredQuestions;


    public List<Question> InitialiseGeoQuestion(int levelReached)
    {
        List<Question> geoQuestions;

        switch (levelReached)
        {
            case 1:
                Debug.Log("Geography Level 1 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("Malaysia is in Southeast Asia.", true), 
                    new Question("Kuala Lumpur is the capital city of Malaysia.", true), 
                    new Question("The longest river in Malaysia is the Kelantan River.", false), 
                    new Question("Penang is an island located on the east coast of Malaysia.", true), 
                    new Question("Mount Kinabalu is the highest mountain in Malaysia.", true) 

                };
                geoQuestions = questions.ToList<Question>();
                break;

            case 2:
                Debug.Log("Geography level 2 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The South China Sea is the body of water to the east of Peninsular Malaysia.", true), 
                    new Question("Malaysia is divided into two regions: East Malaysia and West Malaysia.", true), 
                    new Question("The Cameron Highlands are known for their hot and humid climate.", false), 
                    new Question("The Titiwangsa Range runs along the west coast of Peninsular Malaysia.", true), 
                    new Question("The Straits of Malacca connect the South China Sea to the Andaman Sea.", false), 
                    new Question("The Gulf of Thailand lies to the east of Peninsular Malaysia.", false) 

                };

                geoQuestions = questions.ToList<Question>();
                break;

            case 3:
                Debug.Log("Geography level 3 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("Langkawi is an archipelago consisting of 99 islands.", true), 
                    new Question("The Crocker Range in Sabah is a mountain range running parallel to the west coast.", false), 
                    new Question("The Borneo Rainforest is one of the oldest rainforests in the world.", true), 
                    new Question("The Johor-Singapore Causeway connects Malaysia to Indonesia.", false), 
                    new Question("The Malaysian state of Sarawak is located on the island of Borneo.", true), 
                    new Question("The Strait of Johor separates Peninsular Malaysia from Sumatra.", false), 
                    new Question("The Gulf of Thailand is on the west coast of Peninsular Malaysia.", false) 

                };

                geoQuestions = questions.ToList<Question>();
                break;

            case 4:
                Debug.Log("Geography level 4 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The Malaysian state of Sabah is located on the island of Java.", false), 
                    new Question("The Coral Triangle, known for its marine biodiversity, includes waters off the coast of Malaysia.", true), 
                    new Question("Malaysia has a tropical climate characterized by high temperatures and high humidity.", false), 
                    new Question("The Sultan Abdul Samad Building is in Putrajayan.", false), 
                    new Question("The Malacca Sultanate was a powerful maritime and commercial empire.", true), 
                    new Question("The Sultanate of Brunei is completely surrounded by the Malaysian state of Sarawak.", false), 
                    new Question("The Sepang International Circuit hosts the Formula One Malaysian Grand Prix.", true), 
                    new Question("The Malayan Union came into existence on April 1, 1946, with Sir Edward Gent as the governor.", true)

                };
                geoQuestions = questions.ToList<Question>();
                break;

            case 5:
                Debug.Log("Geography level 5 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The city of Kota Kinabalu is the capital of the Malaysian state of Sarawak.", false),
                    new Question("The Cameron Highlands are known for their tea plantations.", true),
                    new Question("The Strait of Malacca is one of the busiest shipping lanes in the world.", true),
                    new Question("The Borneo Rainforest is shared by Malaysia, Indonesia, and Brunei.", true),
                    new Question("The Kinabatangan River is the longest river in Malaysia.", false),
                    new Question("The National Physical Plan (NPP) guides Malaysia's spatial development.", true),
                    new Question("The state of Pahang is the largest state in Peninsular Malaysia.", true),
                    new Question("The city of Kuching is the capital of the Malaysian state of Sabah.", false),
                    new Question("The Cameron Highlands are part of the Main Range, also known as the Banjaran Titiwangsa.", true)

                };
                geoQuestions = questions.ToList<Question>();
                break;

            default:
                return unansweredQuestions;
        }

        return geoQuestions;



    }
}
