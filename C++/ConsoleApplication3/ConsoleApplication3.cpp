﻿#include "stdafx.h"
#include <iostream>

#include <string>

using namespace std;
class Car
{
	const int v_max;
	float speed;
public:
	Car(int _v_max, float _speed): v_max(_v_max)
	{
		this->speed = _speed;
	}
	int getV()
	{
		return v_max;
	}
	int getS()
	{
		return speed;
	}
	void setS(float _speed)
	{
		this->speed = _speed;
	}
	
};

class BitOperator
{
protected:
	int bit;
public:
	BitOperator()
	{
		bit = 0;
	}
	virtual ~BitOperator()
	{

	}
	void setBit(int position)
	{
		bit |= 1UL << position;
	}
	void clearBit(int position)
	{
		bit &= ~(1UL << position);
	}
	void toggleBit(int position)
	{
		bit ^= 1UL << position;
	}
};

class BitFormatter : public BitOperator
{
	string bits;
	int _bit;
public:
	BitFormatter()
	{
		bits = "";
	}
	~BitFormatter()
	{
		
	}
	string getBit()
	{
		_bit = bit;
		if (bit == 0)
			return "0";
		while (_bit >= 1)
		{
			if (_bit % 2 == 0)
				bits += "0";
			else
				bits += "1";
			_bit /= 2;
		}
		reverse(bits.begin(), bits.end());

		return bits;
	}
};

class Figure
{
	int x, y;
public:
	Figure() 
	{
		x = 5;
		y = 15;
	}
	Figure(int _x, int _y)
	{
		x = _x;
		y = _y;
	}
	virtual ~Figure();
	virtual void draw() = 0;
	int getX()
	{
		return x;
	}
	int getY()
	{
		return y;
	}
};
Figure::~Figure()
{
	cout << "Figure des" << endl;
}
class Rectangle : public Figure
{
public:
	Rectangle(): Figure(115, 1115)
	{

	}
	~Rectangle()
	{
		cout << "Rectangle" << endl;
	}
	void draw()
	{
		cout << "Rysuje prostokat" << endl;
	}
};
class Triangle : public Figure
{
public:
	Triangle()
	{

	}
	~Triangle()
	{
		cout << "Triangle" << endl;
	}
	void draw()
	{
		cout << "Rysuje trojkat" << endl;
	}
};

class Single
{
	static Single *singleton;
	Single()
	{
		cout << "Konstruktor singletona";
	}
public:
	static Single *getSingleton()
	{
		if (!singleton)
			singleton = new Single();
		return singleton;
	}
};

Single* Single::singleton = nullptr;

bool checkPalindrom(string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		if (str[i] != str[str.length() - i-1])
			return false;
	}
	return true;
}
int strlenM(const char *txt)
{
	int i;
	for (i = 0; txt[i] != '\0'; i++);
	return i;
}

int main()
{
	Car car(10, 0);
	Car *car2 = new Car(10, 0);

	cout << car2->getS() << endl;

	cout << car.getV() << endl;

	delete car2;

	cout << endl;

	//@@@@@@@@@@@@@@@@@@@@@@@@@@@

	BitFormatter *bt = new BitFormatter();

	cout << bt->getBit() << endl;
	bt->setBit(2);
	bt->toggleBit(2);
	bt->clearBit(3);
	bt->toggleBit(3);
	cout << bt->getBit() << endl;

	delete bt;

	cout << endl;

	//@@@@@@@@@@@@@@@@@@@@@@@@@@

	Figure **figury = new Figure*[2];

	figury[0] = new Rectangle();
	figury[1] = new Triangle();

	figury[0]->draw();
	figury[1]->draw();

	cout << figury[0]->getX() << endl;
	cout << figury[1]->getY() << endl;

	cout << endl;

	delete figury[0];
	delete figury[1];
	delete[] figury;

	cout << endl;

	//@@@@@@@@@@@@@@@@@@@@@@@@@@

	Single *ptr = ptr->getSingleton();
	Single *ptr2 = Single::getSingleton();

	cout << ptr << " == " << ptr << endl;

	cout << endl;

	//@@@@@@@@@@@@@@@@@@@@@@@@@@

	string text;
	text = "xxttdsattasdttxx";

	checkPalindrom(text) ? cout << "Tak" : cout << "Nie";

	cout << endl << endl;

	//@@@@@@@@@@@@@@@@@@@@@@@@@@@

	cout << strlenM("Xdsdfg") << endl;
	
	cout << endl;

	//@@@@@@@@@@@@@@@@@@@@@@@@@@@

	system("pause");

    return 0;
}

