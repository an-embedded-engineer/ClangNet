int main(void);
int Add(int a, int b);

class TestClass
{
public:
    TestClass()
    {
        this->m_a = 0;
        this->m_b = 0;
    }

    TestClass(int a, int b);

    ~TestClass(){}

    int Add();

private:
    int m_a;
    int m_b;
};