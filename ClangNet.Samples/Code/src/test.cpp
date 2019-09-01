#include <iostream>
#include "test.h"

using namespace std;

int Add(int a, int b)
{
    return a + b;
}

TestClass::TestClass(int a, int b)
{
    this->m_a = a;
    this->m_b = b;
}

int TestClass::Add()
{
    return this->m_a + this->m_b;
}

int main(void)
{
    cout << "Hello, World" << endl;

    int a = 1;
    int b = 2;

    int c = Add(a, b);

    return 0;
}
