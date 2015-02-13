#include <iostream>
#include "Tree.h"
#include <fstream>
#include <string>
#include "checkSymbol.h"

using namespace std;

struct TreeElement
{
	ElementType value;
	int number;				// поле, в которое будем записывать результаты арифметических операций
	TreeElement *leftChild;
	TreeElement *rightChild;
};

struct Tree
{
	TreeElement *root = nullptr;
};

Tree* createTree()
{
	return new Tree;
}

// Создаем новый элемент
TreeElement* createNewElement(ElementType value)
{
	TreeElement *newElement = new TreeElement;
	newElement->leftChild = nullptr;
	newElement->rightChild = nullptr;
	newElement->value = value;
	newElement->number = value - '0';  // записываем в поле number число (оно может получиться и отрицательным, если value будет знаком, но нам это неважно)
	return newElement;
}

// Проверка, полная ли ветвь
bool isBranchFull(TreeElement* treeElement)
{
	if (treeElement == nullptr)
	{
		return false;
	}

	if (isOperation(treeElement->value))
	{
		return isBranchFull(treeElement->leftChild) && isBranchFull(treeElement->rightChild);
	}

	return true;
}

void addElement(TreeElement* treeElement, ElementType value)
{
	if (treeElement->leftChild == nullptr)
	{
		treeElement->leftChild = createNewElement(value);
		return;
	}

	if (isOperation(treeElement->leftChild->value) && !isBranchFull(treeElement->leftChild))
	{
		addElement(treeElement->leftChild, value);
		return;
	}

	if (treeElement->rightChild == nullptr)
	{
		treeElement->rightChild = createNewElement(value);
		return;
	}

	if (isOperation(treeElement->rightChild->value) && !isBranchFull(treeElement->rightChild))
	{
		addElement(treeElement->rightChild, value);
		return;
	}
}

void addElement(Tree* tree, ElementType value)
{
	if (tree->root != nullptr)
	{
		addElement(tree->root, value);
	}
	else
	{
		tree->root = createNewElement(value);
	}
}

// Вспомогательная функция для calculateNums. Удаляем из дерева один элемент, у которого нет сыновей и возвращаем его значение
int deleteTreeElement(TreeElement* &treeElement)
{
	int num = treeElement->number;
	delete treeElement;
	treeElement = nullptr;
	return num;
}

// Вспомогательная функция для calculateValues
void calculateNums(TreeElement* treeElement)
{
	if (isAddition(treeElement->value))  // если сложение, то удаляем двух сыновей и присваиваем отцу в поле number их суммарное значение
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) + deleteTreeElement(treeElement->rightChild);
	}
	else if (isSubtraction(treeElement->value))  // если вычитание, то...
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) - deleteTreeElement(treeElement->rightChild);
	}
	else if (isMultiplication(treeElement->value))  // если умножение, то...
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) * deleteTreeElement(treeElement->rightChild);
	}
	else if (isDivision(treeElement->value))  // если деление, то...
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) / deleteTreeElement(treeElement->rightChild);
	}

	treeElement->value = '1';  // в поле value отцу, у которого теперь нет сыновей присваиваем символ, равный цифре, для того,
}							  // чтобы в calculateValues удобно было проверять: !isDigit(treeElement->leftChild->value)

void calculateValues(TreeElement* treeElement)
{
	while (!isDigit(treeElement->leftChild->value))  // если не цифра, значит, оператор, т.е. у левого сына есть точно своих два сына
	{												// если же цифра, значит, нет сыновей у левого сына
		treeElement = treeElement->leftChild;
	}

	if (!isDigit(treeElement->rightChild->value))  // если не цифра, значит, у правого сына есть своих два сына
	{
		calculateValues(treeElement->rightChild);  // вызываем рекурсию для правого сына
	}
	else
	{
		calculateNums(treeElement);	 // если дошли досюда, это означает, что у treeElement есть два сына, причем у каждого
	}							    // из них в поле value цифра, т.е. нет больше сыновей, вызываем calculateNums (см. выше)
}

// Вызываем calculateValues(tree->root), пока корень дерева не останется без сыновей
int calculateNums(Tree* tree)
{
	while ((tree->root->leftChild != nullptr) && (tree->root->rightChild != nullptr)) 
	{
		calculateValues(tree->root);
	}

	return tree->root->number;
}

bool isCorrectReading(Tree* tree)
{
	ifstream file("Expression.txt", ios::in);

	if (file.is_open())
	{
		int i = 0;

		while (!file.eof())
		{
			int sizeOfArray = 50;
			string expression;
			getline(file, expression);

			if (!isCorrectString(expression))  // если выражение некорректно, возвращаем false
			{
				return false;
			}

			while (expression[i] != '\0')
			{
				if (isDigit(expression[i]) || isOperation(expression[i]))  
				{
					addElement(tree, expression[i]);
				}

				i++;
			}
		}
	}

	file.close();
	return true;
}

void printTree(TreeElement* treeElement)
{
	cout << treeElement->value << " ";

	if (treeElement->leftChild != nullptr)
	{
		printTree(treeElement->leftChild);
	}

	if (treeElement->rightChild != nullptr)
	{
		printTree(treeElement->rightChild);
	}
}

void printTree(Tree* tree)
{
	printTree(tree->root);
}

// Проверка, пустое ли дерево
bool isEmptyTree(Tree* tree)
{
	return tree->root == nullptr;
}

// Вспомогательная функция для deleteTree, удаляет все элементы из дерева
void deleteTreeElements(TreeElement* &treeElement)
{
	if (treeElement->leftChild != nullptr)
	{
		deleteTreeElements(treeElement->leftChild);
	}

	if (treeElement->rightChild != nullptr)
	{
		deleteTreeElements(treeElement->rightChild);
	}

	delete treeElement;
	treeElement = nullptr;
}

void deleteTree(Tree* tree)
{
	if (!isEmptyTree(tree))
	{
		deleteTreeElements(tree->root);
	}

	delete tree;
}