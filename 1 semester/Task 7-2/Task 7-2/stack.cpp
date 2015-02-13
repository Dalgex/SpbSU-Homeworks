#include <iostream>
#include "stack.h"

struct StackElement
{
	int value;
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

void push(Stack *stack, int value)
{
	StackElement *stackElement = new StackElement;
	stackElement->value = value;
	stackElement->next = stack->top;
	stack->top = stackElement;
}

int pop(Stack *stack)
{
	if (stack->top == nullptr)
	{
		return 1;
	}

	int result = stack->top->value;
	StackElement *stackElement = stack->top;
	stack->top = stack->top->next;
	delete stackElement;
	return result;
}

bool isEmpty(Stack *stack)
{
	return stack->top == nullptr;
}

StackElement* firstElement(Stack* stack)
{
	return stack->top;
}

StackElement* secondElement(Stack* stack)
{
	return stack->top->next;
}

void deleteStack(Stack *stack)
{
	while (!isEmpty(stack))
	{
		pop(stack);
	}

	delete stack;
}