using System;
using Library;

namespace Labatym12
{
    class Program
    {
        static void Main()
        {
            bool isTaskEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("Лабораторная работа Тумакова №12");

                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 12.1.              -   цифра 1\n" +
                                  "Упражнение 12.2.              -   цифра 2\n" +
                                  "Домашнее задание 12.1.        -   цифра 3\n" +
                                  "Домашнее задание 12.2.        -   цифра 4\n" +
                                  "Закончить выполнение заданий  -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Упражнение 12.1");

                        BankAccount firstBankAccount = new BankAccount(1000000, AccountType.Текущий_счет);
                        BankAccount secondBankAccount = new BankAccount(784562, AccountType.Сберегательный_счет);
                        BankAccount thirdBankAccount = new BankAccount(1000000, AccountType.Текущий_счет);

                        Console.WriteLine("Проверка операции == :");
                        if (firstBankAccount == secondBankAccount)
                        {
                            Console.WriteLine(firstBankAccount.ToString() + " равнен " + secondBankAccount.ToString());
                        }
                        else
                        {
                            Console.WriteLine(firstBankAccount.ToString() + " неравнен " + secondBankAccount.ToString());
                        }

                        Console.WriteLine("Проверка операции != :");
                        if (firstBankAccount != thirdBankAccount)
                        {
                            Console.WriteLine(firstBankAccount.ToString() + " неравнен " + thirdBankAccount.ToString());
                        }
                        else
                        {
                            Console.WriteLine(firstBankAccount.ToString() + " равнен " + thirdBankAccount.ToString());
                        }

                        Console.WriteLine("Проверка метода Equals:");
                        if (firstBankAccount.Equals(secondBankAccount))
                        {
                            Console.WriteLine(firstBankAccount.ToString() + " равнен " + secondBankAccount.ToString());
                        }
                        else
                        {
                            Console.WriteLine(firstBankAccount.ToString() + " неравнен " + secondBankAccount.ToString());
                        }

                        Console.Write("Нажмите на кнопку чтобы завершить задание");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Упражнение 12.2");

                        RationalNumber firstRationalNumber = RationalNumber.MakeRationalNumber(1, 2);
                        RationalNumber secondRationalNumber = RationalNumber.MakeRationalNumber(3, 4);

                        Console.WriteLine("Сумма: " + firstRationalNumber.ToString() + " + " + secondRationalNumber.ToString() + $" = {firstRationalNumber + secondRationalNumber}");
                        Console.WriteLine("Разность: " + firstRationalNumber.ToString() + " - " + secondRationalNumber.ToString() + $" = {firstRationalNumber - secondRationalNumber}");
                        Console.WriteLine("Умножение: " + firstRationalNumber.ToString() + " * " + secondRationalNumber.ToString() + $" = {firstRationalNumber * secondRationalNumber}");
                        Console.WriteLine("Деление: " + firstRationalNumber.ToString() + " / " + secondRationalNumber.ToString() + $" = {firstRationalNumber / secondRationalNumber}");
                        Console.WriteLine("Деление с остатком: " + firstRationalNumber.ToString() + " % " + secondRationalNumber.ToString() + $" = {firstRationalNumber % secondRationalNumber}");
                        Console.WriteLine("Инкремент: ++" + firstRationalNumber.ToString() + $" = {++firstRationalNumber}");
                        Console.WriteLine("Декремент: --" + secondRationalNumber.ToString() + $" = {--secondRationalNumber}\n");


                        Console.WriteLine("Равно: " + firstRationalNumber.ToString() + " == " + secondRationalNumber.ToString() + $" => {firstRationalNumber == secondRationalNumber}");
                        Console.WriteLine("Неравно: " + firstRationalNumber.ToString() + " != " + secondRationalNumber.ToString() + $" => {firstRationalNumber != secondRationalNumber}");
                        Console.WriteLine("Больше: " + firstRationalNumber.ToString() + " > " + secondRationalNumber.ToString() + $" => {firstRationalNumber > secondRationalNumber}");
                        Console.WriteLine("Меньше: " + firstRationalNumber.ToString() + " < " + secondRationalNumber.ToString() + $" => {firstRationalNumber < secondRationalNumber}");
                        Console.WriteLine("Больше или равно: " + firstRationalNumber.ToString() + " >= " + secondRationalNumber.ToString() + $" => {firstRationalNumber >= secondRationalNumber}");
                        Console.WriteLine("Меньше или равно: " + firstRationalNumber.ToString() + " <= " + secondRationalNumber.ToString() + $" => {firstRationalNumber <= secondRationalNumber}\n");

