#include <iostream>

#include "TestClass.h"

void RecursiveCallTest(int i);

int main()
{
    root::sub1::sub2::TestClass test_instance;
    int a = 10;
    int b = 5;
    int result = 0;

    test_instance.SetA(a);

    test_instance.SetB(b);

    std::cout << "a : " << test_instance.GetA() << std::endl;

    std::cout << "b : " << test_instance.GetB() << std::endl;

    test_instance.PublicMethod(a, b);

    result = test_instance.GetResult();

    std::cout << "result : " << result << std::endl;

    RecursiveCallTest(10);
}

void RecursiveCallTest(int i)
{
    if (i < 0)
    {
        return;
    }
    else
    {
        std::cout << "i : " << i << std::endl;

        RecursiveCallTest(i - 1);
    }
}

