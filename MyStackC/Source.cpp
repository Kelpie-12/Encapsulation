#include <iostream>
#include <stdexcept>
using namespace std;

template <typename T>
class MyStack
{
public:
	MyStack() : root(nullptr) {}
	void Push(const T& x)
	{
		Node* newnode = new Node;
		newnode->data = x;
		newnode->next = root;
		root = newnode;
	}
	bool Is_Empty() const
	{
		return root == nullptr;
	}
	const T& Top()const
	{
		if (Is_Empty())
		{
			throw length_error("stack is empty");
		}
		return root->data;
	}
	T Pop()
	{
		if (Is_Empty())
		{
			throw length_error("stack is empty");
		}
		Node* delete_elment = root;
		T data = delete_elment->data;
		root = delete_elment->next;
		delete delete_elment;
		return data;
	}

	~MyStack()
	{
		while (!Is_Empty())
		{
			Pop();
		}
	}
private:
	struct Node
	{
		T data;
		Node* next;
	};
	Node* root;
};


template<typename T>
class LinkList {
private:
	class node {
	public:
		T data;
		node* next;
		node* prew;

	};
	node* head;
	node* tail;
	int count = 0;
public:
	LinkList()
	{
		head = tail = nullptr;
		count = 0;
	}
	~LinkList()
	{
		Clear();
	}
	int Get_Count() const { return count; }
	void Add_Element(T source)
	{
		node* new_element = new node;
		new_element->data = source;
		if (head == nullptr)
		{
			head = tail = new_element;
			head->prew = nullptr;
		}
		else
		{
			tail->next = new_element;
			new_element->prew = tail;
			tail = new_element;
		}
		tail->next = nullptr;
		count++;
	}
	void Delete_Element()
	{
		node* move = head;
		if (head != nullptr)
		{
			if (count > 1)
			{
				head = head->next;
				head->prew = nullptr;
			}
			count--;
			if (count == 0)
			{
				head = tail = nullptr;
			}
			delete[]move;
		}
		else
		{
			throw exception("no element");
		}
	}	
	void Clear()
	{
		while (count > 0)
		{
			Delete_Element();
		}
	}	
	T operator[](int index) {
		node* move = new node;
		if (index >= 0 && index < count)
		{
			if (count / 2 > index)
			{
				move = head;
				for (size_t i = 0; i < index; i++)
				{
					move = move->next;
				}
			}
			else
			{
				move = tail;
				for (size_t i = 0; i < count - index - 1; i++)
				{
					move = move->prew;
				}
			}
			return move->data;
		}
		throw  exception("out of range!");
	}
	void Delete_Element(int index) {
		if (count && index >= 0 && index < count)
		{
			node* move = new node;
			if (index == 0 || count == 1)
			{
				Delete_Element();
			}
			else if (index == count - 1)
			{
				if (head != nullptr)
				{
					if (count > 1)
					{
						move = tail;
						tail = tail->prew;
						tail->next = nullptr;
					}
					count--;
					if (count == 0)
					{
						head = tail = nullptr;
					}
					delete move;
				}
			}
			else
			{
				if (count / 2 > index)
				{
					move = head;
					for (size_t i = 0; i < index - 1; i++)
					{
						move = move->next;
					}
				}
				else
				{
					move = tail;
					for (size_t i = 0; i < count - index - 1; i++)
					{
						move = move->prew;
					}
				}
				move->next->prew = move->prew;
				move->prew->next = move->next;
				delete move;
				count--;
			}
		}
	}
	void Add_Element(int index, T source)
	{
		node* new_element = new node;
		new_element->data = source;
		node* move;
		int c = index;
		if (c < 0)
		{
			move = head;

			new_element->prew = nullptr;
			new_element->next = move;
			head = new_element;
			count++;
		}
		else if (c >= count)
		{
			Add_Element(source);
		}
		else
		{
			if (head == nullptr)
			{
				head = tail = new_element;
				head->prew = nullptr;
			}
			else
			{
				if (count / 2 > c)
				{
					move = head;
					for (size_t i = 0; i < c - 1; i++)
					{
						move = move->next;
					}
				}
				else
				{
					move = tail;
					for (size_t i = 0; i < count - c - 1; i++)
					{
						move = move->prew;
					}
				}
				new_element->prew = move->prew;
				new_element->next = move;
				move->prew->next = new_element;
				move->prew = new_element;
				count++;
			}
		}
	}
	void Push_Front(T source)
	{
		node* new_element = new node;
		new_element->data = source;
		node* move;
		move = head;
		new_element->prew = move->prew;
		new_element->next = move;
		move->prew->next = new_element;
		move->prew = new_element;
		count++;
	}

};

//template<typename T>
class MyQueue {
private:
	int count = 0;
	/*struct Data
	{
		T data;
	};*/	
	
	LinkList<int> queArray;
public:

	MyQueue()
	{
		count = 0;
	}	
	void Push_Front(int data)
	{
		queArray.Push_Front(data);
		count++;
	}
	void Push_Back(int data)
	{
		queArray.Add_Element(count,data);
		count++;
	}
	int Pop_Front()
	{
		auto value = queArray[0];
		count--;
		queArray.Delete_Element(0);
		return value;
	}
	int Pop_Back()
	{
		auto value = queArray[count-1];
		queArray.Delete_Element(count);
		count--;		
		return value;
	}
};
int main()
{
	MyStack<int> a;
	for (size_t i = 0; i < 10; i++)
	{
		a.Push(i + 5);
	}
	for (size_t i = 0; i < 10; i++)
	{
		cout << a.Pop() << "\t";
	}
	MyQueue b;
	cout << endl;
	for (size_t i = 0; i < 10; i++)
	{
		b.Push_Back(i + 10);
	}
	for (size_t i = 0; i < 10; i++)
	{
		cout << b.Pop_Back() << "\t";
	}

}