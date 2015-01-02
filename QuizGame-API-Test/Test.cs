﻿using NUnit.Framework;
using QuizGameAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame_API_Test
{
    public class Test
    {

        // ----- CATEGORIES ----- //

        [TestCase]
        public void GetCategories()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            
            List<String> categories = api.GetCategories();
            
            Assert.AreNotEqual(categories, null);
        }

        // ----- QUESTIONS ----- //

        [TestCase]
        public void GetQuestionByID()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            
            Question question = api.GetQuestion(1);
            
            Assert.AreNotEqual(question, null);
        }

        [TestCase]
        public void GetQuestions()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            
            List<Question> questions = api.GetQuestions();
            
            Assert.AreNotEqual(questions, null);
        }

        [TestCase]
        public void GetQuestionsByCategory()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            
            List<Question> questions = api.GetQuestionsByCategory("basic");
            
            Assert.AreNotEqual(questions, null);
        }

        [TestCase]
        public void AddQuestion()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("Solve 4 * 7");
            question.AddCategories("basic");
            question.AddAnswers("24", "26", "28", "30", "32");

            Question result = api.AddQuestion(question);

            Assert.AreNotEqual(result, null);
        }

        [TestCase]
        public void EditQuestion()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("Solve 3 + 5 * 10");
            question.AddCategories("basic");
            question.AddAnswers("80", "53", "35");

            Question result = api.AddQuestion(question);

            question.RemoveAnswers("80");

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Answers, result2.Answers);
        }

        [TestCase]
        public void DeleteQuestion()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("test", null, null);
            Question result = api.AddQuestion(question);

            Boolean success = api.DeleteQuestion(result.ID);

            Assert.AreEqual(success, true);
        }
    }
}
