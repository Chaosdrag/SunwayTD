using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class History
{
    private Question[] questions;
    private List<Question> unansweredQuestions;


    public List<Question> InitialiseHistoryQuestion(int levelReached)
    {
        List<Question> historyQuestions;

        switch (levelReached)
        {
            case 1:
                Debug.Log("History Level 1 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("Malaysia gained independence in 1957.", true),
                    new Question("Parameswara founded the city of Malacca.", true),
                    new Question("Malaysia has always been a single country throughout its history.", false),
                    new Question("The national flower of Malaysia is the hibiscus.", true),
                    new Question("Tunku Abdul Rahman was Malaysia's first Prime Minister.", true)

                };
                historyQuestions = questions.ToList<Question>();
                break;

            case 2:
                Debug.Log("History level 2 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The Portuguese were the first European colonial power to control Malacca.", true),
                    new Question("The Rukun Negara is Malaysia's national ideology.", true),
                    new Question("The Japanese occupied Malaya during World War II.", true),
                    new Question("Penang was named after a tree.", true),
                    new Question("The first Sultan of Perak was Sultan Mansur Shah.", false),
                    new Question("Kuala Lumpur is the capital city of Malaysia.", true)

                };

                historyQuestions = questions.ToList<Question>();
                break;

            case 3:
                Debug.Log("History level 3 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The 13 May Incident in 1969 was a political crisis in Malaysia.", true),
                    new Question("The Malayan Emergency was a conflict against communist insurgents.", true),
                    new Question("Malaysia is a constitutional monarchy and a parliamentary democracy.", true),
                    new Question("The Bujang Valley is an ancient archaeological site in Sabah.", false),
                    new Question("The Sultanate of Brunei was part of Malaysia at one point in history.", true),
                    new Question("The Malacca Sultanate was the first Malay kingdom.", true),
                    new Question("Malaysia was part of the British Empire during World War III.", false)

                };

                historyQuestions = questions.ToList<Question>();
                break;

            case 4:
                Debug.Log("History level 4 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The formation of Malaysia took place on 16 September 1963.", true),
                    new Question("The New Economic Policy (NEP) was introduced to address economic imbalances among different ethnic groups.", true),
                    new Question("The Battle of Pasir Panjang was a significant event during the Japanese occupation.", false),
                    new Question("The Petronas Towers were the tallest twin towers in the world at the time of completion.", true),
                    new Question("The May 13 Incident in 1969 led to the establishment of the National Operations Council.", true),
                    new Question("The Federal Constitution of Malaysia was enacted in 1957.", false),
                    new Question("The Langkawi Declaration in 1989 marked the official declaration of Langkawi as a duty-free island.", false),
                    new Question("The 1999 Malaysian constitutional crisis led to the removal of the Lord President.", true)

                };
                historyQuestions = questions.ToList<Question>();
                break;

            case 5:
                Debug.Log("History level 5 called");
                questions = new Question[]
                {
                    // Add more questions as needed
                    new Question("The Anglo-Dutch Treaty of 1824 divided the territories of Malaya between the British and the Dutch.", true),
                    new Question("The New Economic Policy (NEP) was introduced in Malaysia in 1961.", false),
                    new Question("The Malayan Union was established after World War II.", true),
                    new Question("The Renaissance was a period of renewed interest in classical art and learning.", false),
                    new Question("The National Front (Barisan Nasional) is a political coalition in Malaysia.", true),
                    new Question("The Malayan Communist Party (MCP) played a significant role during the Malayan Emergency.", true),
                    new Question("The Langkawi Declaration in 1989 emphasized regional cooperation in Southeast Asia.", true),
                    new Question("The Qing Dynasty ruled China from the 17th to the early 20th century.", false),
                    new Question("The 1Malaysia concept was introduced by Prime Minister Najib Razak.", false)

                };
                historyQuestions = questions.ToList<Question>();
                break;

            default:
                return unansweredQuestions;
        }

        return historyQuestions;



    }
}
