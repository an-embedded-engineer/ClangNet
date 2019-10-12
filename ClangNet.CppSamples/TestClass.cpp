#include "TestClass.h"

namespace root
{
    namespace sub1
    {
        namespace sub2
        {
            TestClass::TestClass()
                : m_a(0)
                , m_b(0)
                , m_result(0)
            {
            }

            TestClass::~TestClass()
            {

            }

            void TestClass::PublicMethod(int a, int b)
            {
                int result = this->PrivateMethod(a, b);

                this->SetResult(result);
            }

            int TestClass::PrivateMethod(int a, int b)
            {
                this->SetA(a);
                this->SetB(b);

                return this->m_a + this->m_b;
            }
        }
    }
}