                        Console.WriteLine("Приведение типов в float: (float)" + secondRationalNumber.ToString() + $" => {(float)secondRationalNumber}");
                        Console.WriteLine("Приведение типов в int: (int)" + firstRationalNumber.ToString() + $" => {(int)firstRationalNumber}");

                        Console.Write("Нажмите на кнопку чтобы завершить задание");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Домашнее задание 12.1");

                        ComplexNumber firstComplexNumber = new ComplexNumber(5, 9);
                        ComplexNumber secondComplexNumber = new ComplexNumber(15, -7);

                        Console.WriteLine("Сумма: " + firstComplexNumber.ToString() + " + " + secondComplexNumber.ToString() + $" = {firstComplexNumber + secondComplexNumber}");
                        Console.WriteLine("Разность: " + firstComplexNumber.ToString() + " - " + secondComplexNumber.ToString() + $" = {firstComplexNumber - secondComplexNumber}");
                        Console.WriteLine("Умножение: " + firstComplexNumber.ToString() + " * " + secondComplexNumber.ToString() + $" = {firstComplexNumber * secondComplexNumber}\n");

                        Console.WriteLine("Равно: " + firstComplexNumber.ToString() + " == " + secondComplexNumber.ToString() + $" => {firstComplexNumber == secondComplexNumber}");
                        Console.WriteLine("Неравно: " + firstComplexNumber.ToString() + " != " + secondComplexNumber.ToString() + $" => {firstComplexNumber != secondComplexNumber}");

                        Console.Write("Нажмите на кнопку чтобы завершить задание");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Домашнеее задание 12.2");

                        SortDelegate sortByTitle = book => book.BookTitle;
                        SortDelegate sortByAuthor = book => book.BookAuthor;
                        SortDelegate sortByPublishingHouse = book => book.PublishingHouse;

                        Book firstBook = new Book("Тростник и хлопок", "Черномазов", "Нигерсбук");
                        Book secondBook = new Book("Негры и пистолеты", "Блэкманов", "Даркбук.компани");
                        Book thirdBook = new Book("Бедная жизнь негритенка Федота", "Ф.Ф.Федоров", "Федикулит");
                        Book fourtBook = new Book("Как создать свою банду", "Чернымырев", "БлэкМафия");
                        Book fifthBook = new Book("Насколько неприкольный черный цвет или как сделать свою жизнь белее", "Саня Белый", "НАсколько жизнь классасная");

                        BooksContainer.AddBookToList(firstBook, secondBook, thirdBook, fourtBook, fifthBook);

                        Console.WriteLine("Сортировка по названию: \n");
                        BooksContainer.SortingListOfBooks(sortByTitle);

                        foreach (Book book in BooksContainer.BooksList)
                        {
                            Console.WriteLine(book.ToString());
                        }

                        Console.WriteLine("\nСортировка по автору: \n");
                        BooksContainer.SortingListOfBooks(sortByAuthor);

                        foreach (Book book in BooksContainer.BooksList)
                        {
                            Console.WriteLine(book.ToString());
                        }

                        Console.WriteLine("\nСортировка по издательству: \n");
                        BooksContainer.SortingListOfBooks(sortByPublishingHouse);

                        foreach (Book book in BooksContainer.BooksList)
                        {
                            Console.WriteLine(book.ToString());
                        }

                        Console.Write("Нажмите на кнопку чтобы завершить задание");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Завершение работы");
                        isTaskEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такого задания не существует");
                        break;
                }
            } while (!isTaskEnd);
        }
    }
}