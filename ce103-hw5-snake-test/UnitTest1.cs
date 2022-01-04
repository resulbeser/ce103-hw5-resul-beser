using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce103_hw5_snake_dll;
namespace ce103_hw5_snake_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void collision_snake_test1()
        {
            Class1 collision = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 40;
            snakeXY[1, 0] = 10;
            Assert.AreEqual(false, collision.CollisionSnake(37, 7, snakeXY, 7, 1));
        }

        [TestMethod]
        public void collision_snake_test2()
        {
            Class1 collision = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 40;
            snakeXY[1, 0] = 10;
            Assert.AreEqual(false, collision.CollisionSnake(37, 10, snakeXY, 6, 1));
        }

        [TestMethod]
        public void collision_snake_test3()
        {
            Class1 collision = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 40;
            snakeXY[1, 0] = 10;
            Assert.AreEqual(false, collision.CollisionSnake(17, 16, snakeXY, 7, 1));
        }
        [TestMethod]
        public void eatfood_test_1()
        {
            Class1 eat = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 40;
            snakeXY[1, 0] = 10;
            int[] foodXY = { 5, 5 };
            Assert.AreEqual(false, eat.EatFood(snakeXY, foodXY));
        }

        [TestMethod]
        public void eatfood_test_2()
        {
            Class1 eat = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 25;
            snakeXY[1, 0] = 10;
            int[] foodXY = { 5, 5 };
            Assert.AreEqual(false, eat.EatFood(snakeXY, foodXY));
        }

        [TestMethod]
        public void eatfood_test_3()
        {
            Class1 eat = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 20;
            snakeXY[1, 0] = 15;
            int[] foodXY = { 5, 5 };
            Assert.AreEqual(false, eat.EatFood(snakeXY, foodXY));
        }
        [TestMethod]
        public void Collision_dedection_test1()
        {
            Class1 snake = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 40;
            snakeXY[1, 0] = 55;           
            Assert.AreEqual(false, snake.CollisionDetection(snakeXY,28,61,6));
        }

        [TestMethod]
        public void Collision_dedection_test2()
        {
            Class1 snake = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 30;
            snakeXY[1, 0] = 25;
            Assert.AreEqual(false, snake.CollisionDetection(snakeXY, 27, 58, 8));
        }

        [TestMethod]
        public void Collision_dedection_test3()
        {
            Class1 snake = new Class1();
            int[,] snakeXY = new int[2, 310];
            snakeXY[0, 0] = 75;
            snakeXY[1, 0] = 70;
            Assert.AreEqual(false, snake.CollisionDetection(snakeXY, 29, 75, 7));
        }
    }






}
