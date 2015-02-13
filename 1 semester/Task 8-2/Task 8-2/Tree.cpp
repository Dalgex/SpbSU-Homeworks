#include <iostream>
#include "Tree.h"

using namespace std;

struct TreeElement
{
	ElementType value;
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

TreeElement* createNewElement(ElementType value)
{
	TreeElement *newElement = new TreeElement;
	newElement->leftChild = nullptr;
	newElement->rightChild = nullptr;
	newElement->value = value;
	return newElement;
}

// Вспомогательная функция для addTreeElement
void addElement(TreeElement* treeElement, ElementType value)
{
	while (treeElement->value != value)
	{
		if (value < treeElement->value)
		{
			if (treeElement->leftChild == nullptr)
			{
				treeElement->leftChild = createNewElement(value);
				break;
			}

			treeElement = treeElement->leftChild;
		}
		else
		{
			if (treeElement->rightChild == nullptr)
			{
				treeElement->rightChild = createNewElement(value);
				break;
			}

			treeElement = treeElement->rightChild;
		}
	}
}

void addTreeElement(Tree* tree, ElementType value)
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

bool isContains(Tree* tree, ElementType value)
{
	TreeElement *cursor = tree->root;

	while (cursor != nullptr)
	{
		if (cursor->value == value)
		{
			return true;
		}
		
		if (cursor->value > value)
		{
			cursor = cursor->leftChild;
		}
		else
		{
			cursor = cursor->rightChild;
		}
	}

	return false;
}

// Вызываем данную функцию в printTree, если нам нужно расположить значения в порядке возрастания
void printInAscendingOrder(TreeElement* treeElement)
{
	if (treeElement->leftChild != nullptr)
	{
		printInAscendingOrder(treeElement->leftChild);
	}

	cout << treeElement->value << " ";

	if (treeElement->rightChild != nullptr)
	{
		printInAscendingOrder(treeElement->rightChild);
	}
}

// Вызываем данную функцию в printTree, если нам нужно отстортировать значения в порядке убывания
void printInDescendingOrder(TreeElement* treeElement)
{
	if (treeElement->rightChild != nullptr)
	{
		printInDescendingOrder(treeElement->rightChild);
	}

	cout << treeElement->value << " ";

	if (treeElement->leftChild != nullptr)
	{
		printInDescendingOrder(treeElement->leftChild);
	}
}

// Проверка, пустое ли дерево
bool isEmptyTree(Tree* tree)
{
	return tree->root == nullptr;
}

void printTree(Tree* tree, bool descending)
{
	if (isEmptyTree(tree))
	{
		cout << "Дерево пустое";
		return;
	}

	if (descending)
	{
		printInDescendingOrder(tree->root);
	}
	else
	{
		printInAscendingOrder(tree->root);
	}
}

// Вспомогательная функция для removeElement, возвращающая значение минимального элемента
int searchMinElement(TreeElement* current)
{
	while (current->leftChild != nullptr)
	{
		current = current->leftChild;
	}

	int value = current->value;
	return value;
}

void removeElementWithoutChildren(TreeElement* &current, ElementType value)
{
	if (current->value == value)
	{
		delete current;
		current = nullptr;
		cout << "Значение удалено";
	}
	else
	{
		cout << "Такое число не найдено";
	}
}

void removeElementWithLeftChild(TreeElement* &current, ElementType value)
{
	if (value > current->value)
	{
		cout << "Такое число не найдено";
		return;
	}

	if (value < current->value)
	{
		removeElement(current->leftChild, value);
	}
	else
	{
		TreeElement *cursor = current;
		current = current->leftChild;
		delete cursor;
		cursor = nullptr;
		cout << "Значение удалено";
	}
}

void removeElementWithRightChild(TreeElement* &current, ElementType value)
{
	if (value < current->value)
	{
		cout << "Такое число не найдено";
		return;
	}

	if (value > current->value)
	{
		removeElement(current->rightChild, value);
	}
	else
	{
		TreeElement *cursor = current;
		current = current->rightChild;
		delete cursor;
		cursor = nullptr;
		cout << "Значение удалено";
	}
}

void removeElementWithTwoChildren(TreeElement* &current, ElementType value)
{
	if (current->value > value)         // если значение меньше, то вызываем рекурсию по левому сыну
	{
		removeElement(current->leftChild, value);
	}
	else if (current->value < value)    // если значение больше, то вызываем рекурсию по правому сыну
	{
		removeElement(current->rightChild, value);
	}
	else
	{
		current->value = searchMinElement(current->rightChild); // среди правого поддерева находим самый маленький элемент, присваиваем его значение удаляемому 
		removeElement(current->rightChild, current->value);  // элементу, но удаляем именно тот элемент, у которого нашли минимальное значение из правого поддерева
	}
}

// Передаем параметр по ссылке. current - это какой-то из сыновей предыдущего узла. Прежде чем удалить его, нужно сделать так,
// чтобы предыдущий узел стал иметь нового сына - сына элемента current'а, иначе потеряется связь
void removeElement(TreeElement* &current, ElementType value)
{
	if ((current->leftChild == nullptr) && (current->rightChild == nullptr)) // если нет сыновей
	{
		removeElementWithoutChildren(current, value);
		return;
	}

	if ((current->leftChild != nullptr) && (current->rightChild == nullptr)) // если только левый сын
	{
		removeElementWithLeftChild(current, value);
		return;
	}

	if ((current->leftChild == nullptr) && (current->rightChild != nullptr)) // если только правый сын
	{
		removeElementWithRightChild(current, value);
		return;
	}

	removeElementWithTwoChildren(current, value);
}

void removeElement(Tree* tree, ElementType value)
{
	if (isEmptyTree(tree))
	{
		cout << "Дерево пустое";
	}
	else
	{
		removeElement(tree->root, value);
	}
}

// Вспомогательная функция для deleteAllElements, удаляет все элементы из дерева
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

void deleteAllElements(Tree* tree)
{
	if (!isEmptyTree(tree))
	{
		deleteTreeElements(tree->root);
	}
}

void deleteTree(Tree* tree)
{
	deleteAllElements(tree);
	delete tree;
}