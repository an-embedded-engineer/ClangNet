#pragma once

namespace root
{
    namespace sub1
    {
        namespace sub2
        {
            class TestClass
            {
            public:
                TestClass();
                ~TestClass();

                void PublicMethod(int a, int b);

                int GetA() { return this->m_a; }
                int GetB() { return this->m_b; }
                int GetResult() { return this->m_result; }

                void SetA(int a) { this->m_a = a; }
                void SetB(int b) { this->m_b = b; }
                void SetResult(int result) { this->m_result = result; }

            private:
                int PrivateMethod(int a, int b);

            private:
                int m_a;
                int m_b;
                int m_result;
            };
        }
    }
}

