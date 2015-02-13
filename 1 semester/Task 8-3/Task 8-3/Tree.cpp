#include <iostream>
#include "Tree.h"
#include <fstream>
#include <string>
#include "checkSymbol.h"

using namespace std;

struct TreeElement
{
	ElementType value;
	int number;				// ����, � ������� ����� ���������� ���������� �������������� ��������
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

// ������� ����� �������
TreeElement* createNewElement(ElementType value)
{
	TreeElement *newElement = new TreeElement;
	newElement->leftChild = nullptr;
	newElement->rightChild = nullptr;
	newElement->value = value;
	newElement->number = value - '0';  // ���������� � ���� number ����� (��� ����� ���������� � �������������, ���� value ����� ������, �� ��� ��� �������)
	return newElement;
}

// ��������, ������ �� �����
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

// ��������������� ������� ��� calculateNums. ������� �� ������ ���� �������, � �������� ��� ������� � ���������� ��� ��������
int deleteTreeElement(TreeElement* &treeElement)
{
	int num = treeElement->number;
	delete treeElement;
	treeElement = nullptr;
	return num;
}

// ��������������� ������� ��� calculateValues
void calculateNums(TreeElement* treeElement)
{
	if (isAddition(treeElement->value))  // ���� ��������, �� ������� ���� ������� � ����������� ���� � ���� number �� ��������� ��������
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) + deleteTreeElement(treeElement->rightChild);
	}
	else if (isSubtraction(treeElement->value))  // ���� ���������, ��...
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) - deleteTreeElement(treeElement->rightChild);
	}
	else if (isMultiplication(treeElement->value))  // ���� ���������, ��...
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) * deleteTreeElement(treeElement->rightChild);
	}
	else if (isDivision(treeElement->value))  // ���� �������, ��...
	{
		treeElement->number = deleteTreeElement(treeElement->leftChild) / deleteTreeElement(treeElement->rightChild);
	}

	treeElement->value = '1';  // � ���� value ����, � �������� ������ ��� ������� ����������� ������, ������ �����, ��� ����,
}							  // ����� � calculateValues ������ ���� ���������: !isDigit(treeElement->leftChild->value)

void calculateValues(TreeElement* treeElement)
{
	while (!isDigit(treeElement->leftChild->value))  // ���� �� �����, ������, ��������, �.�. � ������ ���� ���� ����� ����� ��� ����
	{												// ���� �� �����, ������, ��� ������� � ������ ����
		treeElement = treeElement->leftChild;
	}

	if (!isDigit(treeElement->rightChild->value))  // ���� �� �����, ������, � ������� ���� ���� ����� ��� ����
	{
		calculateValues(treeElement->rightChild);  // �������� �������� ��� ������� ����
	}
	else
	{
		calculateNums(treeElement);	 // ���� ����� ������, ��� ��������, ��� � treeElement ���� ��� ����, ������ � �������
	}							    // �� ��� � ���� value �����, �.�. ��� ������ �������, �������� calculateNums (��. ����)
}

// �������� calculateValues(tree->root), ���� ������ ������ �� ��������� ��� �������
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

			if (!isCorrectString(expression))  // ���� ��������� �����������, ���������� false
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

// ��������, ������ �� ������
bool isEmptyTree(Tree* tree)
{
	return tree->root == nullptr;
}

// ��������������� ������� ��� deleteTree, ������� ��� �������� �� ������
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