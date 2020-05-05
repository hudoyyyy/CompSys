#include <iostream>
#include <bitset>

int main()
{
	int a, b;
	std::cout << "Input 2 numbers: " << std::endl;
	std::cin >> a >> b;
	std::bitset<32> bs1(a), bs2(b);
	std::cout << "The value of first variable is:" << bs1 << std::endl;
	std::cout << "The value of second variable is: " << bs2 << std::endl;

	std::bitset<64> reg;
	for (int i = 0; i < bs1.size(); ++i)
		reg[i] = bs1[i];
	std::cout << "REGISTER IS NEXT:" << reg << std::endl;
	std::cout << "Next steps is:" << std::endl;
	for (int i = 0; i < 32; ++i)
	{
		int lsb = reg[0];
		reg >>= 1;
		std::cout << reg << "][" << lsb << std::endl;
		if (lsb == 1)
		{
			std::cout << reg << std::endl;
			std::cout << "+" << std::endl;
			std::cout << bs2 << std::endl;
			std::cout << "_________________________________________________________________" << std::endl;

			std::bitset<32> a;
			for (int k = 0; k < 32; ++k)
				a[k] = reg[31 + k];

			std::bitset<32> m("1"), result;
			for (int j = 0; j < 32; ++j)
			{
				std::bitset<32> const diff(((a >> j)& m).to_ullong() + ((bs2 >> j)& m).to_ullong() + (result >> j).to_ullong());
				result ^= (diff ^ (result >> j)) << j;
			}

			for (int k = 0; k < 32; ++k)
				reg[k + 31] = result[k];
			std::cout << reg << std::endl;
		}
	}
	std::cout << std::endl << "Result is: " << reg << std::endl;
	std::cout << "Multiplication result for " << a << " and " << b << " is " << a * b << std::endl;
	return 0;
}