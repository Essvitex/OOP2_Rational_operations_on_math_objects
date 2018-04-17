# OOP2_Rational_operations_on_math_objects
Задача: реализовать арифметические операции - сложение, вычитание, умножение и деление для математических объектов. 
А также преобразование в строковое представление и обратно. 
Ниже приведены интерфейсы классов, необходимо реализовать методы и свойства.

Рациональные числа - числа, представимые в виде дроби M/N где M и N - целые числа. Нужно реализовать операции
    public struct Rational{
        /// Числитель дроби
        public int Numerator { get; set; }
        /// Знаменатель дроби
        public int Denominator { get; set; }
        /// Целая часть числа Z.N:D, Z. получается делением числителя на знаменатель и
        /// отбрасыванием остатка
        public int Base { get {} }
        /// Дробная часть числа Z.N:D, N:D
        public int Fraction { get {} }
        /// Операция сложения, возвращает новый объект - рациональное число,
        /// которое является суммой чисел c и this
        public Rational Add(Rational c) {}
        /// Операция смены знака, возвращает новый объект - рациональное число,
        /// которое являтеся разностью числа 0 и this
        public Rational Negate() {}
        /// Операция умножения, возвращает новый объект - рациональное число,
        /// которое является результатом умножения чисел x и this
        public Rational Multiply(Rational x){}
        /// Операция деления, возвращает новый объект - рациональное число,
        /// которое является результатом деления this на x
        public Rational DivideBy(Rational x){}
        /// Вовзращает строковое представление числа в виде Z.N:D, где
        /// Z — целая часть N и D — целые числа, числитель и знаменатель, N < D
        /// '.' — символ, отличающий целую часть от дробной,
        /// ':' — символ, обозначающий знак деления
        /// если числитель нацело делится на знаменатель, то
        /// строковое представление не отличается от целого числа
        /// (исчезает точка и всё, что после точки)
        /// Если Z = 0, опускается часть представления до точки включительно
        public override string ToString(){}
        /// Создание экземпляра рационального числа из строкового представления Z.N:D
        /// допускается N > D, также допускается
        /// Строковое представления рационального числа
        /// Результат конвертации строкового представления в рациональное
        /// число
        /// true, если конвертация из строки в число была успешной,
        /// false если строка не соответствует формату
        public static bool TryParse(string input, out Rational result){}
        /// Приведение дроби - сокращаем дробь на общие делители числителя
        /// и знаменателя. Вызывается реализацией после каждой арифметической операции
        private void Even(){}
    }
    
    Пользовательский интерфейс - командная строка. Необходимо реализовать следующие команды
add - сложение
sub - вычитание
mul - умножение
div - деление
Каждая из команд принимает два параметра - комплексные или рациональные числа соответственно (в соответствующих строковых представлениях, см комментарий к методу ToString).

Сессия работы программы может выглядеть примерно так:
Вариант:

  $ add 5:7 1.4:5
  2.18:35
  $ div 5:7 9:5
  25:63
  
Доп. задание
Переопределить с помощью операторов

Арифметические операции
Приведение типа:
к/из целому числу.
