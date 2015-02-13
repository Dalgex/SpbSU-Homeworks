#include <iostream>
#include "stack.h"

struct StackElement
{
	char value;
	StackElement *next;
};

struct Stack
{
	StackElement *top = nullptr;
};

Stack* createStack()
{
	Stack *stack = new Stack;
	return stack;
}

void push(Stack* stack, char value)
{
	StackElement *stackElement = new StackElement;
	stackElement->value = value;
	stackElement->next = stack->top;
	stack->top = stackElement;
}

char pop(Stack* stack)
{
	if (stack->top == nullptr)
	{
		return ' ';
	}

	int temp = stack->top->value;
	StackElement *stackElement = stack->top;
	stack->top = stack->top->next;
	delete stackElement;
	return temp;
}

bool isEmpty(Stack* stack)
{
	return stack->top == nullptr;
}

char valueElement(Stack* stack)
{
	return stack->top->value;
}

void deleteStack(Stack* stack)
{
	while (!isEmpty)
	{
		pop(stack);
	}

	delete stack;
} 